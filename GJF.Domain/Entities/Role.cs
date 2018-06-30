using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GJF.Domain.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        [System.ComponentModel.DisplayName("უფლება")]
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
