using System;
using System.Collections.Generic;

namespace task_2.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? CategoryId { get; set; }

    public string? ProductImage { get; set; }

    public virtual Category? Category { get; set; }
}

public partial class ProductDTO
{
 
    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }

 
    public string? ProductImage { get; set; }

 }

public partial class ProductDTO2
{

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }


    public IFormFile ProductImage { get; set; }

}
