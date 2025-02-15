using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EHRBS_backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EHRBS_backend.Domain.Entities
{
    public class Appointments
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid TenantId { get; set; }
        public DateTime ScheduledAt { get; set; }
        public AppointmentStatus Status { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        //[ForeignKey("DoctorId")]
        //public Doctors Doctors { get; set; }
        //[ForeignKey("PatientId")]
        //public Patients Patients { get; set; }
        //[ForeignKey("TenantId")]
        //public Tenants Tenants { get; set; }

    }
}
