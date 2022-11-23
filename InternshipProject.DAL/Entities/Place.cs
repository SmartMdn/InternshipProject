namespace InternshipProject.DAL.Entities;

public enum PlaceType
{
    IsSitting,
    IsStanding,
    IsRecumbent
}

public class Place
{
    public int Id { get; set; }
    public PlaceType Type { get; set; }
}