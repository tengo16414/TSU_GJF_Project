using GJF.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GJF.Domain.Models.User
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [StringLength(100)]
        [DisplayName("სახელი")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [StringLength(100)]
        [DisplayName("გვარი")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [StringLength(100)]
        [DisplayName("მომხმარებელი")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("პაროლი")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        public bool IsDeleted { get; set; }

        public Role Role;

        [DisplayName("უფლება")]
        public int RoleId { get; set; }

        [DisplayName("უფლება")]
        public ICollection<Entities.UserRole> UserRoles { get; set; } = new HashSet<Entities.UserRole>();
    }
}
