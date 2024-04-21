using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Objects;
using System.Numerics;
using System.Windows.Input;
using Vector = MainPatterns.SpaceBattle.Calculations.Vector;

namespace MainPatterns.SpaceBattle.UnitTests
{
    public class ObjectMovementTests
    {
        //[Fact]
        //public void ObjectChangePositionTest()
        //{
        //    // Для объекта, находящегося в точке (12, 5) и движущегося со скоростью (-7, 3) движение меняет положение объекта на (5, 8)

        //    GameObject tank = new GameObject();
        //    tank.AddComponent(new Transform());

        //    Transform tankTransform = tank.GetComponent<Transform>();
        //    tankTransform.Position = new Vector3(12, 5, 0);
        //    Vector3 velocity = new Vector3(-7, 3, 0);

        //    ICommand moveCommand = new MoveCommand(tank, velocity);
        //    moveCommand.Execute();

        //    Assert.That(tankTransform.Position, Is.EqualTo(new Vector3(5, 8, 0)));
        //}

        [Fact]
        public void ObjectChangePositionTest()
        {
            var starShip = new SpaceObject();
            starShip.Add(new Specifications());

            var starShipSpecifications = starShip.Get<Specifications>();
            starShipSpecifications.Position = new Vector(new[]{12, 5});
            starShipSpecifications.Velocity = new Vector(new[] { -7, 3 });

            new MoveCommand(starShip).Execute();

            Assert.Equal(starShipSpecifications.Position, new Vector(new[] { 5, 8 }));
        }

        [Fact]
        public void ObjectImpossibleToGetThePositionInSpace()
        {
            var starShip = new SpaceObject();
            starShip.Add(new Specifications());

            var starShipSpecifications = starShip.Get<Specifications>();
            starShipSpecifications.Velocity = new Vector(new[] { -7, 3 });

            Assert.Throws<NullReferenceException>(() => new MoveCommand(starShip).Execute());
            Assert.Throws<NullReferenceException>(() => starShipSpecifications.Position = new Vector(new[]{ 1, 1 }));
        }

    }
}