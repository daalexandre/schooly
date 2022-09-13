using Schooly.Core.Configuration;
using Schooly.Core.IRepositories;
using Schooly.Core.Repositories;

namespace Schooly.Data
{
    public class UnitOfWork: IUnitOfWork, System.IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IStudentsRepository Students { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Students = new StudentsRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
