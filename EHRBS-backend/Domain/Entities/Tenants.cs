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

        public ICollection<Doctors> Doctors { get; set; } = new List<Doctors>();
        public ICollection<Patients> Patients { get; set; } = new List<Patients>();
    }
}
