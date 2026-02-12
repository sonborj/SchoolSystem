using MediatR;
using SchoolSystem.Application.Common.Exceptions;
using SchoolSystem.Application.Common.Interfaces;
using SchoolSystem.Application.Common.Mappings;
using SchoolSystem.Application.Features.Students.DTOs;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Features.Students.Queries.GetStudentById;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
{
    private readonly IRepository<Student> _repository;

    public GetStudentByIdQueryHandler(IRepository<Student> repository)
    {
        _repository = repository;
    }

    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Student), request.Id);

        return student.ToDto();
    }
}
