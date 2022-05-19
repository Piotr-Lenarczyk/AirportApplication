using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportApplication.Models;

public class Seat
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SeatId { get; set; }
    public int SeatRow { get; set; }
    public bool AisleTaken { get; set; } = false;
    public bool CenterTaken { get; set; } = false;
    public bool WindowTaken { get; set; } = false;
}