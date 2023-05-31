namespace InternshipProject.BLL.DTO;

public class EventDTO : BaseDTO
{
    public string? Name { get; set; }
    public int EventDuration { get; set; }
    internal DateTime EventDate { get; set; }
    public int BookingPeriodDays { get; set; }
    public int HallId { get; set; }
    public int CagegoryId { get; set; }
}