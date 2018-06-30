using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GJF.DAL.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        int? Add(T entity);
        Task<int?> AddAsync(T entity);
        int? Update(T entity);
        Task<int?> UpdateAsync(T entity);
        List<T> GetAll(params Expression<Func<T, object>>[] expression);
        IQueryable<T> GetAllQuerable(params Expression<Func<T, object>>[] expression);
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] expression);
        T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] expression);
        T GetSingleWithLoad(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] expression);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] expression);
        List<T> GetRaws(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] expression);
        IQueryable<T> GetRawsQuerable(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] expression);
        Task<List<T>> GetRawsAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] expression);
        void Delete(int id);
        Task DeleteAsync(int id);
        void DeleteWhere(params Expression<Func<T, bool>>[] where);
        Task DeleteWhereAsync(params Expression<Func<T, bool>>[] where);
    }
}
