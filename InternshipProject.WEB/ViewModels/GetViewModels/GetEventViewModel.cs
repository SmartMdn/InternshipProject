namespace InternshipProject.WEB.ViewModels.GetViewModels;

public class GetEventViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int EventDuration { get; set; }
    public int BookingPeriodDays { get; set; }
    public int HallId { get; set; }
    public int CountOfPlaces { get; set; }
}