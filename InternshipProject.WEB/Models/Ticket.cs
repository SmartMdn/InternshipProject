namespace InternshipProject.WEB.Models;

public class Ticket
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public int PlaceId { get; set; }
    public bool IsBought { get; set; }
}