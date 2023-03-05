using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

public class Cinema : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}