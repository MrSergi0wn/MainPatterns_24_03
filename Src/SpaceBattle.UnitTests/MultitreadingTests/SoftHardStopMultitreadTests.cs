using System.Collections.Concurrent;
using FluentAssertions;
using Moq;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Ioc;
using SpaceBattle.Server;

namespace SpaceBattle.UnitTests.MultitreadingTests
{
    public class SoftHardStopMultitreadTests
    {
        protected Mock<IoContainer> Ioc = new();

        [Fact]
        public void ExecuteMultitreadTest()
        {
            var command = new Mock<ICommand>();

            var resetEvent = new ManualResetEvent(false);

            command.Setup(c => c.Execute()).Callback(() => resetEvent.Set());

            var queue = new ConcurrentQueue<ICommand>();

            queue.Enqueue(command.Object);

            var server = new GameServer(this.Ioc.Object, queue);

            server.RunMultithreadCommands();

            Assert.True(resetEvent.WaitOne(TimeSpan.FromSeconds(5)));
        }

        [Fact]
        public void SoftStopMultitreadTest()
        {
            var firstCommand = new Mock<ICommand>();
            var firstResetEvent = new ManualResetEvent(false);
            firstCommand.Setup(c => c.Execute()).Callback(() => firstResetEvent.Set());

            var secondCommand = new Mock<ICommand>();
            var secondResetEvent = new ManualResetEvent(false);
            secondCommand.Setup(c => c.Execute()).Callback(() => secondResetEvent.Set());

            var thirdCommand = new Mock<ICommand>();
            var thirdResetEvent = new ManualResetEvent(false);
            thirdCommand.Setup(c => c.Execute()).Callback(() => thirdResetEvent.Set());

            var softStopCommand = new SoftStopMultitreadCommand();
            var queue = new ConcurrentQueue<ICommand>();
            queue.Enqueue(firstCommand.Object);
            queue.Enqueue(secondCommand.Object);
            queue.Enqueue(softStopCommand);
            queue.Enqueue(thirdCommand.Object);
            var server = new GameServer(this.Ioc.Object, queue);

            server.RunMultithreadCommands();

            firstResetEvent.WaitOne(TimeSpan.FromSeconds(5)).Should().BeTrue();

            firstCommand.Verify(fc => fc.Execute(), Times.Once);

            secondResetEvent.WaitOne(TimeSpan.FromSeconds(5)).Should().BeTrue();

            secondCommand.Verify(sc => sc.Execute(), Times.Once);

            thirdResetEvent.WaitOne(TimeSpan.FromSeconds(5)).Should().BeTrue();

            thirdCommand.Verify(tc => tc.Execute(), Times.Once);

            server.Games.First().Value.Should().BeEmpty();
        }

        [Fact]
        public void HardStopMultitreadTest()
        {
            var firstCommand = new Mock<ICommand>();
            var resetEvent = new ManualResetEvent(false);
            firstCommand.Setup(c => c.Execute()).Callback(() => resetEvent.Set());

            var secondCommand = new Mock<ICommand>();

            var hardStopCommand = new HardStopMultithreadCommand();
            var queue = new ConcurrentQueue<ICommand>();
            queue.Enqueue(firstCommand.Object);
            queue.Enqueue(hardStopCommand);
            queue.Enqueue(secondCommand.Object);
            var server = new GameServer(this.Ioc.Object, queue);

            server.RunMultithreadCommands();

            resetEvent.WaitOne(TimeSpan.FromSeconds(5)).Should().BeTrue();

            firstCommand.Verify(fc => fc.Execute(), Times.Once);

            secondCommand.Verify(sc => sc.Execute(), Times.Never);

            server.Games.First().Value.Should().NotBeEmpty();
        }
    }
}
