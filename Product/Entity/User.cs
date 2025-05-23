using System;
using System.Collections.Generic;

namespace Product.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}

public class UserDTO
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string RoleName { get; set; } = null!;
}
