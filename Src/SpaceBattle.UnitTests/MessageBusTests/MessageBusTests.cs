using System.Collections.Concurrent;
using System.Numerics;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Components.Actions;
using SpaceBattle.Components.Objects;
using SpaceBattle.MessageBus;
using SpaceBattle.ObjectParameters;
using SpaceBattle.Server;
using Vector = SpaceBattle.Components.Calculations.Vector;

namespace SpaceBattle.UnitTests.MessageBusTests
{
    public class MessageBusTests
    {
        //[Fact]
        //public void GameObjectMovesAfterServerReceivedMessage()
        //{
        //    var objectToMove = new Mock<IMovable>();
        //    objectToMove.SetupGet(o => o.Position).Returns(new Vector(12, 5));
        //    //objectToMove.Setup(o => o.GetComponent<Parameters>()).Returns(new Parameters() { Position = new Vector(12, 5) });
        //    //objectToMove.SetupGet(o => o.GetComponent<Parameters>()).Returns(new Parameters() { Position = new Vector(12, 5) });

        //    var ioc = new Ioc.Ioc();
        //    ioc.Bind("Objects.Movable548", (Func<object[], object>)(_ => objectToMove.Object));
        //    var movable548Command = ioc.Resolve<ICommand>("IoC.Register",
        //        "Objects.Movable548",
        //        (Func<object[], object>)(_ => objectToMove.Object)
        //    );

        //    //ioc.Resolve<ICommand>("IoC.Register",
        //    //    "Commands.Move",
        //    //    (Func<object[], object>)(args => new MoveCommand((SpaceObject)args[0], (Vector)args[1]))
        //    //).Execute();

        //    var server = new GameServer(ioc, new ConcurrentQueue<ICommand>());

        //    server.RunMultithreadCommands();

        //    var message = new GameMessage
        //    {
        //        GameId = 1,
        //        GameObjectId = "Objects.Movable548",
        //        GameOperationId = "Commands.Move",
        //        ArgsJson = "2"
        //    };

        //    server.MessageReceived(message);

        //    objectToMove.VerifySet(obj => obj.Position = new Vector(14, 7));
        //}
    }
}
