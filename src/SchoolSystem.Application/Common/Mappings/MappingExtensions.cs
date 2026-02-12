using SchoolSystem.Application.Features.Teachers.DTOs;
using SchoolSystem.Application.Features.Students.DTOs;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Common.Mappings;

public static class MappingExtensions
{
    public static TeacherDto ToDto(this Teacher teacher) => new()
    {
        Id = teacher.Id,
        FirstName = teacher.FirstName,
        LastName = teacher.LastName,
        Email = teacher.Email,
        PhoneNumber = teacher.PhoneNumber,
        Subject = teacher.Subject,
        Gender = teacher.Gender,
        DateOfBirth = teacher.DateOfBirth,
        HireDate = teacher.HireDate,
        Status = teacher.Status,
        CreatedAt = teacher.CreatedAt
    };

    public static StudentDto ToDto(this Student student) => new()
    {
        Id = student.Id,
        FirstName = student.FirstName,
        LastName = student.LastName,
        Email = student.Email,
        PhoneNumber = student.PhoneNumber,
        DateOfBirth = student.DateOfBirth,
        EnrollmentDate = student.EnrollmentDate,
        Grade = student.Grade,
        Gender = student.Gender,
        Status = student.Status,
        TeacherId = student.TeacherId,
        TeacherName = student.Teacher != null
            ? $"{student.Teacher.FirstName} {student.Teacher.LastName}"
            : null,
        CreatedAt = student.CreatedAt
    };
}
