using MediatR;
using Schooly.Core.Configuration;
using Schooly.Domain.Queries;
using Schooly.Models;

namespace Schooly.Domain.Handlers
{
    public class GetStudentsListHandler: IRequestHandler<GetStudentsListQuery, List<Student>>
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentsListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Student>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            return  (await _unitOfWork.Students.All()).ToList();
        }
    }
}
