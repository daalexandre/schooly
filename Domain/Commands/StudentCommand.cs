using MediatR;
using Schooly.Models;

namespace Schooly.Domain.Commands
{
    public class StudentCommand : IRequest<Student>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int? EducationLevelId { get; set; }
        public int EducationHistoryId { get; set; }
    }

}
