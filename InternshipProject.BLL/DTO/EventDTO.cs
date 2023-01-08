namespace InternshipProject.BLL.DTO;

public class EventDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int EventDuration { get; set; }
    internal DateTime EventDate { get; set; }
    public int BookingPeriodDays { get; set; }
    public int HallId { get; set; }
}