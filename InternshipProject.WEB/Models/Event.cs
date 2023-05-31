namespace InternshipProject.WEB.Models;

public class Event
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int EventDuration { get; set; }
    public DateTime EventDate { get; set; }
    public int BookingPeriodDays { get; set; }
    public int HallId { get; set; }
    public int CategoryId { get; set; }
}