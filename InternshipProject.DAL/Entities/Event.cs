namespace InternshipProject.DAL.Entities;

public class Event
{
    public int Id { get; set; }
    public int EventDuration { get; set; }

    public Hall? EventHall { get; set; }
    public int HallId { get; set; }
}