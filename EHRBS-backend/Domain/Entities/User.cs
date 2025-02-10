using System.ComponentModel.DataAnnotations;
using EHRBS_backend.Domain.Enums;

namespace EHRBS_backend.Domain.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public required string FullName { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string PasswordHash { get; set; }
    [Required]
    public UserRole Role { get; set; } = UserRole.User;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
