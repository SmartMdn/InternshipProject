namespace InternshipProject.DAL.Entities;

internal class Event : DefaultEntity
{
    public string? Name { get; set; }
    public int EventDuration { get; set; }
    public DateTime EventDate { get; set; }
    public int BookingPeriodDays { get; set; }

    public Hall? EventHall { get; set; }
    public int HallId { get; set; }

    public List<Ticket>? EventTickets { get; set; }
}