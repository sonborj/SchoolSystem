using MediatR;
using SchoolSystem.Application.Common.Exceptions;
using SchoolSystem.Application.Common.Interfaces;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Features.Students.Commands.DeleteStudent;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
{
    private readonly IRepository<Student> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStudentCommandHandler(IRepository<Student> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Student), request.Id);

        _repository.Delete(student);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
