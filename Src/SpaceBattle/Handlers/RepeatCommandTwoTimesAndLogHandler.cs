using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Commands.Сomposite;
using SpaceBattle.Runner;

namespace SpaceBattle.Handlers
{
    public class RepeatCommandTwoTimesAndLogHandler : IExceptionHandler
    {
        public ICommandsRunner commandsRunner;

        public RepeatCommandTwoTimesAndLogHandler()
        {
            this.commandsRunner = new CommandsRunner();
        }

        public void Handle(ICommand command, Exception exception)
        {
            if (command is RepeatTwoTimesCommand repeatTwoTimesCommand)
            {
                this.commandsRunner.AddCommandToTheQueue(repeatTwoTimesCommand.timesToRepeat >= 2
                        ? new LogExceptionCommand(command, exception)
                        : new RepeatTwoTimesCommand(command, repeatTwoTimesCommand.timesToRepeat++));
            }
            else
            {
                commandsRunner.AddCommandToTheQueue(new RepeatTwoTimesCommand(command));
            }
        }
    }
}
