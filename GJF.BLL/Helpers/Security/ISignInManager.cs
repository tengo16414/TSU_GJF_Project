using GJF.Domain.Entities;
using GJF.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.BLL.Helpers.Security
{
   public interface ISignInManager
    {
        bool LogIn(string username, string password, out User user);

        bool ChangePassword(ChangePasswordModel model, string username);
    }
}
