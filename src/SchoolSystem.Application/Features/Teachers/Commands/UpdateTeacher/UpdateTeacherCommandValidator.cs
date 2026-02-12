using FluentValidation;

namespace SchoolSystem.Application.Features.Teachers.Commands.UpdateTeacher;

public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
{
    public UpdateTeacherCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("A valid teacher ID is required.");

        RuleFor(x => x.Teacher.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Teacher.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Teacher.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.")
            .MaximumLength(200);

        RuleFor(x => x.Teacher.Subject)
            .NotEmpty().WithMessage("Subject is required.")
            .MaximumLength(100);

        RuleFor(x => x.Teacher.DateOfBirth)
            .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.");

        RuleFor(x => x.Teacher.HireDate)
            .NotEmpty().WithMessage("Hire date is required.");

        RuleFor(x => x.Teacher.Gender)
            .IsInEnum().WithMessage("Valid gender is required.");

        RuleFor(x => x.Teacher.Status)
            .IsInEnum().WithMessage("Valid status is required.");
    }
}
