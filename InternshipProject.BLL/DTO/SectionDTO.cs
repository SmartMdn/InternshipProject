namespace InternshipProject.BLL.DTO;

public class SectionDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HallId { get; set; }
    public int[]? Places { get; set; }
}