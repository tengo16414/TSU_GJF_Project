using GJF.BLL.Abstract;
using GJF.Domain.Entities;
using GJF.Domain.Models.User;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.BLL.Helpers.Security
{
    public class SignInManager : ISignInManager
    {
        private readonly IUserBll _userBll;
        public SignInManager(IUserBll userBll)
        {
            _userBll = userBll;
        }

        public bool ChangePassword(ChangePasswordModel model, string username)
        {
            var user = _userBll.GetSingle(u => u.UserName == username);

            if (user == null)
                return false;

            var hasher = new PasswordHasher();

            if (hasher.VerifyHashedPassword(user.PasswordHash, model.OldPassword) != PasswordVerificationResult.Success)
                return false;

            if (model.NewPassword == model.ConfirmPassword)
            {
                user.PasswordHash = hasher.HashPassword(model.NewPassword);
                _userBll.Update(user);

                return true;
            }

            return false;
        }

        public bool LogIn(string username, string password, out User user)
        {
            username = username.ToLower();
            var entity = _userBll.GetSingle(u => u.UserName == username, u => u.UserRoles.Select(r => r.Role));
            user = entity;

            if (entity == null)
                return false;

            var result = new PasswordHasher().VerifyHashedPassword(entity.PasswordHash, password) == PasswordVerificationResult.Success;
            return result;
        }
    }
}
