namespace InternshipProject.DAL.Entities;

internal class Ticket
{  
    internal int Id { get; set; }
    internal Event? Event { get; set; }
    internal int EventId { get; set; }
    internal Place? Place { get; set; }
    internal int PlaceId { get; set; }
    internal bool IsBought { get; set; }
}