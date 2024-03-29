﻿using System.ComponentModel.DataAnnotations;

namespace InternshipProject.DAL.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Event>? Events { get; set; }
    }
}
