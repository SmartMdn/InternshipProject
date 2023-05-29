namespace InternshipProject.WEB.Models;

public class Hall
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int StadiumId { get; set; }
    public int[]? Sections { get; set; }
}