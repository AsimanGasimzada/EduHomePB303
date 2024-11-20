using EduHome.Business.Services.Abstractions;
using EduHome.Presentation.Constants;
using EduHome.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILanguageService _languageService;

    public HomeController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ChangeLanguage(string language)
    {
        Response.Cookies.Append("selectedLanguage", language);

        string? retunUrl = Request.GetReturnUrl();

        LanguageConstants.SelectedLanguage = language;

        return Redirect(retunUrl);
    }


}
