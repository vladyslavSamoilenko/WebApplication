using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using laboratorium1.Models;

namespace laboratorium1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Calculator()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Calculator(string? op , double? a, double? b)
    {
        // var op = Request.Query["op"];
        // var a = double.Parse(Request.Query["a"]);
        // var b = double.Parse(Request.Query["b"]);
        if (a is null || b is null)
        {   
            ViewBag.ErrorMessage = "Niepoprawny format liczby";
            return View("CustomError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny operator";
            return View("CustomError");
        }

        ViewBag.op = op;
        ViewBag.a = a;
        ViewBag.b = b;
        switch (op)
        {
            case "add":
                ViewBag.Result = a + b;
                ViewBag.Operator = "+";
                break;
            case "sub":
                ViewBag.Result = a - b;
                ViewBag.Operator = "-";
                break;
            case "mul":
                ViewBag.Result = a * b;
                ViewBag.Operator = "*";
                break;
            case "div":
                ViewBag.Result = a / b;
                ViewBag.Operator = "/";
                break;
            default:
                ViewBag.ErrorMessage = "Nieznan operator";
                return View("CustomError");
        }

        return View();
    }
    
    public IActionResult Birth()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Birth(string name, DateTime? birthDate)
    {
        if (string.IsNullOrEmpty(name) || birthDate == null || birthDate >= DateTime.Now)
        {
            ViewBag.ErrorMessage = "Sprawdz czy wpisales poprawnie dane";
            return View();
        }
        
        var today = DateTime.Today;
        var age = today.Year - birthDate.Value.Year;

        if (birthDate.Value.Date > today.AddYears(-age)) age--;

        ViewBag.Message = $"Cześć {name}, masz {age} lat(a).";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    
}

public enum Operator
{
    add,sub,mul,div
}