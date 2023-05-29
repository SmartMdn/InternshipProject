namespace InternshipProject.BLL.DTO;

internal class SectionDTO : BaseDTO
{
    public string? Name { get; set; }
    public int HallId { get; set; }
    public int[]? Places { get; set; }
}