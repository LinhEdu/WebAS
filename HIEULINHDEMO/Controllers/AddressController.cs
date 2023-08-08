using HIEULINHDEMO.DbContext;
using HIEULINHDEMO.Models;
using HIEULINHDEMO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HIEULINHDEMO.Controllers;

public class AddressController : Controller
{
    private readonly ApplicationDbContext _db;
    public AddressController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    // GET
    public IActionResult Index()
    {
        var addresses = _db.Addresses.ToList();
        return View(addresses);
    }
    
    public IActionResult Create()
    {
        var addressVm = new UpSertAddressVM()
        {
            Address = new Address(),
            Peoples = _db.Peoples.ToList().Select(people =>
                new SelectListItem
                {
                    Text = people.Name,
                    Value = people.Id.ToString()
                }
            ).ToList()
        };
        return View(addressVm);
    }

    public IActionResult Update(int addressId)
    {
        var addressVm = new UpSertAddressVM()
        {
            Address = _db.Addresses.Find(addressId),
            Peoples = _db.Peoples.ToList().Select(people =>
                new SelectListItem
                {
                    Text = people.Name,
                    Value = people.Id.ToString()
                }
            ).ToList()
        };
        return View(addressVm);
    }

    [HttpPost]
    public IActionResult Update(UpSertAddressVM upSertAddressVm)
    {
        if (upSertAddressVm.Address.Position != null && upSertAddressVm.Address.PeopleId != null)
        {
            var addressFromDb = _db.Addresses.Find(upSertAddressVm.Address.Id);
            addressFromDb.Position = upSertAddressVm.Address.Position;
            addressFromDb.PeopleId = upSertAddressVm.Address.PeopleId;
            _db.Addresses.Update(addressFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        upSertAddressVm.Peoples = _db.Peoples.ToList().Select(people =>
            new SelectListItem
            {
                Text = people.Name,
                Value = people.Id.ToString()
            }
        ).ToList();
        return View(upSertAddressVm);
    }
    
    [HttpPost]
    public IActionResult Create(UpSertAddressVM upSertAddressVm)
    {
        if (upSertAddressVm.Address.Position != null && upSertAddressVm.Address.PeopleId != null)
        {
            _db.Addresses.Add(upSertAddressVm.Address);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        upSertAddressVm.Peoples = _db.Peoples.ToList().Select(people =>
            new SelectListItem
            {
                Text = people.Name,
                Value = people.Id.ToString()
            }
        ).ToList();
        
        return View(upSertAddressVm);
    }
    
    [HttpGet]
    public IActionResult Delete(int addressId)
    {
        var address = _db.Addresses.Find(addressId);
        _db.Addresses.Remove(address);
        _db.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
}