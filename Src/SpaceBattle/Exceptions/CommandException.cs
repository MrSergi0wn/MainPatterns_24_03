using SpaceBattle.Commands;

namespace SpaceBattle.Exceptions
{
    public class CommandException : Exception
    {
        public readonly ICommand Command;

        public readonly Exception? Exception;

        public CommandException(ICommand command)
        {
            Command = command;
        }

        public CommandException(ICommand command, Exception exception)
        {
            Command = command;
            Exception = exception;
        }
    }
}
