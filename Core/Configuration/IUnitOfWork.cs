using Schooly.Core.IRepositories;

namespace Schooly.Core.Configuration
{
    public interface IUnitOfWork
    {
        IStudentsRepository Students { get; }
        Task CompleteAsync();
    }
}
