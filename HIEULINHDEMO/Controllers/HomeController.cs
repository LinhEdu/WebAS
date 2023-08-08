using System.Diagnostics;
using HIEULINHDEMO.DbContext;
using Microsoft.AspNetCore.Mvc;
using HIEULINHDEMO.Models;

namespace HIEULINHDEMO.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        // var people = new People()
        // {
        //     Name = "Nhat Linh",
        //     Age = 15,
        //     Description = "Lazy"
        // };
        // _db.Peoples.Add(people);
        // _db.SaveChanges();
        // return View();

        // var people = _db.Peoples.Find(1);
        // _db.Peoples.Remove(people);
        // _db.SaveChanges();

        // var peoples= _db.Peoples.ToList();

        // var peoples = _db.Peoples.Where(p => p.Age >= 12).ToList();
        
        // var people = _db.Peoples.Find(5);
        // people.Name = "Link";
        // _db.Peoples.Update(people);
        // _db.SaveChanges();
        // return View();
        var peoples = _db.Peoples.ToList();
        return View(peoples);
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