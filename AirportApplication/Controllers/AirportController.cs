using System.Data.Entity;
using AirportApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportApplication.Controllers;

[Authorize]
public class AirportController : Controller
{
    private SqLiteContext _db = new SqLiteContext();
    
    // GET
    public IActionResult Index()
    {
        var airports = _db.Airports.Include("AirportName");
        return View(airports);
    }
    
    // GET
    public IActionResult Create()
    {
        ViewBag.Cities = _db.Cities.Include("CityName");
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Create(Airport airport)
    {
        airport.City = Request.Form["values"].ToString();
        _db.Airports?.Add(airport);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit()
    {
        ViewBag.Cities = _db.Cities.Include("CityName");
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Edit(Airport airport)
    {
        airport.AirportName = Request.Path.Value.Substring(14);
        airport.City =  Request.Form["values"].ToString();
        _db.Airports?.Update(airport);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(string id)
    {
        var airports = _db.Airports.Include("AirportName");
        Airport airport = airports.FirstOrDefault(item => item.AirportName == id);
        return View(airport);
    }

    public IActionResult Delete(string id)
    {
        var airports = _db.Airports.Include("AirportName");
        Airport airport = airports.FirstOrDefault(item => item.AirportName == id);
        return View(airport);
    }
    
    // POST
    [HttpPost]
    public IActionResult Delete(Airport airport)
    {
        _db.Airports?.Remove(airport);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}