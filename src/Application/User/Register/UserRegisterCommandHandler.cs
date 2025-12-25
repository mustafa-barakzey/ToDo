using brk.Todo.Domain.User.Data;
using brk.Todo.Domain.User.Entities;

namespace brk.Todo.Application.User.Register;

public class UserRegisterCommandHandler(IUserCommandRepository userCommandRepository) : ICommandHandler<UserRegisterCommand>
{
    public async Task<CommandResponse> HandleAsync(UserRegisterCommand command)
    {
        // check email is exist
        if(await userCommandRepository.IsEmailAlreadyExistAsync(command.Email))
            return CommandResponse.Faild($"This email is already registered.");

        var user = UserModel.Register(command.Email,command.Password);

        await userCommandRepository.AddAsync(user);

        return CommandResponse.Success();
    }
}