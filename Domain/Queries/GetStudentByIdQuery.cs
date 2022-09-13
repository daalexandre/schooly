using MediatR;
using Schooly.Models;

namespace Schooly.Domain.Queries
{
    public record GetStudentByIdQuery(int Id) : IRequest<Student>;
}
