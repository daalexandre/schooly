using Microsoft.EntityFrameworkCore;
using Schooly.Core.IRepositories;
using Schooly.Data;

namespace Schooly.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected readonly ILogger _logger;
        protected DbSet<T> dbSet;

        public GenericRepository(
            ApplicationDbContext context,
            ILogger logger
        )
        {
            _context = context;
            _logger = logger;
            dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            var resulst = await dbSet.AddAsync(entity);
            return true;
        }

#pragma warning disable CS1998 // O método assíncrono não possui operadores 'await' e será executado de forma síncrona
        public virtual async Task<bool> Delete(int id)
#pragma warning restore CS1998 // O método assíncrono não possui operadores 'await' e será executado de forma síncrona
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS1998 // O método assíncrono não possui operadores 'await' e será executado de forma síncrona
        public virtual async Task<bool> UpdateInsert(T entity)
#pragma warning restore CS1998 // O método assíncrono não possui operadores 'await' e será executado de forma síncrona
        {
            throw new NotImplementedException();
        }
    }
}
