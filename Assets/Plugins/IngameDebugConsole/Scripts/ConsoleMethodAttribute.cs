using System;

namespace IngameDebugConsole
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class ConsoleMethodAttribute : Attribute
    {
        public ConsoleMethodAttribute(string command, string description)
        {
            Command = command;
            Description = description;
        }

        public string Command { get; }

        public string Description { get; }
    }
}