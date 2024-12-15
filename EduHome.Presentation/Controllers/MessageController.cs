﻿using EduHome.Business.Hubs;
using EduHome.Business.StaticFiles;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.Presentation.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EduHome.Presentation.Controllers;
[Authorize]
public class MessageController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AppDbContext _context;
    private readonly IHubContext<ChatHub> _chatHubContext;

    public MessageController(UserManager<AppUser> userManager, AppDbContext context, IHubContext<ChatHub> chatHubContext)
    {
        _userManager = userManager;
        _context = context;
        _chatHubContext = chatHubContext;
    }

    public async Task<IActionResult> Index()
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return BadRequest();


        var chats = await _context.Chats.Include(x => x.AppUserChats).Where(x => x.AppUserChats.Any(x => x.AppUserId == userId)).ToListAsync();


        return View(chats);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return BadRequest();

        var chat = await _context.Chats.Include(x => x.AppUserChats).ThenInclude(x => x.AppUser)
                                .Include(x => x.Messages)
                                .FirstOrDefaultAsync(x => x.Id == id && x.AppUserChats.Any(x => x.AppUserId == userId));


        if (chat is null)
            return NotFound();

        return View(chat);
    }


    [HttpPost]
    public async Task<IActionResult> SendMessage(int chatId, string text)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return BadRequest();

        var chat = await _context.Chats.Include(x => x.AppUserChats).ThenInclude(x => x.AppUser)
                              .Include(x => x.Messages)
                              .FirstOrDefaultAsync(x => x.Id == chatId && x.AppUserChats.Any(x => x.AppUserId == userId));

        if (chat is null)
            return NotFound();

        Message message = new()
        {
            Text = text,
            ChatId = chatId,
            SenderId = userId,
        };

        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();

        message.Chat = null; // view model isletmediyimiz ucun ic ice include un qarsisini aliriq


        foreach (var userChat in chat.AppUserChats.Where(x => x.AppUserId != userId))
        {
            var connection = HubDatas.Connections.FirstOrDefault(x => x.UserId == userChat.AppUserId);
            if (connection is { })
            {
                foreach (var id in connection.ConnectionIds)
                {
                    await _chatHubContext.Clients.Client(id).SendAsync("ReceiveMessage", message);
                }
            }
        }



        return Json(message);
    }
    public IActionResult Test()
    {
        return View();
    }

}
