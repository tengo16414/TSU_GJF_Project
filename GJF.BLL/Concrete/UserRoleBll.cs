using GJF.BLL.Abstract;
using GJF.DAL.Abstract;
using GJF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.BLL.Concrete
{
    public class UserRoleBll : GenericBll<UserRole>, IUserRoleBll
    {
        public UserRoleBll(IGenericRepository<UserRole> genericRepository) : base(genericRepository)
        {
        }
    }
}
