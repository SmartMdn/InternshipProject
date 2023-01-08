namespace InternshipProject.DAL.Entities;

internal class Section
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Hall Hall { get; set; }
    public int HallId { get; set; }
    public List<Place>? Places { get; set; }
}