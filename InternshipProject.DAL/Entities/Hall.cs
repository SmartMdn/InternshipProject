using System.ComponentModel.DataAnnotations;

namespace InternshipProject.DAL.Entities;

public class Hall
{
    [Key] public string Name { get; set; }

    public Stadium? Stadium { get; set; }
    public int StadiumId { get; set; }
    
    public List<Event> Events { get; set; }
    public List<Place> Places { get; set; }
    public List<Section> Sections { get; set; }
}