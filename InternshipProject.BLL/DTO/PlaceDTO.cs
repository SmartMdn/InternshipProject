using InternshipProject.DAL.Enums;

namespace InternshipProject.BLL.DTO;

internal class PlaceDTO : BaseDTO
{
    public PlaceType Type { get; set; }
    public int SectionId { get; set; }
}