using System.Collections.Specialized;
using InternshipProject.DAL.Enums;

namespace InternshipProject.DAL.Entities;

internal class Place
{
    public int Id { get; set; }
    public PlaceType Type { get; set; }
    public Section Section { get; set; }
    public int SectionId { get; set; }
    public List<Ticket>? Tickets { get; set; }
}