using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHRBS_backend.Domain.Entities
{
    public class Messages
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string EncryptedMessage { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
