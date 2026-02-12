using FluentValidation;

namespace SchoolSystem.Application.Features.Students.Commands.UpdateStudent;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("A valid student ID is required.");

        RuleFor(x => x.Student.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Student.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Student.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.")
            .MaximumLength(200);

        RuleFor(x => x.Student.DateOfBirth)
            .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.");

        RuleFor(x => x.Student.EnrollmentDate)
            .NotEmpty().WithMessage("Enrollment date is required.");

        RuleFor(x => x.Student.Grade)
            .NotEmpty().WithMessage("Grade is required.")
            .MaximumLength(10);

        RuleFor(x => x.Student.Gender)
            .IsInEnum().WithMessage("Valid gender is required.");

        RuleFor(x => x.Student.Status)
            .IsInEnum().WithMessage("Valid status is required.");
    }
}
