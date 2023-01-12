namespace InternshipProject.DAL.Entities;

internal class Hall : DefaultEntity
{
    public string Name { get; set; }
    public Stadium Stadium { get; set; }
    public int StadiumId { get; set; }
    public List<Event>? Events { get; set; }
    public List<Section>? Sections { get; set; }
}