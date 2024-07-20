using System.Collections.Concurrent;
using System.Numerics;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SpaceBattle.Actions;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.IocContainer;
using SpaceBattle.MessageBus;
using SpaceBattle.Server;

namespace SpaceBattle.UnitTests.InterpreterTests
{
    public class InterpreterTests : TestBase
    {
        /// <summary>
        /// Test for demonstration that after interpreted order, command executed for movable object in scope for gameObjectId = 548
        /// </summary>
        [Test]
        public void CheckIfInScope()
        {
            var movableObject = new Mock<IMovable>();

            movableObject.SetupGet(obj => obj.Position).Returns(new Vector2(1, 2));

            var ioc = new IocC();

            ioc.Resolve<ICommand>("Scopes.New", "548").Execute();

            ioc.Resolve<ICommand>("Scopes.Current", "548").Execute();

            ioc.Resolve<ICommand>("IoC.Register", "Object.548Movable",
                (Func<object[], object>)(_ => movableObject.Object)).Execute();

            ioc.Resolve<ICommand>("IoC.Register", "Commands.MoveWithVelocity",
                    (Func<object[], object>)(args => new MoveWithVelocityCommand((IMovable)args[0], (Vector2)args[1])))
                .Execute();

            var gameServer = new GameServer(ioc, new ConcurrentQueue<ICommand>());
            gameServer.RunMultithreadCommands();

            var gameMessage = new GameMessage()
            {
                GameId = 1,
                GameObjectId = "Object.548Movable",
                GameOperationId = "Commands.MoveWithVelocity",
                ArgsJson = "2"
            };

            gameServer.ReceiveMessage(gameMessage);

            movableObject.VerifySet(obj => obj.Position = new Vector2(3, 4));
        }

        /// <summary>
        /// Test for demonstration that after interpreted order, command don`t executed for movable object in different scope`s
        /// </summary>
        [Test]
        public void CheckIfNotInScope()
        {
            var movableObject = new Mock<IMovable>();

            movableObject.SetupGet(obj => obj.Position).Returns(new Vector2(1, 2));

            var ioc = new IocC();

            ioc.Resolve<ICommand>("Scopes.New", "548").Execute();

            ioc.Resolve<ICommand>("Scopes.Current", "548").Execute();

            ioc.Resolve<ICommand>("IoC.Register", "Object.548Movable",
                (Func<object[], object>)(_ => movableObject.Object)).Execute();

            ioc.Resolve<ICommand>("IoC.Register", "Commands.MoveWithVelocity",
                    (Func<object[], object>)(args => new MoveWithVelocityCommand((IMovable)args[0], (Vector2)args[1])))
                .Execute();

            ioc.Resolve<ICommand>("Scopes.New", "845").Execute();

            ioc.Resolve<ICommand>("Scopes.Current", "845").Execute();

            var gameServer = new GameServer(ioc, new ConcurrentQueue<ICommand>());

            gameServer.RunMultithreadCommands();

            var gameMessage = new GameMessage()
            {
                GameId = 1,
                GameObjectId = "548",
                GameOperationId = "Commands.MoveWithVelocity",
                ArgsJson = "2"
            };

            var receivingMessage = () => gameServer.ReceiveMessage(gameMessage);

            receivingMessage.Should().Throw<Exception>().WithMessage($"Операции связанные с 548 не найдены!");

            movableObject.Object.Should().NotBeNull();
            movableObject.VerifySet(obj => obj.Position = new Vector2(3, 4), Times.Never);
        }
    }
}
