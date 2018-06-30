using GJF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace GJF.Domain.Models.User
{
    public class UserEditModel
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
        [Remote("IsValidUserName", "Validator", AdditionalFields = "Id",ErrorMessage ="მომხმარებელი ასეთი სახელით უკვე არსებობს")]
        public string UserName { get; set; }

        [DisplayName("პაროლი")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("უფლება")]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("უფლება")]
        public ICollection<Entities.UserRole> UserRoles { get; set; } = new HashSet<Entities.UserRole>();
    }
}
