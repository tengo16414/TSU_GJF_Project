using GJF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.DAL.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        new string Add(User entity);
        new string Update(User entity);
        new Task<string> AddAsync(User entity);
        new Task<string> UpdateAsync(User entity);
    }
}
