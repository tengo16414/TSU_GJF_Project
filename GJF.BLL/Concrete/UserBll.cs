using GJF.BLL.Abstract;
using GJF.Common.Extentions.Lambda;
using GJF.DAL.Abstract;
using GJF.Domain.Entities;
using GJF.Domain.Models.User;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GJF.BLL.Concrete
{
    public class UserBll : GenericBll<User>, IUserBll
    {

        private readonly IUserRoleBll _userRoleBll;
        private readonly IUserRepository _userRepository;
        public Expression<Func<User, bool>> Where { get; set; } = u => !u.IsDeleted;

        public UserBll(IGenericRepository<User> genericRepository, IUserRoleBll userRoleBll, IUserRepository userRepository) : base(genericRepository)
        {
            _userRoleBll = userRoleBll;
            _userRepository = userRepository;
        }

        //get all with deleted users
        //below is overrided functions wich only selects non deleted users
        public IQueryable<User> GetUsersQueryable(params Expression<Func<User, object>>[] includes)
        {
            return base.GetAllQueryable(includes);
        }

        public string AddUser(UserEditModel model)
        {

            using (var transaction = new TransactionScope())
            {
                model.UserName = model.UserName.ToLower();
                var entity = AutoMapper.Mapper.Map<User>(model);
                entity.Id = Guid.NewGuid().ToString();

                entity.PasswordHash = new PasswordHasher().HashPassword(model.PasswordHash);
                var id = Add(entity);

                _userRoleBll.Add(new UserRole() { UserId = id, RoleId = model.RoleId });



                transaction.Complete();
                return id;

            }
        }

        public string UpdateUser(UserEditModel model)
        {
            using (var scope = new TransactionScope())
            {
                var entity = GetSingle(u => u.Id == model.Id);

                entity.UserName = model.UserName;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                var id = Update(entity);

                var userRole = _userRoleBll.GetSingle(u => u.UserId == model.Id);
                if (model.RoleId != 0)
                {
                    if (userRole.RoleId != model.RoleId)
                    {
                        userRole.RoleId = model.RoleId;
                        _userRoleBll.Update(userRole);

                    }
                }



                scope.Complete();
                return id;
            }
        }

        public void DeleteUser(string id)
        {
            var userforDelete = GetSingle(t => t.Id == id);
            userforDelete.IsDeleted = true;
            Update(userforDelete);
        }

        public bool ResetPassword(string id)
        {
            var user = GetSingle(u => u.Id == id);

            user.PasswordHash = new PasswordHasher().HashPassword("123456");

            Update(user);

            return true;
        }

        #region base class hiding

        public new string Add(User entity)
        {
            return _userRepository.Add(entity);
        }

        public new async Task<string> AddAsync(User entity)
        {
            return await _userRepository.AddAsync(entity);
        }

        public new string Update(User entity)
        {
            return _userRepository.Update(entity);
        }

        public new async Task<string> UpdateAsync(User entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }
        #endregion

        #region base class overrides

        public override User GetSingle(Expression<Func<User, bool>> @where, params Expression<Func<User, object>>[] includes)
        {
            var newWhere = where.And(Where);
            return base.GetSingle(newWhere, includes);
        }

        public override List<User> GetRaws(Expression<Func<User, bool>> @where, params Expression<Func<User, object>>[] includes)
        {
            var newWhere = where.And(Where);
            return base.GetRaws(newWhere, includes);
        }

        public override IQueryable<User> GetRawsQueryable(Expression<Func<User, bool>> @where, params Expression<Func<User, object>>[] includes)
        {
            var newWhere = where.And(Where);
            return base.GetRawsQueryable(newWhere, includes);
        }

        public override List<User> GetAll(params Expression<Func<User, object>>[] includes)
        {
            return base.GetRaws(Where, includes);
        }

        public override IQueryable<User> GetAllQueryable(params Expression<Func<User, object>>[] includes)
        {
            return base.GetRawsQueryable(Where, includes);
        }

        #endregion
    }
}
