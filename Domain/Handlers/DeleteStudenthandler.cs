using MediatR;
using Schooly.Core.Configuration;
using Schooly.Data;
using Schooly.Domain.Commands;
using Schooly.Models;

namespace Schooly.Domain.Handlers
{

    
    public class DeleteStudenthandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStudenthandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            
            var deleted = await _unitOfWork.Students.Delete(request.Id);
            await _unitOfWork.CompleteAsync();

            return deleted;
        }
    }
}
