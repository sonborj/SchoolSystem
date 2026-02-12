using MediatR;
using SchoolSystem.Application.Features.Teachers.DTOs;

namespace SchoolSystem.Application.Features.Teachers.Commands.CreateTeacher;

public record CreateTeacherCommand(CreateTeacherDto Teacher) : IRequest<int>;
