using MediatR;
using SchoolSystem.Application.Common.Interfaces;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Features.Teachers.Commands.CreateTeacher;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
{
    private readonly IRepository<Teacher> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTeacherCommandHandler(IRepository<Teacher> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = new Teacher
        {
            FirstName = request.Teacher.FirstName,
            LastName = request.Teacher.LastName,
            Email = request.Teacher.Email,
            PhoneNumber = request.Teacher.PhoneNumber,
            Subject = request.Teacher.Subject,
            Gender = request.Teacher.Gender,
            DateOfBirth = request.Teacher.DateOfBirth,
            HireDate = request.Teacher.HireDate
        };

        await _repository.AddAsync(teacher, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return teacher.Id;
    }
}
