using IUNRWA_Model;
using IUNRWA_ShareKernal.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Repository.Repository.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext Context;
        private readonly DbSet<T> entity;
        public BaseRepository(AppDbContext context)
        {
            Context = context;
            entity = Context.Set<T>();
        }

        public async Task<T> Add(T obj)
        {
            try
            {
                await entity.AddAsync(obj);
                await Context.SaveChangesAsync();
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task AddRange(List<T> obj)
        {
            if (obj is null)
            {
                throw new ValidException(nameof(obj));
            }
            await entity.AddRangeAsync(obj);
            await Context.SaveChangesAsync();
        }



        public async Task<bool> CheckExist(Expression<Func<T, bool>> expression)
        {
            bool check = await entity.Where(e => e.IsVaild).AnyAsync(expression)!;
            return check;
        }
        public async Task<List<T>> GetAll(int pageSize = 0, int pageNumber = 0)
        {
            return pageSize is not 0 && pageNumber is not 0
                ? await entity.Where(e => e.IsVaild).Skip(pageNumber * pageSize).Take(pageSize).ToListAsync()
                : await entity.Where(e => e.IsVaild).ToListAsync();
        }
        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression, int pageSize = 0, int pageNumber = 0)
        {
            return pageSize is not 0 && pageNumber is not 0 ?
             await entity.Where(e => e.IsVaild).Where(expression).Skip(pageNumber * pageSize).Take(pageSize).ToListAsync() :
            await entity.Where(e => e.IsVaild).Where(expression).ToListAsync();
        }



        public async Task<T> GetById(int id)
        {
            try
            {
                T? obj = await entity.Where(e => e.IsVaild).SingleOrDefaultAsync(x => x.Id == id)!;
                return obj is null ? throw new NotFoundException($"{nameof(T)} Not Found") : obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<T> GetById(Expression<Func<T, bool>> expression)
        {
            T? obj = await entity.Where(e => e.IsVaild).SingleOrDefaultAsync(expression)!;
            return obj is null ? throw new NotFoundException("Not Found") : obj;
        }

        public async Task Remove(int id)
        {
            try
            {
                var obj = entity.Where(e => e.Id == id).SingleOrDefault();
                if (obj is null)
                {
                    throw new NotFoundException("Not Found");
                }
                Context.Remove(obj);
                await Context.SaveChangesAsync();
            }
            catch (Exception) { }
        }
        public async Task Remove(List<T> obj)
        {
            try
            {
                Context.RemoveRange(obj);
                await Context.SaveChangesAsync();
            }
            catch (Exception) { }
        }
        public async Task Remove(Expression<Func<T, bool>> expression)
        {
            var obj = entity.Where(expression).Where(e => e.IsVaild).ToList();
            if (obj is null || obj.Count == 0)
            {
            }
            else
                Context.RemoveRange(obj);
            await Context.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }
        #region Update
    
        public async Task Update(T obj)
        {
            entity.Update(obj);
            await Context.SaveChangesAsync();
        }
        
        #endregion
    }
}
