﻿namespace InternshipProject.BLL.DTO
{
    internal class CategoryDTO : BaseDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int[]? Events { get; set; }
    }
}
