using Microsoft.AspNetCore.Mvc;

namespace Avvr.Kappusta.Zoya.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateAccount() => Created();
}