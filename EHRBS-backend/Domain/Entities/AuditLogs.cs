using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHRBS_backend.Domain.Entities
{
    public class AuditLogs
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MedicalRecordId { get; set; }
        public Guid TenantId { get; set; }
        public string Action { get; set; }
        public string TableAffected { get; set; }
        public DateTime CreatedAt { get; set; }

        //[ForeignKey("UserId")]
        //public Users Users { get; set; }
        //[ForeignKey("RecordId")]
        //public MedicalRecords MedicalRecords { get; set; }
        //[ForeignKey("TenantId")]
        //public Tenants Tenants { get; set; }
    }
}
