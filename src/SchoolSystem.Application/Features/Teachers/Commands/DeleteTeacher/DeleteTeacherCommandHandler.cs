using MediatR;
using SchoolSystem.Application.Common.Exceptions;
using SchoolSystem.Application.Common.Interfaces;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Features.Teachers.Commands.DeleteTeacher;

public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, Unit>
{
    private readonly IRepository<Teacher> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTeacherCommandHandler(IRepository<Teacher> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Teacher), request.Id);

        _repository.Delete(teacher);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
