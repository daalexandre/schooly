using MediatR;
using Schooly.Core.Configuration;
using Schooly.Domain.Commands;
using Schooly.Models;

namespace Schooly.Domain.Handlers
{
    public class UpdateStudentHandler: IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthdate = request.Birthdate,
                EducationLevelId = request.EducationLevelId,
                Email = request.Email
            };

            await _unitOfWork.Students.UpdateInsert(student);
            await _unitOfWork.CompleteAsync();

            return student;
        }
    }


}
