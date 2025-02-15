using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EHRBS_backend.Domain.Enums;

namespace EHRBS_backend.Domain.Entities
{
    public class Billings
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PatienId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid TenantId { get; set; }

        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public BillingStatus Status { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        //[ForeignKey("PatientId")]
        //public Patients Patients { get; set; }
        //[ForeignKey("DoctorId")]
        //public Doctors Doctors { get; set; }
        //[ForeignKey("TenantId")]
        //public Tenants Tenants { get; set; }
    }
}
