namespace InternshipProject.BLL.DTO;

public class HallDTO : BaseDTO
{
    public string? Name { get; set; }
    public int StadiumId { get; set; }
    public int[]? Sections { get; set; }
}