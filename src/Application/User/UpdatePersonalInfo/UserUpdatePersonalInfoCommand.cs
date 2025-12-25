
namespace brk.Todo.Application.User.UpdatePersonalInfo;


public class UserUpdatePersonalInfoCommand: ICommand
{
    public string Name { get; set; }
    public string Family { get; set; }
}