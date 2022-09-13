using MediatR;
using Schooly.Models;

namespace Schooly.Domain.Queries
{
    public record GetStudentsListQuery : IRequest<List<Student>>;
}
