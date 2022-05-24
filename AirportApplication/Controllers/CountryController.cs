using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using AirportApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace AirportApplication.Controllers;

public class CountryController : Controller
{
    private SqLiteContext _db = new SqLiteContext();

    // GET
    public IActionResult Index()
    {
        var countries = _db.Countries.Include("CountryName");
        return View(countries);
    }
    
    // GET
    public IActionResult Create()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Create(Country country)
    {
        _db.Countries?.Add(country);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public IActionResult Edit()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Edit(Country country)
    {
        country.CountryName = Request.Path.Value.Substring(14);
        _db.Countries?.Update(country);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(string id)
    {
        var countries = _db.Countries.Include("CountryName");
        Country country = countries.FirstOrDefault(item => item.CountryName == id);
        return View(country);
    }

    public IActionResult Delete(string id)
    {
        var countries = _db.Countries.Include("CountryName");
        Country country = countries.FirstOrDefault(item => item.CountryName == id);
        return View(country);
    }
    
    // POST
    [HttpPost]
    public IActionResult Delete(Country country)
    {
        _db.Countries?.Remove(country);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}