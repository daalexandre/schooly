using MediatR;
using Schooly.Models;

namespace Schooly.Domain.Queries
{
    public record GetEducationHistoryQuery : IRequest<List<EducationHistory>>;
}
