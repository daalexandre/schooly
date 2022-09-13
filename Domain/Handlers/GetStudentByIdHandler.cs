using MediatR;
using Schooly.Core.Configuration;
using Schooly.Domain.Queries;
using Schooly.Models;

namespace Schooly.Domain.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetStudentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.Students.GetById(request.Id));
        }
    }
}
