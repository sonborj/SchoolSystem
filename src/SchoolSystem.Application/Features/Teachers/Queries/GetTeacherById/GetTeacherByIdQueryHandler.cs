using MediatR;
using SchoolSystem.Application.Common.Exceptions;
using SchoolSystem.Application.Common.Interfaces;
using SchoolSystem.Application.Common.Mappings;
using SchoolSystem.Application.Features.Teachers.DTOs;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Features.Teachers.Queries.GetTeacherById;

public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDto>
{
    private readonly IRepository<Teacher> _repository;

    public GetTeacherByIdQueryHandler(IRepository<Teacher> repository)
    {
        _repository = repository;
    }

    public async Task<TeacherDto> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Teacher), request.Id);

        return teacher.ToDto();
    }
}
