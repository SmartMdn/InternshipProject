namespace InternshipProject.DAL.Entities;

public class Hall
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Stadium Stadium { get; set; }
    public int StadiumId { get; set; }
    public List<Event>? Events { get; set; }
    public List<Section>? Sections { get; set; }
}