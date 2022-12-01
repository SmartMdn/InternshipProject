namespace InternshipProject.DAL.Entities;

public class Place
{
    public int Id { get; set; }
    public PlaceType Type { get; set; }
    public List<Section>? Sections { get; set; }
    public List<Ticket>? Tickets { get; set; }
}