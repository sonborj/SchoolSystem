using MediatR;
using SchoolSystem.Application.Features.Students.DTOs;

namespace SchoolSystem.Application.Features.Students.Queries.GetStudentById;

public record GetStudentByIdQuery(int Id) : IRequest<StudentDto>;
