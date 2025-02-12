using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EHRBS_backend.Domain.Entities
{
    public class Doctors
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Specialty { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        [Required]
        public Guid ClinicId { get; set; }
        public decimal ConsultationFee { get; set; }
        public Availability Availability { get; set; }
        public int ExperienceYears { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("TenantId")]
        public Tenants Tenants { get; set; }
    }

    [Owned] // Marks this as a JSON-owned entity in EF Core
    public class Availability
    {
        public string Days { get; set; } // e.g., "Monday, Tuesday"
        public string StartTime { get; set; } // e.g., "08:00 AM"
        public string EndTime { get; set; } // e.g., "05:00 PM"
    }
}
