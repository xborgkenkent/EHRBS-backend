﻿using System.ComponentModel.DataAnnotations;

namespace EHRBS_backend.Domain.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
