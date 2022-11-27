namespace InternshipProject.DAL.Entities;



public class Place
{
    public int Id { get; set; }
    public PlaceType Type { get; set; }
    
    public Hall? Hall { get; set; }
    public string HallName { get; set; }
    
    public List<Ticket>? Tickets { get; set; }
}