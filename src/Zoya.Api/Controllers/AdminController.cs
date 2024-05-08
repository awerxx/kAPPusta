using Microsoft.AspNetCore.Mvc;

namespace Avvr.Kappusta.Zoya.Api.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}