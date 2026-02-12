using MediatR;
using SchoolSystem.Application.Features.Students.DTOs;

namespace SchoolSystem.Application.Features.Students.Commands.UpdateStudent;

public record UpdateStudentCommand(int Id, UpdateStudentDto Student) : IRequest<Unit>;
