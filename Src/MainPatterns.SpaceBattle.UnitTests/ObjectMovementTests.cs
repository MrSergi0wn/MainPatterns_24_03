using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Objects;

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
            var starShip = new SpaceObject();
            starShip.Add(new Specifications());

            var starShipSpecifications = starShip.Get<Specifications>();
            starShipSpecifications.Position = new Vector(12, 5);

            var moveCommand = new MoveCommand(starShip, new Vector(-7, 3));
            moveCommand.Execute();

            Assert.Equal(starShipSpecifications.Position, new Vector(5, 8));
        }
    }
}