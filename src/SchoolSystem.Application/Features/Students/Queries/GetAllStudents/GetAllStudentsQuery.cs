using MediatR;
using SchoolSystem.Application.Features.Students.DTOs;

namespace SchoolSystem.Application.Features.Students.Queries.GetAllStudents;

public record GetAllStudentsQuery : IRequest<IReadOnlyList<StudentDto>>;
