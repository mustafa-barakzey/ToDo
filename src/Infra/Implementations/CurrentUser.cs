using System.Security.Claims;
using brk.Todo.Application.Shared.Contracts;
using Microsoft.AspNetCore.Http;

namespace brk.Todo.Infra.Implementations;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
{
    public int GetUserId()
    {
        var value = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(m=>m.Type == ClaimTypes.NameIdentifier)?.Value;
        if(int.TryParse(value, out var userId))
            return userId;
        return 0;
    }
}
