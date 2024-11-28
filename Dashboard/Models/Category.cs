﻿using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models;

public class Category
{
    [Key] public int Id { get; set; }

    [MaxLength(100)] public string Name { get; set; }

    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}