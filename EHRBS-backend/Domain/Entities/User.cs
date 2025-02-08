﻿namespace EHRBS_backend.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }  // ✅ Add this
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
