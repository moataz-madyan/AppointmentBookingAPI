
using System.ComponentModel.DataAnnotations;

namespace AppointmentBookingAPI.Models;

public class Appointment
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string CustomerName { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }

    public int ProviderId { get; set; }

    public Provider? Provider { get; set; }
}
