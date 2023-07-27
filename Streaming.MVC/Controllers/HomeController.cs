using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Streaming.MVC.Models;

namespace Streaming.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HomeController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

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

    public IActionResult Video() 
    {  
        var contentRootPath = _webHostEnvironment.ContentRootPath;
        var filePath = Path.Combine(contentRootPath, "Media/sample.mp4");

        return File(fileStream: System.IO.File.OpenRead(filePath), contentType: "video/mp4", enableRangeProcessing: true);
    }  
}
