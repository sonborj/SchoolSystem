using SchoolSystem.Domain.Enums;

namespace SchoolSystem.Application.Features.Teachers.DTOs;

public class CreateTeacherDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string Subject { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
}
