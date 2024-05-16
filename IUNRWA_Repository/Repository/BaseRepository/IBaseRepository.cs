using IUNRWA_Model;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Repository.Repository.BaseRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll(int pageSize = 0, int pageNumber = 0);
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression, int pageSize = 0, int pageNumber = 0);
        Task<T> GetById(int id);
        Task<T> GetById(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        Task<bool> CheckExist(Expression<Func<T, bool>> expression);
        Task AddRange(List<T> obj);
        public Task Update(T obj);
        Task Remove(int id);
        Task Remove(List<T> obj);
        Task Remove(Expression<Func<T, bool>> expression);
        Task SaveChanges();
    }
    
}
