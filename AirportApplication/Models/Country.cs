using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportApplication.Models;

public class Country
{
    [Key]
    public string CountryName { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}