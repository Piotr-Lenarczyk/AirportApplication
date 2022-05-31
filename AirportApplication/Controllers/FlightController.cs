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
    
    public IActionResult Book(string id)
    {
        var flights = _db.Flights.Include("FlightName");
        Flight flight = flights.FirstOrDefault(item => item.FlightName == id);
        return View(flight);
    }
    
    [HttpPost]
    public IActionResult Book()
    {
        var seat = Request.Form["SeatType"].ToString();
        var name = Request.Form["Flight"].ToString();
        if (seat == "Window Seat")
        {
            return RedirectToAction("WindowSuccess", new { id = name});
        }
        else if (seat == "Center Seat")
        {
            return RedirectToAction("CenterSuccess", new { id = name});
        }
        else if (seat == "Aisle Seat")
        {
            Random random = new Random();
            int number = random.Next(0, 2);
            if (number == 0)
            {
                return RedirectToAction("Failure");
            }
            else
            {
                return RedirectToAction("AisleSuccess", new { id = name});
            }
        }
        return RedirectToAction("Index");
    }
    
    public IActionResult WindowSuccess(string id)
    {
        var flights = _db.Flights.Include("FlightName");
        Flight flight = flights.FirstOrDefault(item => item.FlightName == id);
        return View(flight);
    }
    
    public IActionResult CenterSuccess(string id)
    {
        var flights = _db.Flights.Include("FlightName");
        Flight flight = flights.FirstOrDefault(item => item.FlightName == id);
        return View(flight);
    }
    
    public IActionResult AisleSuccess(string id)
    {
        var flights = _db.Flights.Include("FlightName");
        Flight flight = flights.FirstOrDefault(item => item.FlightName == id);
        return View(flight);
    }

    public IActionResult Failure()
    {
        return View();
    }
}