namespace InternshipProject.WEB.Models;

public class Section
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int[]? Halls { get; set; }
    public int[]? Places { get; set; }
}