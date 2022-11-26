namespace InternshipProject.DAL.Entities;



public class Place
{
    public int Id { get; set; }
    public PlaceType Type { get; set; }
    
    public Section Section { get; set; }
    public string SectionName { get; set; }
    
    public Ticket? Ticket { get; set; }
    public int? TicketId { get; set; }
}