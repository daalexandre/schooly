using MediatR;
using Schooly.Domain.Queries;
using Schooly.Enums;

namespace Schooly.Domain.Handlers
{
    public class GetEducationLevelListHandler : IRequestHandler<GetEducationLevelListQuery, List<EducationLevel>>
    {
        public Task<List<EducationLevel>> Handle(GetEducationLevelListQuery request, CancellationToken cancellationToken)
        {
           return Task.FromResult(new List<EducationLevel>());
        }
    }
}
