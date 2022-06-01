using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using AirportApplication.Models;
using Microsoft.Data.Sqlite;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace AirportApplication.Controllers;

[Route("[controller]")]
[ApiController]
public class Countries : Controller
{
    private SqLiteContext _db = new SqLiteContext();
    
    // GET: /Countries
    /// <summary>
    /// Retrieves all Country objects
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IQueryable<Country> ListOut()
    {
        var countries = _db.Countries.Include("CountryName");
        return countries;
    }
    
    // POST: /Countries
    /// <summary>
    /// Creates a new Country object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <response code="201">Resource was successfully created</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(string name, string code)
    {
        var country = new Country
        {
            CountryName = name,
            Code = code
        };
        try
        {
            _db.Countries?.Add(country);
            _db.SaveChanges();
            return Created("/Countries/" + country.CountryName, country);
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    // GET: /Countries/{name}
    /// <summary>
    /// Retrieves a single Country object
    /// </summary>
    /// <param name="name"></param>
    [HttpGet("{name}")]
    public Country Details(string name)
    {
        var countries = _db.Countries.Include("CountryName");
        Country country = countries.FirstOrDefault(item => item.CountryName == name);
        if (country != null)
        {
            return country;
        }
        return null;
    }
    
    // PATCH: /Countries/{name}
    /// <summary>
    /// Partially updates a Country object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <response code="200">Resource was successfully updated</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPatch("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Edit(string name, string code)
    {
        var country = new Country
        {
            CountryName = name,
            Code = code
        };
        try
        {
            _db.Countries?.Update(country);
            _db.SaveChanges();
            return Ok();
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    // PUT: /Countries/{name}
    /// <summary>
    /// Updates or creates a Country object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <response code="200">Resource was successfully updated</response>
    /// <response code="201">Resource was successfully created</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPut("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put(string name, string code)
    {
        var country = new Country
        {
            CountryName = name,
            Code = code
        };
        var countries = _db.Countries.Include("CountryName");
        Country existing = countries.FirstOrDefault(item => item.CountryName == name);
        try
        {
            if (existing == null)
            {
                _db.Countries?.Add(country);
                _db.SaveChanges();
                return Created("/Countries/" + country.CountryName, country);
            }
            if (country.CountryName == existing.CountryName)
            {
                _db.Entry(existing).State = EntityState.Detached;
                _db.Countries?.Update(country);
                _db.SaveChanges();
                return Ok();
            }
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
        return null;
    }
    
    // DELETE: /Countries/{name}
    /// <summary>
    /// Deletes a Country object
    /// </summary>
    /// <param name="name"></param>
    /// <response code="204">Resource was successfully deleted</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpDelete("{name}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(string name)
    {
        var countries = _db.Countries.Include("CountryName");
        Country country = countries.FirstOrDefault(item => item.CountryName == name);
        try
        {
            _db.Countries?.Remove(country);
            _db.SaveChanges();
            return NoContent();
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}

[Route("[controller]")]
[ApiController]
public class Cities : Controller
{
    private SqLiteContext _db = new SqLiteContext();
    
    // GET: /Cities
    /// <summary>
    /// Retrieves all City objects
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IQueryable<City> ListOut()
    {
        var cities = _db.Cities.Include("CityName");
        return cities;
    }
    
    // POST: /Cities
    /// <summary>
    /// Creates a new City object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="country"></param>
    /// <response code="201">Resource was successfully created</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(string name, string country)
    {
        var city = new City
        {
            CityName = name,
            Country = country
        };
        try
        {
            _db.Cities?.Add(city);
            _db.SaveChanges();
            return Created("/Cities/" + city.CityName, city);
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    // GET: /Cities/{name}
    /// <summary>
    /// Retrieves a single City object
    /// </summary>
    /// <param name="name"></param>
    [HttpGet("{name}")]
    public City Details(string name)
    {
        var cities = _db.Cities.Include("CityName");
        City city = cities.FirstOrDefault(item => item.CityName == name);
        if (city != null)
        {
            return city;
        }
        return null;
    }
    
    // PATCH: /Cities/{name}
    /// <summary>
    /// Partially updates a City object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="country"></param>
    /// <response code="200">Resource was successfully updated</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPatch("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Edit(string name, string country)
    {
        var city = new City
        {
            CityName = name,
            Country = country
        };
        try
        {
            _db.Cities?.Update(city);
            _db.SaveChanges();
            return Ok();
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    // PUT: /Cities/{name}
    /// <summary>
    /// Updates or creates a City object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="country"></param>
    /// <response code="200">Resource was successfully updated</response>
    /// <response code="201">Resource was successfully created</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPut("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put(string name, string country)
    {
        var city = new City
        {
            CityName = name,
            Country = country
        };
        var cities = _db.Cities.Include("CityName");
        City existing = cities.FirstOrDefault(item => item.CityName == name);
        try
        {
            if (existing == null)
            {
                _db.Cities?.Add(city);
                _db.SaveChanges();
                return Created("/Cities/" + city.CityName, city);
            }
            if (city.CityName == existing.CityName)
            {
                _db.Entry(existing).State = EntityState.Detached;
                _db.Cities?.Update(city);
                _db.SaveChanges();
                return Ok();
            }
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
        return null;
    }
    
    // DELETE: /Cities/{name}
    /// <summary>
    /// Deletes a City object
    /// </summary>
    /// <param name="name"></param>
    /// <response code="204">Resource was successfully deleted</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpDelete("{name}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(string name)
    {
        var cities = _db.Cities.Include("CountryName");
        City city = cities.FirstOrDefault(item => item.CityName == name);
        try
        {
            _db.Cities?.Remove(city);
            _db.SaveChanges();
            return NoContent();
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}

[Route("[controller]")]
[ApiController]
public class Airports : Controller
{
    private SqLiteContext _db = new SqLiteContext();
    
    // GET: /Airports
    /// <summary>
    /// Retrieves all Airport objects
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IQueryable<Airport> ListOut()
    {
        var airports = _db.Airports.Include("AirportName");
        return airports;
    }
    
    // POST: /Airports
    /// <summary>
    /// Creates a new Airport object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="city"></param>
    /// <response code="201">Resource was successfully created</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(string name, string city)
    {
        var airport = new Airport
        {
            AirportName = name,
            City = city
        };
        try
        {
            _db.Airports?.Add(airport);
            _db.SaveChanges();
            return Created("/Airports/" + airport.AirportName, airport);
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    // GET: /Airports/{name}
    /// <summary>
    /// Retrieves a single Airport object
    /// </summary>
    /// <param name="name"></param>
    [HttpGet("{name}")]
    public Airport Details(string name)
    {
        var airports = _db.Airports.Include("CityName");
        Airport airport = airports.FirstOrDefault(item => item.AirportName == name);
        if (airport != null)
        {
            return airport;
        }
        return null;
    }
    
    // PATCH: /Airports/{name}
    /// <summary>
    /// Partially updates a Airport object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="city"></param>
    /// <response code="200">Resource was successfully updated</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPatch("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Edit(string name, string city)
    {
        var airport = new Airport
        {
            AirportName = name,
            City = city
        };
        try
        {
            _db.Airports?.Update(airport);
            _db.SaveChanges();
            return Ok();
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    // PUT: /Airports/{name}
    /// <summary>
    /// Updates or creates a Airport object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="city"></param>
    /// <response code="200">Resource was successfully updated</response>
    /// <response code="201">Resource was successfully created</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPut("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put(string name, string city)
    {
        var airport = new Airport
        {
            AirportName = name,
            City = city
        };
        var cities = _db.Airports.Include("AirportName");
        Airport existing = cities.FirstOrDefault(item => item.AirportName == name);
        try
        {
            if (existing == null)
            {
                _db.Airports?.Add(airport);
                _db.SaveChanges();
                return Created("/Airports/" + airport.AirportName, airport);
            }
            if (airport.AirportName == existing.AirportName)
            {
                _db.Entry(existing).State = EntityState.Detached;
                _db.Airports?.Update(airport);
                _db.SaveChanges();
                return Ok();
            }
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
        return null;
    }
    
    // DELETE: /Airports/{name}
    /// <summary>
    /// Deletes a Airport object
    /// </summary>
    /// <param name="name"></param>
    /// <response code="204">Resource was successfully deleted</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpDelete("{name}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(string name)
    {
        var airports = _db.Airports.Include("CountryName");
        Airport airport = airports.FirstOrDefault(item => item.AirportName == name);
        try
        {
            _db.Airports?.Remove(airport);
            _db.SaveChanges();
            return NoContent();
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}

[Route("[controller]")]
[ApiController]
public class Seats : Controller
{
    private SqLiteContext _db = new SqLiteContext();

    // GET: /Seats
    /// <summary>
    /// Retrieves all Seat objects
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IQueryable<Seat> ListOut()
    {
        var seat = _db.Seats.Include("SeatId");
        return seat;
    }

    // POST: /Seats
    /// <summary>
    /// Creates a new Seat object
    /// </summary>
    /// <param name="row"></param>
    /// <param name="aisleTaken"></param>
    /// <param name="centerTaken"></param>
    /// <param name="windowTaken"></param>
    /// <response code="201">Resource was successfully created</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(int row, bool aisleTaken, bool centerTaken, bool windowTaken)
    {
        var seat = new Seat
        {
            SeatRow = row,
            AisleTaken = aisleTaken,
            CenterTaken = centerTaken,
            WindowTaken = windowTaken
        };
        try
        {
            _db.Seats?.Add(seat);
            _db.SaveChanges();
            return Created("/Seats/" + seat.SeatId, seat);
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    // GET: /Seats/{id}
    /// <summary>
    /// Retrieves a single Seat object
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    public Seat Details(int id)
    {
        var seats = _db.Seats.Include("SeatId");
        Seat seat = seats.FirstOrDefault(item => item.SeatId == id);
        if (seat != null)
        {
            return seat;
        }

        return null;
    }

    // PATCH: /Seats/{id}
    /// <summary>
    /// Partially updates a Seat object
    /// </summary>
    /// <param name="row"></param>
    /// <param name="aisleTaken"></param>
    /// <param name="centerTaken"></param>
    /// <param name="windowTaken"></param>
    /// <response code="200">Resource was successfully updated</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Edit(int row, bool aisleTaken, bool centerTaken, bool windowTaken)
    {
        var seat = new Seat
        {
            SeatRow = row,
            AisleTaken = aisleTaken,
            CenterTaken = centerTaken,
            WindowTaken = windowTaken
        };
        try
        {
            _db.Seats?.Update(seat);
            _db.SaveChanges();
            return Ok();
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    // PUT: /Airports/{id}
    /// <summary>
    /// Updates or creates a Seat object
    /// </summary>
    /// <param name="row"></param>
    /// <param name="aisleTaken"></param>
    /// <param name="centerTaken"></param>
    /// <param name="windowTaken"></param>
    /// <response code="200">Resource was successfully updated</response>
    /// <response code="201">Resource was successfully created</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put(int row, bool aisleTaken, bool centerTaken, bool windowTaken)
    {
        var seat = new Seat
        {
            SeatRow = row,
            AisleTaken = aisleTaken,
            CenterTaken = centerTaken,
            WindowTaken = windowTaken
        };
        var seats = _db.Seats.Include("Seatid");
        Seat existing = seats.FirstOrDefault(item => item.SeatRow == row);
        try
        {
            if (existing == null)
            {
                _db.Seats?.Add(seat);
                _db.SaveChanges();
                return Created("/Seats/" + seat.SeatId, seat);
            }

            if (seat.SeatId == existing.SeatId)
            {
                _db.Entry(existing).State = EntityState.Detached;
                _db.Seats?.Update(seat);
                _db.SaveChanges();
                return Ok();
            }
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }

        return null;
    }

    // DELETE: /Seats/{id}
    /// <summary>
    /// Deletes a Seat object
    /// </summary>
    /// <param name="id"></param>
    /// <response code="204">Resource was successfully deleted</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(int id)
    {
        var seats = _db.Seats.Include("SeatId");
        Seat seat = seats.FirstOrDefault(item => item.SeatId == id);
        try
        {
            _db.Seats?.Remove(seat);
            _db.SaveChanges();
            return NoContent();
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}

[Route("[controller]")]
[ApiController]
public class Flights : Controller
{
    private SqLiteContext _db = new SqLiteContext();
    
    // GET: /Flights
    /// <summary>
    /// Retrieves all Flight objects
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IQueryable<Flight> ListOut()
    {
        var flights = _db.Flights.Include("FlightName");
        return flights;
    }
    
    // POST: /Flights
    /// <summary>
    /// Creates a new Flight object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="departureAirport"></param>
    /// <param name="arrivalAirport"></param>
    /// <param name="departureDate"></param>
    /// <param name="departureTime"></param>
    /// <param name="departureGate"></param>
    /// <response code="201">Resource was successfully created</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(string name, string departureAirport, string arrivalAirport, string departureDate,
        string departureTime, int departureGate)
    {
        var flight = new Flight
        {
            FlightName = name,
            DepartureAirport = departureAirport,
            ArrivalAirport = arrivalAirport,
            DepartureDate = DateOnly.Parse(departureDate),
            DepartureTime = TimeOnly.Parse(departureTime),
            DepartureGate = departureGate
        };
        try
        {
            _db.Flights?.Add(flight);
            _db.SaveChanges();
            return Created("/Flights/" + flight.FlightName, flight);
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    // GET: /Flights/{name}
    /// <summary>
    /// Retrieves a single Flight object
    /// </summary>
    /// <param name="name"></param>
    [HttpGet("{name}")]
    public Flight Details(string name)
    {
        var flights = _db.Flights.Include("FlightName");
        Flight flight = flights.FirstOrDefault(item => item.FlightName == name);
        if (flight != null)
        {
            return flight;
        }
        return null;
    }
    
    // PATCH: /Flights/{name}
    /// <summary>
    /// Partially updates a Flight object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="departureAirport"></param>
    /// <param name="arrivalAirport"></param>
    /// <param name="departureDate"></param>
    /// <param name="departureTime"></param>
    /// <param name="departureGate"></param>
    /// <response code="200">Resource was successfully updated</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPatch("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Edit(string name, string departureAirport, string arrivalAirport, string departureDate,
        string departureTime, int departureGate)
    {
        var flight = new Flight
        {
            FlightName = name,
            DepartureAirport = departureAirport,
            ArrivalAirport = arrivalAirport,
            DepartureDate = DateOnly.Parse(departureDate),
            DepartureTime = TimeOnly.Parse(departureTime),
            DepartureGate = departureGate
        };
        try
        {
            _db.Flights?.Update(flight);
            _db.SaveChanges();
            return Ok();
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    // PUT: /Flights/{name}
    /// <summary>
    /// Updates or creates a Flight object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="departureAirport"></param>
    /// <param name="arrivalAirport"></param>
    /// <param name="departureDate"></param>
    /// <param name="departureTime"></param>
    /// <param name="departureGate"></param>
    /// <response code="200">Resource was successfully updated</response>
    /// <response code="201">Resource was successfully created</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpPut("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put(string name, string departureAirport, string arrivalAirport, string departureDate,
        string departureTime, int departureGate)
    {
        var flight = new Flight
        {
            FlightName = name,
            DepartureAirport = departureAirport,
            ArrivalAirport = arrivalAirport,
            DepartureDate = DateOnly.Parse(departureDate),
            DepartureTime = TimeOnly.Parse(departureTime),
            DepartureGate = departureGate
        };
        var flights = _db.Flights.Include("FlightName");
        Flight existing = flights.FirstOrDefault(item => item.FlightName == name);
        try
        {
            if (existing == null)
            {
                _db.Flights?.Add(flight);
                _db.SaveChanges();
                return Created("/Flights/" + flight.FlightName, flight);
            }
            if (flight.FlightName == existing.FlightName)
            {
                _db.Entry(existing).State = EntityState.Detached;
                _db.Flights?.Update(flight);
                _db.SaveChanges();
                return Ok();
            }
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
        return null;
    }
    
    // DELETE: /Flights/{name}
    /// <summary>
    /// Deletes a Flight object
    /// </summary>
    /// <param name="name"></param>
    /// <response code="204">Resource was successfully deleted</response>
    /// <response code="400">Wrong parameters were provided</response>
    [HttpDelete("{name}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(string name)
    {
        var flights = _db.Flights.Include("CountryName");
        Flight flight = flights.FirstOrDefault(item => item.FlightName == name);
        try
        {
            _db.Flights?.Remove(flight);
            _db.SaveChanges();
            return NoContent();
        }
        catch (SqliteException e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}
