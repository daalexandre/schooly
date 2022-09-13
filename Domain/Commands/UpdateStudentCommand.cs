using MediatR;
using Schooly.Models;

namespace Schooly.Domain.Commands
{
    public class UpdateStudentCommand : StudentCommand
    {
        public int Id { get; set; }
    }
}
