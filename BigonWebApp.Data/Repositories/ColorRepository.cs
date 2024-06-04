using BigonWebApp.Data.Contexts;
using BigonWebApp.Data.Repository;
using BigonWebApp.Infrastructure.Entities;
using BigonWebApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonWebApp.Data.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
