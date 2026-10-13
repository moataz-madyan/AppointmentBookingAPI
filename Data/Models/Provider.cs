
using System.ComponentModel.DataAnnotations;

namespace AppointmentBookingAPI.Models;

public class Provider
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Specialty { get; set; } = string.Empty;

    [System.Text.Json.Serialization.JsonIgnore]
public List<Appointment> Appointments { get; set; } = new();
}
