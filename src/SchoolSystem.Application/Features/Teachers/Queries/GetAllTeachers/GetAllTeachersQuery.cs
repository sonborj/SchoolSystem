using MediatR;
using SchoolSystem.Application.Features.Teachers.DTOs;

namespace SchoolSystem.Application.Features.Teachers.Queries.GetAllTeachers;

public record GetAllTeachersQuery : IRequest<IReadOnlyList<TeacherDto>>;
