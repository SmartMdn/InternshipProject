using InternshipProject.DAL.Enums;

namespace InternshipProject.BLL.DTO;

public class PlaceDTO
{
    public int Id { get; set; }
    public PlaceType Type { get; set; }
    public int SectionId { get; set; }
}