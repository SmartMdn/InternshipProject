using System.Reflection;
using System.Runtime.CompilerServices;

namespace InternshipProject.DAL.Entities;

internal class Hall
{
    internal int Id { get; set; }
    internal string Name { get; set; }
    internal Stadium Stadium { get; set; }
    internal int StadiumId { get; set; }
    internal List<Event>? Events { get; set; }
    internal List<Section>? Sections { get; set; }
}