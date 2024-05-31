using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Commands.Simple;
using MainPatterns.SpaceBattle.Commands.Сomposite;
using MainPatterns.SpaceBattle.Runner;

namespace MainPatterns.SpaceBattle.UnitTests.CommandsTests
{
    public class RepeatTwoTimesCommandTests
    {
        [Fact]
        public void ExecuteReRepeatTwoTimesCommandTest()
        {
            ICommand? command = null;

            var logExceptionCommand = new LogExceptionCommand(new RepeatTwoTimesCommand(command!), new Exception());

            var commandRunner = new CommandsRunner();

            commandRunner.AddCommandToTheQueue(logExceptionCommand);

            var queueSize = commandRunner.GetQueueSize();

            commandRunner.ExecuteQueue();

            Assert.True(queueSize == 1);
            Assert.NotNull(logExceptionCommand.GetLog());
            Assert.Contains(new RepeatTwoTimesCommand(command!).GetType().ToString(), logExceptionCommand.GetLog());
        }
    }
}
