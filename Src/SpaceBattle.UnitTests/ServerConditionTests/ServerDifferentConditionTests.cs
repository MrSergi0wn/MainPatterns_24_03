using System.Collections.Concurrent;
using FluentAssertions;
using Moq;
using SpaceBattle.Actions;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Server;

namespace SpaceBattle.UnitTests.ServerConditionTests
{
    public class ServerDifferentConditionTests
    {
        private Mock<IResolvable> ioContainer { get; set; } = new();

        [Fact]
        public void CommandsQueueExecutionStopsAfterHardStopCommandTest()
        {
            var firstCommand = new Mock<ICommand>();
            var secondCommand = new Mock<ICommand>();
            var hardStopCommand = new HardStopMultithreadCommand();
            var manualResetEvent = new ManualResetEvent(false);

            firstCommand.Setup(command => command.Execute()).Callback(() => manualResetEvent.Set());
            
            var queue = new ConcurrentQueue<ICommand>();
            queue.Enqueue(firstCommand.Object);
            queue.Enqueue(hardStopCommand);
            queue.Enqueue(secondCommand.Object);

            var gameServer = new GameServer(this.ioContainer.Object, queue);
            gameServer.RunMultithreadCommands();

            manualResetEvent.WaitOne().Should().BeTrue();
            gameServer.Games.Should().HaveCount(1);
            firstCommand.Verify(fc => fc.Execute(), Times.Once);
            secondCommand.Verify(sc => sc.Execute(), Times.Never);
        }

        [Fact]
        public void GameServerChangeProcessingCommandsToMoveToAfterMoveToCommandExecuteTest()
        {
            var queue = new ConcurrentQueue<ICommand>();
            var gameServer = new GameServer(this.ioContainer.Object, queue);
            var changeStateToMoveToCommand = new ChangeServerConditionToMoveToCommand(gameServer);
            var manualResetEvent = new ManualResetEvent(false);
            var nextCommand = new Mock<ICommand>();
            nextCommand.Setup(command => command.Execute()).Callback(() => manualResetEvent.Set());
            queue.Enqueue(changeStateToMoveToCommand);
            queue.Enqueue(nextCommand.Object);

            gameServer.RunMultithreadCommands();

            manualResetEvent.WaitOne().Should().BeTrue();
            gameServer.ServerCondition.Should().BeOfType<MoveToServerCondition>();
        }

        [Fact]
        public void GameServerChangeProcessingCommandsFromMoveToServerConditionToNormalServerConditionTest()
        {
            var queue = new ConcurrentQueue<ICommand>();
            var gameServer = new GameServer(this.ioContainer.Object, queue);
            var changeServerConditionToMoveTo = new ChangeServerConditionToMoveToCommand(gameServer);
            var changeServerConditionToNormal = new ChangeServerConditionToNormalCommand(gameServer);
            var nextCommand = new Mock<ICommand>();
            var manualResetEvent = new ManualResetEvent(false);
            nextCommand.Setup(command => command.Execute()).Callback(() => manualResetEvent.Set());
            queue.Enqueue(changeServerConditionToMoveTo);
            queue.Enqueue(changeServerConditionToNormal);
            queue.Enqueue(nextCommand.Object);

            gameServer.RunMultithreadCommands();

            manualResetEvent.WaitOne().Should().BeTrue();
            gameServer.ServerCondition.Should().BeOfType<NormalServerCondition>();
        }
    }
}
