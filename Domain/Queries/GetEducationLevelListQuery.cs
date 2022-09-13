using MediatR;
using Schooly.Enums;

namespace Schooly.Domain.Queries
{
    public record GetEducationLevelListQuery : IRequest<List<EducationLevel>>;
}
