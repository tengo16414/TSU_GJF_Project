using GJF.DAL.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace GJF.DAL.Concrete
{
    public abstract class GenericRepository<T, K> : IGenericRepository<T> where T : class
        where K : DbContext
    {
            
        [Inject]
        public K Context { get; set; }

        public virtual int? Add(T entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();

            return (int)entity.GetType().GetProperty("Id").GetValue(entity);

        }

        public virtual async Task<int?> AddAsync(T entity)
        {

            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();

            return await Task.FromResult((int?)entity.GetType().GetProperty("Id").GetValue(entity));
        }

        public virtual int? Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return (int)entity.GetType().GetProperty("Id").GetValue(entity);
        }

        public virtual async Task<int?> UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            var taskResult = new TaskCompletionSource<int?>();
            taskResult.SetResult((int)entity.GetType().GetProperty("Id").GetValue(entity));

            return await taskResult.Task;

        }

        public virtual List<T> GetAll(params Expression<Func<T, object>>[] expression)
        {
            var set = Context.Set<T>();
            IQueryable<T> querable = set;
            foreach (var item in expression)
            {
                querable = querable.Include(item);
            }

            return querable.AsNoTracking().ToList();
        }

        public virtual IQueryable<T> GetAllQuerable(params Expression<Func<T, object>>[] expression)
        {
            var set = Context.Set<T>();
            IQueryable<T> querable = set;
            foreach (var item in expression)
            {
                querable = querable.Include(item);
            }

            return querable.AsNoTracking();
        }

        public virtual async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] expression)
        {
            var set = Context.Set<T>();
            IQueryable<T> querable = set;
            foreach (var item in expression)
            {
                querable = querable.Include(item);
            }
            return await querable.AsNoTracking().ToListAsync();
        }

        public virtual T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] expression)
        {
            var set = Context.Set<T>();
            IQueryable<T> querable = set.Where(where);

            foreach (var item in expression)
            {
                querable = querable.Include(item);
            }

            return (T)querable.AsNoTracking().FirstOrDefault();
        }

        public T GetSingleWithLoad(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] expression)
        {
            var set = Context.Set<T>();
            set.Load();
            IQueryable<T> querable = set.Where(where);

            foreach (var item in expression)
            {
                querable = querable.Include(item);
            }

            return (T)querable.AsNoTracking().FirstOrDefault();
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] expression)
        {
            var set = Context.Set<T>();
            IQueryable<T> querable = set.Where(where);

            foreach (var item in expression)
            {
                querable = querable.Include(item);
            }

            return await querable.AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual List<T> GetRaws(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] expression)
        {
            var set = Context.Set<T>();
            IQueryable<T> querable = set.Where(where);

            foreach (var item in expression)
            {
                querable = querable.Include(item);
            }

            return querable.AsNoTracking().ToList();
        }

        public virtual IQueryable<T> GetRawsQuerable(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] expression)
        {
            var set = Context.Set<T>();
            IQueryable<T> querable = set.Where(where);

            foreach (var item in expression)
            {
                querable = querable.Include(item);
            }

            return querable.AsNoTracking();
        }

        public virtual async Task<List<T>> GetRawsAsync(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] expression)
        {
            var set = Context.Set<T>();
            IQueryable<T> querable = set.Where(where);

            foreach (var item in expression)
            {
                querable = querable.Include(item);
            }

            return await querable.AsNoTracking().ToListAsync();
        }

        public virtual void Delete(int id)
        {
            Context.Set<T>().ToList().ForEach(m =>
            {
                if ((int)m.GetType().GetProperty("Id").GetValue(m) == id)
                {
                    Context.Entry(m).State = EntityState.Deleted;
                    Context.SaveChanges();
                }
            });
        }

        public virtual async Task DeleteAsync(int id)
        {
            var set = await Context.Set<T>().ToListAsync();

            set.ForEach(m =>
            {
                if ((int)m.GetType().GetProperty("Id").GetValue(m) == id)
                {
                    Context.Entry(m).State = EntityState.Deleted;
                    Context.SaveChangesAsync();
                }
            });
        }

        public virtual void DeleteWhere(params Expression<Func<T, bool>>[] @where)
        {
            var set = Context.Set<T>();
            IQueryable<T> querable = set;

            foreach (var item in where)
            {
                querable = querable.Where(item);
            }

            querable.ToList().ForEach(entity =>
            {
                Context.Entry(entity).State = EntityState.Deleted;
                Context.SaveChanges();
            });
        }

        public virtual async Task DeleteWhereAsync(params Expression<Func<T, bool>>[] @where)
        {
            var set = Context.Set<T>();
            IQueryable<T> querable = set;

            foreach (var item in where)
            {
                querable = querable.Where(item);
            }

            var list = await querable.ToListAsync();
            list.ForEach(entity =>
            {
                Context.Entry(entity).State = EntityState.Deleted;
                Context.SaveChangesAsync();
            });
        }

        private static Expression<Func<TItem, bool>> PropertyEquals<TItem, TValue>(PropertyInfo property, TValue value)
        {
            var param = Expression.Parameter(typeof(TItem));
            var body = Expression.Equal(Expression.Property(param, property), Expression.Constant(value));
            var expression = Expression.Lambda<Func<TItem, bool>>(body, param);
            return expression;
        }


        public void Dispose()
        {
            Context?.Dispose();
        }


    }
}
