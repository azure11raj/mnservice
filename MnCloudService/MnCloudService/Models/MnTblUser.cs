using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MnCloudService.Models;

public partial class MnTblUser
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public string? Mobile { get; set; }

    public string? UserPassword { get; set; }

    public string? Message { get; set; }

    public DateTime? Createddatetime { get; set; }

    public DateTime? Updateddatetime { get; set; }
}

public class Login
{
    [Required]
    public required string Mobile { get; set; }
    [Required]
    public required string Password { get; set; }
}
