namespace InternshipProject.BLL.DTO;

public class HallDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int[]? Stadiums { get; set; }
    public int[]? Sections { get; set; }
}