using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Commands.Simple;
using MainPatterns.SpaceBattle.Commands.Сomposite;
using MainPatterns.SpaceBattle.Runner;

namespace MainPatterns.SpaceBattle.Handlers
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
