using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Objects;
using Moq;

namespace MainPatterns.SpaceBattle.UnitTests
{
    public class ObjectMovementTests
    {
        //[Fact]
        //public void MovingInLine()
        //{

        //    var position = new Mock<IMovable>();
        //    position.Setup(a => a.getPosition()).Returns(new Vector(new int[] { 12, 5 })).Verifiable();
        //    position.Setup(a => a.getVelocity()).Returns(new Vector(new int[] { -5, 3 })).Verifiable();

        //    var movecommand = new MoveCommand(position.Object);
        //    movecommand.Execute();

        //    position.Verify(x => x.setPosition(new Vector(new int[] { 7, 8 })));
        //}


        [Fact]
        public void AbstractObjectChangePositionTest()
        {
            var resultPosition = new Mock<IMovable>();

            resultPosition.Setup(p => p.GetPosition()).Returns(new Vector(12, 5)).Verifiable();
            resultPosition.Setup(p => p.GetVelocity()).Returns(new Vector(-5, 3)).Verifiable();

            var moveCommand = new MoveCommand(resultPosition.Object);
            moveCommand.Execute();



            //resultPosition.Verify(p => p.SetPosition(new Vector(7, 8)));
        }
    }
}