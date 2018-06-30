using GJF.DAL.Abstract;
using GJF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.DAL.Concrete
{
    public class UserRepository : GenericRepository<User, GJFDbContext>, IUserRepository
    {

        public new string Add(User entity)
        {
            entity.Id = Guid.NewGuid().ToString();

            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();

            return entity.Id;
        }

        public new string Update(User entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();

            return entity.Id;
        }

        public new async Task<string> AddAsync(User entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();

            return await Task.FromResult(entity.Id);
        }

        public new async Task<string> UpdateAsync(User entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return await Task.FromResult(entity.Id);
        }
    }

}
