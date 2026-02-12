using MediatR;
using SchoolSystem.Application.Features.Teachers.DTOs;

namespace SchoolSystem.Application.Features.Teachers.Queries.GetTeacherById;

public record GetTeacherByIdQuery(int Id) : IRequest<TeacherDto>;
