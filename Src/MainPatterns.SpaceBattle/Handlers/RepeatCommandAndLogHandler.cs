using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Commands.Simple;
using MainPatterns.SpaceBattle.Runner;

namespace MainPatterns.SpaceBattle.Handlers
{
    public class RepeatCommandAndLogHandler : IExceptionHandler
    {
        public readonly ICommandsRunner commandsRunner;

        public RepeatCommandAndLogHandler()
        {
            this.commandsRunner = new CommandsRunner();
        }

        public void Handle(ICommand command, Exception exception)
        {
            this.commandsRunner.AddCommandToTheQueue(command.GetType() == typeof(RepeatCommand)
                ? new LogExceptionCommand(command, exception)
                : new RepeatCommand(command));
        }
    }
}
