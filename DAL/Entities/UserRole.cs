using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeAPI.DAL.Entities
{
    [PrimaryKey(nameof(UserId),nameof(RoleId))]
    public class UserRole
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(Role))]
        public Guid RoleId { get; set; }    

        public Role Role_ { get; set; }  
        public User User_ { get; set;  }
        
    }
}
