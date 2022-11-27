using System.ComponentModel.DataAnnotations;

namespace InternshipProject.DAL.Entities;

public class Section
{
    [Key] public string Name { get; set; }

    public Hall? Hall { get; set; }
    public string HallName { get; set; }
}