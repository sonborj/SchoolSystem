using MediatR;
using SchoolSystem.Application.Features.Teachers.DTOs;

namespace SchoolSystem.Application.Features.Teachers.Commands.UpdateTeacher;

public record UpdateTeacherCommand(int Id, UpdateTeacherDto Teacher) : IRequest<Unit>;
