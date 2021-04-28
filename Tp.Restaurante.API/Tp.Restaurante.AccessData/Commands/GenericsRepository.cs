using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.Commands;

namespace Tp.Restaurante.AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository 
    {
        private readonly RestauranteDbContext _context;
        public GenericsRepository (RestauranteDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }
}
