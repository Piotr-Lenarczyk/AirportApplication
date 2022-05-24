using System.Data.Entity;
using AirportApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportApplication.Controllers;

[Authorize]
public class SeatController : Controller
{
    private SqLiteContext _db = new SqLiteContext();
    
    public IActionResult Index()
    {
        var airports = _db.Seats.Include("SeatId");
        return View(airports);
    }
    
    // GET
    public IActionResult Create()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Create(Seat seat)
    {
        _db.Seats?.Add(seat);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Edit(Seat seat)
    {
        seat.SeatId = Convert.ToInt32(Request.Path.Value.Substring(11));
        _db.Seats?.Update(seat);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        return View();
    }

    public IActionResult Delete(int id)
    {
        return View();
    }
    
    // POST
    [HttpPost]
    public IActionResult Delete(Seat seat)
    {
        seat.SeatId = Convert.ToInt32(Request.Path.Value.Substring(13));
        _db.Seats?.Remove(seat);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}