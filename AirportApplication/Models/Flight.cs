using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportApplication.Models;

public class Flight
{
    [Key]
    public string FlightName { get; set; } = string.Empty;
    
    [Display(Name = "DepartureAirport")]
    public string? DepartureAirport { get; set; }
    
    [ForeignKey("DepartureAirport")]
    public virtual List<Airport> DepartureAirports { get; set; }
    
    [Display(Name = "ArrivalAirport")]
    public string? ArrivalAirport { get; set; }
    
    [ForeignKey("ArrivalAirport")]
    public virtual List<Airport> ArrivalAirports { get; set; }

    public DateOnly DepartureDate { get; set; }
    
    public TimeOnly DepartureTime { get; set; }

    public int DepartureGate { get; set; }
    
    public ICollection<Seat>? Seats { get; set; }
}