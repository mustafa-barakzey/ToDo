using System;

namespace brk.Todo.WebApi.Constants;

public static class ApiRoutes
{
    public static class Auth
    {
        private const string BasePath = "Auth";
        public const string Register = $"{BasePath}/Register";
        public const string Login = $"{BasePath}/Login";
        public const string Tag = BasePath;
    }
}
