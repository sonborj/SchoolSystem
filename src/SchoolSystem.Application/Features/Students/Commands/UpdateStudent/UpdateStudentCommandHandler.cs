using MediatR;
using SchoolSystem.Application.Common.Exceptions;
using SchoolSystem.Application.Common.Interfaces;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Features.Students.Commands.UpdateStudent;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
{
    private readonly IRepository<Student> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStudentCommandHandler(IRepository<Student> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Student), request.Id);

        student.FirstName = request.Student.FirstName;
        student.LastName = request.Student.LastName;
        student.Email = request.Student.Email;
        student.PhoneNumber = request.Student.PhoneNumber;
        student.DateOfBirth = request.Student.DateOfBirth;
        student.EnrollmentDate = request.Student.EnrollmentDate;
        student.Grade = request.Student.Grade;
        student.Gender = request.Student.Gender;
        student.Status = request.Student.Status;
        student.TeacherId = request.Student.TeacherId;

        _repository.Update(student);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
