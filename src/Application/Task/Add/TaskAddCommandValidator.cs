using FluentValidation;

namespace brk.Todo.Application.Task.Add;

public class TaskAddCommandValidator:AbstractValidator<TaskAddCommand>
{
    public TaskAddCommandValidator()
    {
        RuleFor(m=>m.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title is required");
    }
}
