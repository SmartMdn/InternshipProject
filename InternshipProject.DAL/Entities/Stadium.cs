namespace InternshipProject.DAL.Entities;

public class Stadium
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public List<Hall>? Halls { get; set; }
}