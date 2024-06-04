using BigonWebApp.Data.EFconfigurations;
using BigonWebApp.Infrastructure.Commons;
using BigonWebApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonWebApp.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt) : base(opt) { }
        public DbSet<Color> Colors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColorCongiguration).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in datas)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        item.Entity.EditedDate = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        item.State = EntityState.Modified;
                        item.Entity.DeletedDate = DateTime.Now; 
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
