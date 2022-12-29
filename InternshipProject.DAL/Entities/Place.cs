using System.Collections.Specialized;

namespace InternshipProject.DAL.Entities;

internal class Place
{
    internal int Id { get; set; }
    internal PlaceType Type { get; set; }
    internal Section Section { get; set; }
    internal int SectionId { get; set; }
    internal List<Ticket>? Tickets { get; set; }
}