using BigonWebApp.Infrastructure.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BigonWebApp.Infrastructure.Repository
{
    public interface IRepository<T>
        where T : BaseEntity
    {

        DbSet<T> Table { get; }

        //Write
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteAsync(string id);

        //Read

        IEnumerable<T> GetAll();

        IEnumerable<T> GetWhere(Expression<Func<T,bool>> expression);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression);

        Task<T> GetByIdAsync(string id);

        Task<int> SaveAsync();
        int Save();
        
    }
}
