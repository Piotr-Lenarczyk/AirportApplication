using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportApplication.Models;

public class Airport
{
    [Key]
    public string AirportName { get; set; } = string.Empty;
    
    [Display(Name = "City")]
    public string? City { get; set; }

    [ForeignKey("City")]
    public virtual List<City> Cities { get; set; }
}