using EduHome.Business.Dtos;
using EduHome.Business.Services.Abstractions;
using EduHome.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class CourseController : Controller
{
    private readonly ICourseService _service;

    public CourseController(ICourseService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _service.GetAllAsync();

        return View(categories);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var dto = await _service.GetCreatedDtoAsync();

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CourseCreateDto dto)
    {
        var result = await _service.CreateAsync(dto, ModelState);

        if (result is false)
        {
            dto = await _service.GetCreatedDtoAsync(dto);
            return View(dto);
        }

        return RedirectToAction("Index");
    }



    public async Task<IActionResult> DeleteImage(int id)
    {
        await _service.DeleteImageAsync(id);

        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var result = await _service.GetUpdatedDtoAsync(id);

        return View(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(CourseUpdateDto dto)
    {
        var result = await _service.UpdateAsync(dto, ModelState);

        if (result is false)
        {
            dto = await _service.GetUpdatedDtoAsync(dto);
            return View(dto);
        }

        return RedirectToAction("Index");
    }
}
