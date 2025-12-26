using FluentValidation;

namespace brk.Todo.Application.User.Login;

public class UserLoginQueryValidator:AbstractValidator<UserLoginQuery>
{
    public UserLoginQueryValidator()
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
