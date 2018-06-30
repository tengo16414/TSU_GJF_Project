using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GJF.Domain.Models.User
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DataType(DataType.Password)]
        [Display(Name = "მიმდინარე პაროლი")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DataType(DataType.Password)]
        [Display(Name = "ახალი პაროლი")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "გაიმეორეთ ახალი პაროლი")]
        [Compare("NewPassword", ErrorMessage = "პაროლები არ ემთხვევა.")]
        public string ConfirmPassword { get; set; }
    }
}
