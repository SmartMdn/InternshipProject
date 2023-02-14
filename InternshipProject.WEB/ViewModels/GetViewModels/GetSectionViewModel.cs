namespace InternshipProject.WEB.ViewModels.GetViewModels;

public class GetSectionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int[]? Halls { get; set; }
    public int[]? Places { get; set; }
}