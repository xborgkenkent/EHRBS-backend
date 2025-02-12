using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EHRBS_backend.Domain.Entities
{
    public class Admins
    {
        [Key]
        public Guid Id { get; set; }
        
    }

    [Owned]
    public class Permissions
    {
        //to be created
    }
}
