using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHRBS_backend.Domain.Entities
{
    public class AuditLogs
    {
        [Key]
        public Guid Id { get; set; }
        public string Action { get; set; }
        public string TableAffected { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        
    }
}
