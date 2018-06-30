using GJF.Domain.Entities;
using GJF.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GJF.BLL.Abstract
{
    public interface IUserBll : IGenericBll<User>
    {
        Expression<Func<User, bool>> Where { get; set; }
        string AddUser(UserEditModel model);
        string UpdateUser(UserEditModel model);
        void DeleteUser(string id);
        bool ResetPassword(string id);
        IQueryable<User> GetUsersQueryable(params Expression<Func<User, object>>[] includes);

        #region hiding parent interface methods
        new string Add(User entity);
        new Task<string> AddAsync(User entity);
        new string Update(User entity);
        new Task<string> UpdateAsync(User entity);
        #endregion
    }
}
