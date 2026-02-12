using MediatR;
using SchoolSystem.Application.Common.Interfaces;
using SchoolSystem.Application.Common.Mappings;
using SchoolSystem.Application.Features.Students.DTOs;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Features.Students.Queries.GetAllStudents;

public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IReadOnlyList<StudentDto>>
{
    private readonly IRepository<Student> _repository;

    public GetAllStudentsQueryHandler(IRepository<Student> repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _repository.GetAllAsync(cancellationToken);
        return students.Select(s => s.ToDto()).ToList().AsReadOnly();
    }
}
