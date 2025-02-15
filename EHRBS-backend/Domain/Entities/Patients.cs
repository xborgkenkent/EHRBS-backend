using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHRBS_backend.Domain.Entities
{
    public class Patients
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TenantId { get; set; }
        public string MedicalRecordNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public string EmergencyContact { get; set; }
        public string InsuranceProvider { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();
        public ICollection<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();
        public ICollection<Billings> Billings { get; set; } = new List<Billings>();

    }
}
