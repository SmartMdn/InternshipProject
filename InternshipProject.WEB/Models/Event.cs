namespace InternshipProject.WEB.Models;

public class Event
{
    public string? Name { get; set; }
    public int EventDuration { get; set; }
    public int BookingPeriodDays { get; set; }
    public int HallId { get; set; }
}