using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Commands.Simple;
using MainPatterns.SpaceBattle.Runner;

namespace MainPatterns.SpaceBattle.UnitTests.CommandsTests
{
    public class CommandsRunnerTests
    {
        [Fact]
        public void CommandsRunnerTest()
        {
            ICommand? command = null;

            var logExceptionCommand = new LogExceptionCommand(new RepeatCommand(command!), new Exception());

            var commandRunner = new CommandsRunner();

            commandRunner.AddCommandToTheQueue(logExceptionCommand);

            var queueSize = commandRunner.GetQueueSize();

            commandRunner.ExecuteQueue();

            Assert.True(queueSize == 1);
            Assert.NotNull(logExceptionCommand.GetLog());
        }
    }
}
