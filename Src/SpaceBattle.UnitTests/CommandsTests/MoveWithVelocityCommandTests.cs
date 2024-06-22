using System.Numerics;
using Moq;
using SpaceBattle.Actions;
using SpaceBattle.Commands.Simple;

namespace SpaceBattle.UnitTests.CommandsTests
{
    public class MoveWithVelocityCommandTests
    {
        [Fact]
        public void MoveWithVelocityCommandTest()
        {
            var objectToMove = new Mock<IMovable>();
            objectToMove.SetupGet(o => o.Position).Returns(new Vector2(12, 5));
            objectToMove.SetupGet(o => o.Velocity).Returns(new Vector2(-7, 3));
            var mover = new MoveCommand(objectToMove.Object);

            mover.Execute();

            objectToMove.VerifySet(o => o.Position = new Vector2(5, 8));
        }
    }
}

