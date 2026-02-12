using MediatR;
using SchoolSystem.Application.Common.Exceptions;
using SchoolSystem.Application.Common.Interfaces;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Features.Teachers.Commands.UpdateTeacher;

public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, Unit>
{
    private readonly IRepository<Teacher> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTeacherCommandHandler(IRepository<Teacher> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Teacher), request.Id);

        teacher.FirstName = request.Teacher.FirstName;
        teacher.LastName = request.Teacher.LastName;
        teacher.Email = request.Teacher.Email;
        teacher.PhoneNumber = request.Teacher.PhoneNumber;
        teacher.Subject = request.Teacher.Subject;
        teacher.Gender = request.Teacher.Gender;
        teacher.DateOfBirth = request.Teacher.DateOfBirth;
        teacher.HireDate = request.Teacher.HireDate;
        teacher.Status = request.Teacher.Status;

        _repository.Update(teacher);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
