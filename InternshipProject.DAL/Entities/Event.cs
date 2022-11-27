namespace InternshipProject.DAL.Entities;

public class Event
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int EventDuration { get; set; }

    public Hall? EventHall { get; set; }
    public string HallName { get; set; }
    
    public List<Ticket>? EventTickets { get; set; }
}