using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EHRBS_backend.Domain.Enums;

namespace EHRBS_backend.Domain.Entities;

public class Users
{
    [Key]
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    [Required]
    public required string FullName { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string PasswordHash { get; set; }
    [Required]
    public UserRole Role { get; set; } = UserRole.User;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Doctors> Doctors { get; set; } = new List<Doctors>();
    public ICollection<Patients> Patients { get; set; } = new List<Patients>();
    public ICollection<AuditLogs> AuditLogs { get; set; } = new List<AuditLogs>();
}
