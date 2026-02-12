using MediatR;

namespace SchoolSystem.Application.Features.Students.Commands.DeleteStudent;

public record DeleteStudentCommand(int Id) : IRequest<Unit>;
