using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EHRBS_backend.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EHRBS_backend.Domain.Entities
{
    public class MedicalRecords
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid TenantId { get; set; }
        public RecordType RecordType {  get; set; }
        public string EncryptedData { get; set; }
        public string EncryptionKey { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<AuditLogs> AuditLogs { get; set; } = new List<AuditLogs>();
    }
}
