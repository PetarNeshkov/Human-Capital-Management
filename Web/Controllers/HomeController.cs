using System.Diagnostics;
using HumanCapitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanCapitalManagement.Web.Controllers;

public class HomeController(ILogger<HomeController> logger)
    : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}