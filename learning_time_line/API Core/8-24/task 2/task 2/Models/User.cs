using System;
using System.Collections.Generic;

namespace task_2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? CartId { get; set; }

    public byte[]? Salt { get; set; }

    public byte[]? HashedPassword { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
