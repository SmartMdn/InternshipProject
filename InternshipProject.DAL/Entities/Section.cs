using System.ComponentModel.DataAnnotations;

namespace InternshipProject.DAL.Entities;

public class Section
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Hall>? Halls { get; set; }
    public List<Place>? Places { get; set; }
}