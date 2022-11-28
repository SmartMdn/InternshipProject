using System.ComponentModel.DataAnnotations;

namespace InternshipProject.DAL.Entities;

public class Hall
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Stadium>? Stadiums { get; set; }
    public List<Event>? Events { get; set; }
    public List<Section>? Sections { get; set; }
}