﻿namespace InternshipProject.BLL.DTO;

public class StadiumDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Address { get; set; }
    public int[]? Halls { get; set; }
}