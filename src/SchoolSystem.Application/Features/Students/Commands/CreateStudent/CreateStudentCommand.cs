using MediatR;
using SchoolSystem.Application.Features.Students.DTOs;

namespace SchoolSystem.Application.Features.Students.Commands.CreateStudent;

public record CreateStudentCommand(CreateStudentDto Student) : IRequest<int>;
