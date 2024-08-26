﻿using System;
using System.Collections.Generic;

namespace task_2.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryImage { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}


public partial class CategoryDTO
{
 
    public string CategoryName { get; set; } = null!;

    public string? CategoryImage { get; set; }

 }