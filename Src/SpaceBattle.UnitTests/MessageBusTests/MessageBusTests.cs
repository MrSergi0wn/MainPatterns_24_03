using System.Collections.Concurrent;
using System.Numerics;
using Moq;
using NUnit.Framework;
using SpaceBattle.Actions;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.IocContainer;
using SpaceBattle.MessageBus;
using SpaceBattle.Server;

namespace SpaceBattle.UnitTests.MessageBusTests
{
    public class MessageBusTests : TestBase
    {
        [Test]
        public void GameObjectMovesAfterServerReceivedMessageTest()
        {
            var spaceObject = new Mock<IMovable>();
            spaceObject.SetupGet(o => o.Position).Returns(new Vector2(5, 2));

            var ioc = new IocC();

            ioc.Resolve<ICommand>("IoC.Register",
                "Objects.Movable_Number548",
                (Func<object[], object>)(_ => spaceObject.Object)
            ).Execute();
            ioc.Resolve<ICommand>("IoC.Register",
                "Commands.MoveWithVelocity",
                (Func<object[], object>)(args => new MoveWithVelocityCommand((IMovable)args[0], (Vector2)args[1]))
            ).Execute();

            var server = new GameServer(ioc, new ConcurrentQueue<ICommand>());
            server.RunMultithreadCommands();

            var message = new GameMessage
            {
                GameId = 1,
                GameObjectId = "Objects.Movable_Number548",
                GameOperationId = "Commands.MoveWithVelocity",
                ArgsJson = "2"
            };

            server.ReceiveMessage(message);

            spaceObject.VerifySet(o => o.Position = new Vector2(7, 4));
        }
    }
}
