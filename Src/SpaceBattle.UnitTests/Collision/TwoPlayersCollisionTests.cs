using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using SpaceBattle.Actions;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Server;

namespace SpaceBattle.UnitTests.Collision
{
    public class TwoPlayersCollisionTests
    {
        private readonly Mock<IResolvable> ioc;

        public TwoPlayersCollisionTests()
        {
            this.ioc = new Mock<IResolvable>();
        }

        [Fact]
        public void TwoSpaceObjectsInOneAreaCollisionCheckTest()
        {
            var firstObject = new Mock<IMovable>();
            firstObject.SetupGet(obj => obj.Position).Returns(new Vector2(1, 2));

            var secondObject = new Mock<IMovable>();
            secondObject.SetupGet(obj => obj.Position).Returns(new Vector2(4, 6));

            var thirdObject = new Mock<IMovable>();
            thirdObject.SetupGet(obj => obj.Position).Returns(new Vector2(11,11));

            
            var stopCommand = new Mock<ICommand>();
            var manualResetEvent = new ManualResetEvent(false);
            stopCommand.Setup(c => c.Execute()).Callback(() => manualResetEvent.Set());

            var queue = new ConcurrentQueue<ICommand>();
            var gameServer = new GameServer(this.ioc.Object, queue);

            var identCollisionsCommand = new IdentCollisionsCommand(gameServer,
                new List<IMovable>() { firstObject.Object, secondObject.Object, thirdObject.Object });
            queue.Enqueue(identCollisionsCommand);
            queue.Enqueue(stopCommand.Object);

            gameServer.RunMultithreadCommands();

            manualResetEvent.WaitOne().Should().BeTrue();
            gameServer.CollisionObjects.Count.Should().Be(2);
            gameServer.CollisionObjects.ElementAt(0).Position.X.Should().Be(1);
            gameServer.CollisionObjects.ElementAt(0).Position.Y.Should().Be(2);
            gameServer.CollisionObjects.ElementAt(1).Position.X.Should().Be(4);
            gameServer.CollisionObjects.ElementAt(1).Position.Y.Should().Be(6);
        }

        [Fact]
        public void TwoSpaceObjectsInDifferentAreaCollisionCheckTest()
        {
            var firstObject = new Mock<IMovable>();
            firstObject.SetupGet(obj => obj.Position).Returns(new Vector2(6, 7));

            var secondObject = new Mock<IMovable>();
            secondObject.SetupGet(obj => obj.Position).Returns(new Vector2(11, 15));

            var stopCommand = new Mock<ICommand>();
            var manualResetEvent = new ManualResetEvent(false);
            stopCommand.Setup(c => c.Execute()).Callback(() => manualResetEvent.Set());

            var queue = new ConcurrentQueue<ICommand>();
            var gameServer = new GameServer(this.ioc.Object, queue);

            var identCollisionsCommand = new IdentCollisionsCommand(gameServer,
                new List<IMovable>() { firstObject.Object, secondObject.Object});
            queue.Enqueue(identCollisionsCommand);
            queue.Enqueue(stopCommand.Object);

            gameServer.RunMultithreadCommands();

            manualResetEvent.WaitOne().Should().BeTrue();
            gameServer.CollisionObjects.Count.Should().Be(0);
        }

        [Fact]
        public void TwoSpaceObjectsInDifferentAreaButNearEachOtherCollisionCheckTest()
        {
            var firstObject = new Mock<IMovable>();
            firstObject.SetupGet(obj => obj.Position).Returns(new Vector2(19, 19));

            var secondObject = new Mock<IMovable>();
            secondObject.SetupGet(obj => obj.Position).Returns(new Vector2(20, 20));

            var stopCommand = new Mock<ICommand>();
            var manualResetEvent = new ManualResetEvent(false);
            stopCommand.Setup(c => c.Execute()).Callback(() => manualResetEvent.Set());

            var queue = new ConcurrentQueue<ICommand>();
            var gameServer = new GameServer(this.ioc.Object, queue);

            var identCollisionsCommand = new IdentCollisionsCommand(gameServer,
                new List<IMovable>() { firstObject.Object, secondObject.Object }, 5);
            queue.Enqueue(identCollisionsCommand);
            queue.Enqueue(stopCommand.Object);

            gameServer.RunMultithreadCommands();

            manualResetEvent.WaitOne().Should().BeTrue();
            gameServer.CollisionObjects.Count.Should().Be(2);
            gameServer.CollisionObjects.ElementAt(0).Position.X.Should().Be(19);
            gameServer.CollisionObjects.ElementAt(0).Position.Y.Should().Be(19);
            gameServer.CollisionObjects.ElementAt(1).Position.X.Should().Be(20);
            gameServer.CollisionObjects.ElementAt(1).Position.Y.Should().Be(20);
        }
    }
}
