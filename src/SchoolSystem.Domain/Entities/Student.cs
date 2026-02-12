using SchoolSystem.Domain.Common;
using SchoolSystem.Domain.Enums;

namespace SchoolSystem.Domain.Entities;

public class Student : BaseAuditableEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Grade { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public StudentStatus Status { get; set; } = StudentStatus.Active;

    public int? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
}
