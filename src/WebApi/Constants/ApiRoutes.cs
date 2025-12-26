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
    public static class Task
    {
        private const string BasePath = "Task";
        public const string Add = $"{BasePath}/Add";
        public const string Tag = BasePath;
    }
}
