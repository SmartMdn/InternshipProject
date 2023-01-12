namespace InternshipProject.DAL.Entities;

internal class Ticket : DefaultEntity 
{
    public Event? Event { get; set; }
    public int EventId { get; set; }
    public Place? Place { get; set; }
    public int PlaceId { get; set; }
    public bool IsBought { get; set; }
}