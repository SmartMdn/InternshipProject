namespace InternshipProject.BLL.DTO;

internal class TicketDTO : BaseDTO
{
    public int EventId { get; set; }
    public int PlaceId { get; set; }
    public bool IsBought { get; set; }
}