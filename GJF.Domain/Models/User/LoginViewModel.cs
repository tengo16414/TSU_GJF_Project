using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GJF.Domain.Models.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("მომხმარებელი")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DataType(DataType.Password)]
        [DisplayName("პაროლი")]
        public string Password { get; set; }

        [DisplayName("პაროლის დამახსოვრება")]
        public bool RememberMe { get; set; }

        public string Url { get; set; }
    }
}
