namespace InternshipProject.DAL.Entities;

public class Ticket
{
    public int Id { get; set; }
    public Event? Event { get; set; }
    public Place? Place { get; set; }
}