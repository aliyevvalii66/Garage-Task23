using BigonWebApp.Data.Contexts;
using BigonWebApp.Infrastructure.Commons;
using BigonWebApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace BigonWebApp.Data.Repository
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get => _context.Set<T>(); }
        public async Task<bool> AddAsync(T entity)
        {
            var result = await Table.AddAsync(entity);
            return result.State == EntityState.Added;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            var data = await Table.FirstOrDefaultAsync(x=>x.Id == entity.Id);
            if (data == null) 
                return false;

            data.IsDeleted = true;
            var result = Table.Remove(entity);
            return result.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var data =await Table.FindAsync(id);
            if (data == null)
                return false;

            data.IsDeleted = true;
            var result = Table.Remove(data);
            return result.State == EntityState.Deleted;
        }
        public bool Update(T entity)
        {
            var result = Table.Update(entity);
            entity.EditedDate = DateTime.Now;
            return result.State == EntityState.Modified;
        }


        public IEnumerable<T> GetAll()
        {
           return Table.AsEnumerable();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(x=>x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.FirstOrDefaultAsync(expression);
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return Table.Where(expression);
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        
    }
}
