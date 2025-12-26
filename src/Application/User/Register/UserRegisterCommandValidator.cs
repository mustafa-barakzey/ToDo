using FluentValidation;

namespace brk.Todo.Application.User.Register;

public class UserRegisterCommandValidator: AbstractValidator<UserRegisterCommand>
{
    public UserRegisterCommandValidator()
    {
        RuleFor(m=>m.Email)
        .EmailAddress()
        .NotEmpty()
        .WithMessage("Email is required");

        RuleFor(m=>m.Password)
        .NotEmpty()
        .WithMessage("Password is required");
    }
}
