using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Runner;

namespace SpaceBattle.Handlers
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
