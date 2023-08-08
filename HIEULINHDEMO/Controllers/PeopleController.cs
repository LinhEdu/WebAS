using System.Diagnostics;
using HIEULINHDEMO.DbContext;
using Microsoft.AspNetCore.Mvc;
using HIEULINHDEMO.Models;

namespace HIEULINHDEMO.Controllers;

public class PeopleController : Controller
{
    private readonly ILogger<PeopleController> _logger;
    private readonly ApplicationDbContext _db;
    
    public PeopleController(ILogger<PeopleController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }
    public IActionResult Index()
    {
        var peoples = _db.Peoples.ToList();
        return View(peoples);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View(new People());
    }

    [HttpPost]
    public IActionResult Create(People people)
    {
        if (ModelState.IsValid)
        {
            _db.Peoples.Add(people);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(people);
    }

    public IActionResult Update(int peopleId)
    {
        var people = _db.Peoples.Find(peopleId);
        return View(people);
    }

    [HttpPost]
    public IActionResult Update(People people)
    {
        var peopleFromDb = _db.Peoples.Find(people.Id);
        peopleFromDb.Name = people.Name;
        peopleFromDb.Age = people.Age;
        peopleFromDb.Description = people.Description;

        _db.Peoples.Update(peopleFromDb);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpGet]
    public IActionResult Delete(int peopleId)
    {
        var people = _db.Peoples.Find(peopleId);
        _db.Peoples.Remove(people);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}