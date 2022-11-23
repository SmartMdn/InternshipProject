using System.ComponentModel.DataAnnotations;

namespace InternshipProject.DAL.Entities;

public class Hall
{
    [Key]
    public string? Name { get; set; }
    public Stadium? Stadium { get; set; }
}