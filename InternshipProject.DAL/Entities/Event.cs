﻿namespace InternshipProject.DAL.Entities;

public class Event
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int EventDuration { get; set; }
    public DateTime EventDate { get; set; }
    public int BookingPeriodDays { get; set; }
    public Hall? EventHall { get; set; }
    public int HallId { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    public List<Ticket>? EventTickets { get; set; }
}