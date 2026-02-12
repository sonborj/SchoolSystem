using MediatR;
using SchoolSystem.Application.Common.Interfaces;
using SchoolSystem.Application.Common.Mappings;
using SchoolSystem.Application.Features.Teachers.DTOs;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Features.Teachers.Queries.GetAllTeachers;

public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, IReadOnlyList<TeacherDto>>
{
    private readonly IRepository<Teacher> _repository;

    public GetAllTeachersQueryHandler(IRepository<Teacher> repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<TeacherDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
    {
        var teachers = await _repository.GetAllAsync(cancellationToken);
        return teachers.Select(t => t.ToDto()).ToList().AsReadOnly();
    }
}
