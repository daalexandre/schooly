using MediatR;
using Schooly.Core.Configuration;
using Schooly.Domain.Commands;
using Schooly.Models;

namespace Schooly.Domain.Handlers
{
    public class CreateStudentHandler: IRequestHandler<CreateStudentCommand, Student>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthdate = request.Birthdate,
                EducationLevelId = request.EducationLevelId,
                Email = request.Email
            };

            await _unitOfWork.Students.Add(student);
            await _unitOfWork.CompleteAsync();            

            return student;
        }
    }
}
