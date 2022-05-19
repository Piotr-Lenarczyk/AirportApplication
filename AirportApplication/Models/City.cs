using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportApplication.Models;

public class City
{
    [Key]
    public string CityName { get; set; } = string.Empty;

    [Display(Name = "Country")]
    public string? Country { get; set; }

    [ForeignKey("Country")]
    public virtual List<Country> Countries { get; set; }
}