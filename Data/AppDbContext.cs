
using Microsoft.EntityFrameworkCore;
using AppointmentBookingAPI.Models;

namespace AppointmentBookingAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Provider> Providers { get; set; } = null!;

    public DbSet<Appointment> Appointments { get; set; } = null!;
}
