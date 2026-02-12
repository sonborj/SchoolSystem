using MediatR;

namespace SchoolSystem.Application.Features.Teachers.Commands.DeleteTeacher;

public record DeleteTeacherCommand(int Id) : IRequest<Unit>;
