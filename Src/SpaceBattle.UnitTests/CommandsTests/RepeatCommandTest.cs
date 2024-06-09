using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Runner;

namespace SpaceBattle.UnitTests.CommandsTests
{
    public class RepeatCommandTest
    {
        [Fact]
        public void ExecuteRepeatCommandTest()
        {
            ICommand? command = null;

            var logExceptionCommand = new LogExceptionCommand(new RepeatCommand(command!), new Exception());

            var commandRunner = new CommandsRunner();

            commandRunner.AddCommandToTheQueue(logExceptionCommand);

            var queueSize = commandRunner.GetQueueSize();

            commandRunner.ExecuteQueue();

            Assert.True(queueSize == 1);
            Assert.NotNull(logExceptionCommand.GetLog());
            Assert.Contains(new RepeatCommand(command!).GetType().ToString(), logExceptionCommand.GetLog());
        }
    }
}
