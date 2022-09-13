using MediatR;
using Schooly.Models;
using Schooly.Domain.Queries;

namespace Schooly.Domain.Handlers
{    
    public class GetEducationHistoryHandler : IRequestHandler<GetEducationHistoryQuery, List<EducationHistory>>
    {
        public Task<List<EducationHistory>> Handle(GetEducationHistoryQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<EducationHistory>());
        }
    }
}
