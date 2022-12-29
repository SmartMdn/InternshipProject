namespace InternshipProject.DAL.Entities;

internal class Event
{
    internal int Id { get; set; }
    internal string? Name { get; set; }
    internal int EventDuration { get; set; }
    internal int BookingPeriodDays { get; set; }

    internal Hall? EventHall { get; set; }
    internal int HallId { get; set; }

    internal List<Ticket>? EventTickets { get; set; }
}