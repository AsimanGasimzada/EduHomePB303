using Microsoft.AspNetCore.Mvc;

namespace EduHome.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
