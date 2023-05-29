namespace InternshipProject.BLL.DTO;

public class StadiumDTO : BaseDTO
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int[]? Halls { get; set; }
}