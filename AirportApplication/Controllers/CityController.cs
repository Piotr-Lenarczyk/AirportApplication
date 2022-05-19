using System.Data.Entity;
using AirportApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace AirportApplication.Controllers;

public class CityController : Controller
{
    private SqLiteContext _db = new SqLiteContext();
    
    // GET
    public IActionResult Index()
    {
        var cities = _db.Cities.Include("CityName");
        return View(cities);
    }
    
    // GET
    public IActionResult Create()
    {
        ViewBag.Countries = _db.Countries.Include("CountryName");
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Create(City city)
    {
        city.Country = Request.Form["values"].ToString();
        _db.Cities?.Add(city);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit()
    {
        ViewBag.Countries = _db.Countries.Include("CountryName");
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Edit(City city)
    {
        city.CityName = Request.Path.Value.Substring(11);
        city.Country =  Request.Form["values"].ToString();
        _db.Cities?.Update(city);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(string id)
    {
        var cities = _db.Cities.Include("CityName");
        City city = cities.FirstOrDefault(item => item.CityName == id);
        return View(city);
    }

    public IActionResult Delete(string id)
    {
        var cities = _db.Cities.Include("CityName");
        City city = cities.FirstOrDefault(item => item.CityName == id);
        return View(city);
    }
    
    // POST
    [HttpPost]
    public IActionResult Delete(City city)
    {
        _db.Cities?.Remove(city);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}