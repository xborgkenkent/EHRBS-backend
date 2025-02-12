using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHRBS_backend.Domain.Entities
{
    public class Patients
    {
        [Key]
        public Guid Id { get; set; }
        public string MedicalRecordNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public string EmergencyContact { get; set; }
        public string InsuranceProvider { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("TenantId")]
        public Tenants Tenants { get; set; }
    }
}
