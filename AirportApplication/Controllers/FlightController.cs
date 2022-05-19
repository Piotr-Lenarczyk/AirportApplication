using System.Data.Entity;
using AirportApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirportApplication.Controllers;

public class FlightController : Controller
{
    private SqLiteContext _db = new SqLiteContext();
    
    // GET
    public IActionResult Index()
    {
        var flights = _db.Flights.Include("FlightName");
        return View(flights);
    }
    
    // GET
    public IActionResult Create()
    {
        ViewBag.Airports = _db.Airports.Include("AirportName");
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Create(Flight flight)
    {
        flight.DepartureAirport = Request.Form["departure"].ToString();
        flight.ArrivalAirport = Request.Form["arrival"].ToString();
        flight.DepartureDate = DateOnly.Parse(Request.Form["DepartureDate"].ToString());
        flight.DepartureTime = TimeOnly.Parse(Request.Form["DepartureTime"].ToString());
        _db.Flights?.Add(flight);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit()
    {
        ViewBag.Airports = _db.Airports.Include("AirportName");
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Edit(Flight flight)
    {
        flight.FlightName = Request.Path.Value.Substring(13);
        flight.DepartureAirport = Request.Form["departure"].ToString();
        flight.ArrivalAirport = Request.Form["arrival"].ToString();
        flight.DepartureDate = DateOnly.Parse(Request.Form["DepartureDate"].ToString());
        flight.DepartureTime = TimeOnly.Parse(Request.Form["DepartureTime"].ToString());
        _db.Flights?.Update(flight);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(string id)
    {
        var flights = _db.Flights.Include("FlightName");
        Flight flight = flights.FirstOrDefault(item => item.FlightName == id);
        return View(flight);
    }

    public IActionResult Delete(string id)
    {
        var flights = _db.Flights.Include("FlightName");
        Flight flight = flights.FirstOrDefault(item => item.FlightName == id);
        return View(flight);
    }
    
    // POST
    [HttpPost]
    public IActionResult Delete(Flight flight)
    {
        _db.Flights?.Remove(flight);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}