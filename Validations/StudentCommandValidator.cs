using FluentValidation;
using Schooly.Domain.Commands;

namespace Schooly.Validations
{
    public class StudentCommandValidator: AbstractValidator<StudentCommand>
    {
        public StudentCommandValidator()
        {
            RuleFor(student => student.Email).NotEmpty().EmailAddress();
            RuleFor(student => student.FirstName).NotEmpty();
            RuleFor(student => student.LastName).NotEmpty();
            RuleFor(student => student.Birthdate).NotEmpty().LessThan(DateTime.Now);
        }
    }
}
