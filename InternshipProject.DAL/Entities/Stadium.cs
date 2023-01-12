namespace InternshipProject.DAL.Entities;

internal class Stadium : DefaultEntity
{
    public string Name { get; set; }
    public string? Address { get; set; }
    public List<Hall>? Halls { get; set; }
}