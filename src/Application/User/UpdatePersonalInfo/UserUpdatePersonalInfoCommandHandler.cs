
using brk.Todo.Domain.User.Data;

namespace brk.Todo.Application.User.UpdatePersonalInfo;


public class UserUpdatePersonalInfoCommandHandler(ICurrentUser currentUser,IUserCommandRepository userCommandRepository) : ICommandHandler<UserUpdatePersonalInfoCommand>
{
    public async Task<CommandResponse> HandleAsync(UserUpdatePersonalInfoCommand command)
    {
        var userId = currentUser.GetUserId();

        // find current user 
        var user = await userCommandRepository.GetByIdAsync(userId);
        if(user is null)
            return CommandResponse.Faild("User not found");

        user.Update(command.Name,command.Family);

        await userCommandRepository.UpdateAsync(user);

        return CommandResponse.Success("Personal info updated");
    }
}
