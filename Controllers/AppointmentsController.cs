
using AppointmentBookingAPI.Data;
using AppointmentBookingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBookingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AppointmentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAppointments()
    {
        var appointments = await _context.Appointments
            .Include(a => a.Provider)
            .ToListAsync();

        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointment(int id)
    {
        var appointment = await _context.Appointments
            .Include(a => a.Provider)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (appointment == null)
            return NotFound();

        return Ok(appointment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment(Appointment appointment)
    {
        if (appointment.EndTime <= appointment.StartTime)
        {
            return BadRequest("End time must be after start time.");
        }

        if (appointment.StartTime <= DateTime.Now)
        {
            return BadRequest("Appointment must be in the future.");
        }

        var providerExists = await _context.Providers
            .AnyAsync(p => p.Id == appointment.ProviderId);

        if (!providerExists)
        {
            return BadRequest("Provider not found.");
        }

        var hasConflict = await _context.Appointments.AnyAsync(a =>
            a.ProviderId == appointment.ProviderId &&
            appointment.StartTime < a.EndTime &&
            appointment.EndTime > a.StartTime);

        if (hasConflict)
        {
            return Conflict("This provider already has an appointment at that time.");
        }

        appointment.Id = 0;
        appointment.Provider = null;

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetAppointment),
            new { id = appointment.Id },
            appointment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);

        if (appointment == null)
            return NotFound();

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
