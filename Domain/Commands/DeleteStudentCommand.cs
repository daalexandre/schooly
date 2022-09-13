using MediatR;
using Schooly.Models;

namespace Schooly.Domain.Commands
{    
    public record DeleteStudentCommand(int Id) : IRequest<bool>;

}
