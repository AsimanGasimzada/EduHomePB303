using EduHome.Business.Dtos;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.Presentation.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EduHome.Presentation.Controllers;

public class CourseController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public CourseController(AppDbContext context, UserManager<AppUser> user)
    {
        _context = context;
        _userManager = user;
    }

    public async Task<IActionResult> Detail(int id)
    {
        var course = await _context.Courses
                    .Include(x => x.CourseDetails).Include(x => x.CourseImages)
                    .Include(x => x.Comments.Where(x => x.ParentId == null)).ThenInclude(x => x.AppUser).Include(x => x.Comments)
                    .ThenInclude(x => x.Children).ThenInclude(x => x.AppUser) //for replies
                    .FirstOrDefaultAsync(x => x.Id == id);



        if (course is null)
            return NotFound();

        course.Comments = course.Comments.Where(x => x.ParentId == null).ToList();
        return View(course);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostComment(CommentCreateDto dto)
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return BadRequest();

        var course = await _context.Courses.Include(x => x.Comments.Where(x => x.ParentId == null)).FirstOrDefaultAsync(x => x.Id == dto.CourseId);

        if (course is null)
            return BadRequest();

        Comment comment = new()
        {
            Text = dto.Text,
            Rating = dto.Rating,
            AppUserId = userId,
            CourseId = dto.CourseId,

        };


        course.Comments.Add(comment);

        await _context.Comments.AddAsync(comment);

        var avaragePoint = Math.Round((decimal)(course.Comments!.Sum(x => (int)x.Rating)) / (decimal)course.Comments.Count);

        course.Rating = (int)avaragePoint;

        _context.Courses.Update(course);
        await _context.SaveChangesAsync();

        string returnUrl = Request.GetReturnUrl();

        return Redirect(returnUrl);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ReplyComment(CommentReplyDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return BadRequest();

        var isExistParent = await _context.Comments.AnyAsync(x => x.Id == dto.ParentId && x.ParentId == null);

        if (!isExistParent)
            return BadRequest();


        var isExistCourse = await _context.Courses.AnyAsync(x => x.Id == dto.CourseId);

        if (!isExistCourse)
            return BadRequest();

        Comment comment = new()
        {
            Text = dto.Text,
            AppUserId = userId,
            CourseId = dto.CourseId,
            ParentId = dto.ParentId,
        };

        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();


        string returnUrl = Request.GetReturnUrl();

        return Redirect(returnUrl);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var comment = await _context.Comments.Include(x => x.Children).FirstOrDefaultAsync(x => x.Id == id);

        if (comment is null)
            return NotFound();




        _context.Comments.Remove(comment);


        _context.Comments.RemoveRange(comment.Children);
        await _context.SaveChangesAsync();

        string returnUrl = Request.GetReturnUrl();

        return Redirect(returnUrl);

    }
}
