using MediatR;
using SchoolSystem.Application.Common.Interfaces;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IRepository<Student> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStudentCommandHandler(IRepository<Student> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            FirstName = request.Student.FirstName,
            LastName = request.Student.LastName,
            Email = request.Student.Email,
            PhoneNumber = request.Student.PhoneNumber,
            DateOfBirth = request.Student.DateOfBirth,
            EnrollmentDate = request.Student.EnrollmentDate,
            Grade = request.Student.Grade,
            Gender = request.Student.Gender,
            TeacherId = request.Student.TeacherId
        };

        await _repository.AddAsync(student, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return student.Id;
    }
}
