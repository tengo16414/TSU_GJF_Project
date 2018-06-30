using GJF.BLL.Abstract;
using GJF.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GJF.BLL.Concrete
{
    public class GenericBll<T> : IGenericBll<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericBll(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public virtual int? Add(T entitie)
        {
            return _genericRepository.Add(entitie);
        }

        public virtual async Task<int?> AddAsync(T entity)
        {
            return await _genericRepository.AddAsync(entity);
        }

        public virtual int? Update(T entitie)
        {
            return _genericRepository.Update(entitie);
        }

        public virtual async Task<int?> UpdateAsync(T entity)
        {
            return await _genericRepository.UpdateAsync(entity);
        }

        public virtual List<T> GetAll(params Expression<Func<T, object>>[] expression)
        {
            var list = _genericRepository.GetAll(expression).ToList();
            return list;
        }

        public virtual IQueryable<T> GetAllQueryable(params Expression<Func<T, object>>[] expression)
        {
            var querable = _genericRepository.GetAllQuerable(expression);
            return querable;
        }

        public virtual async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] expression)
        {
            return await _genericRepository.GetAllAsync(expression);
        }


        public virtual void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _genericRepository.DeleteAsync(id);
        }

        public virtual void DeleteWhere(params Expression<Func<T, bool>>[] @where)
        {
            _genericRepository.DeleteWhere(where);
        }

        public virtual async Task DeleteWhereAsync(params Expression<Func<T, bool>>[] @where)
        {
            await _genericRepository.DeleteWhereAsync(where);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] expression)
        {
            var item = _genericRepository.GetSingle(where, expression);
            return item;
        }

        public T GetSingleWithLoad(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] expression)
        {
            var item = _genericRepository.GetSingleWithLoad(where, expression);
            return item;
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] expression)
        {
            return await _genericRepository.GetSingleAsync(where, expression);
        }

        public virtual List<T> GetRaws(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] expression)
        {
            var items = _genericRepository.GetRaws(where, expression);
            return items;
        }

        public virtual IQueryable<T> GetRawsQueryable(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] expression)
        {
            var items = _genericRepository.GetRawsQuerable(where, expression);
            return items;
        }

        public virtual async Task<List<T>> GetRawsAsync(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] expression)
        {
            return await _genericRepository.GetRawsAsync(where, expression);
        }

    }
}
