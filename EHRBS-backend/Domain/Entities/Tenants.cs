using System.ComponentModel.DataAnnotations;

namespace EHRBS_backend.Domain.Entities
{
    public class Tenants
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Users> Users { get; set; }
        public ICollection<Doctors> Doctors { get; set; } = new List<Doctors>();
        public ICollection<Patients> Patients { get; set; } = new List<Patients>();
        public ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();
        public ICollection<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();
        public ICollection<AuditLogs> AuditLogs { get; set; } = new List<AuditLogs>();
        public ICollection<Billings> Billings { get; set; } = new List<Billings>();

    }
}
