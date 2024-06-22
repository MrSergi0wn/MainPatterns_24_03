using System.Numerics;
using FluentAssertions;
using Moq;
using SpaceBattle.Actions;
using SpaceBattle.Commands.Simple;

namespace SpaceBattle.UnitTests.ActionsTests
{
    public class ObjectMovementTests
    {
        /// <summary>
        /// Для объекта, находящегося в точке (12, 5) и движущегося со скоростью (-7, 3) движение меняет положение объекта на (5, 8) 
        /// </summary>
        [Fact]
        public void ObjectChangePositionTest()
        {
            var spaceObject = new Mock<IMovable>();
            spaceObject.SetupGet(o => o.Position).Returns(new Vector2(12, 5 ));
            spaceObject.SetupGet(o => o.Velocity).Returns(new Vector2(-7, 3));

            new MoveCommand(spaceObject.Object).Execute();

            spaceObject.VerifySet(o => o.Position = new Vector2(5, 8));
        }

        /// <summary>
        /// Попытка сдвинуть объект, у которого невозможно прочитать положение в пространстве, приводит к ошибке
        /// </summary>
        [Fact]
        public void ImpossibleMoveObjectWhenCantGetGetPositionTest()
        {
            var objectToMove = new Mock<IMovable>();
            objectToMove.SetupGet(o => o.Position).Returns(new Vector2(float.NaN, 0));

            var action = () => new MoveCommand(objectToMove.Object).Execute();

            action.Should().Throw<Exception>().WithMessage("Невозможно получить положение объекта!");
        }

        /// <summary>
        /// Попытка сдвинуть объект, у которого невозможно прочитать значение мгновенной скорости, приводит к ошибке
        /// </summary>
        [Fact]
        public void ImpossibleToMoveObjectWhenCantGetVelocityTest()
        {
            var objectToMove = new Mock<IMovable>();
            objectToMove.SetupGet(o => o.Velocity).Returns(new Vector2(float.NaN, 0));
            var mover = new MoveCommand(objectToMove.Object);

            var action = () => new MoveCommand(objectToMove.Object).Execute();

            action.Should().Throw<Exception>().WithMessage("Невозможно получить скорость объекта!");
        }

        /// <summary>
        /// Попытка сдвинуть объект, у которого невозможно изменить положение в пространстве, приводит к ошибке
        /// </summary>
        [Fact]
        public void ObjectWithNanValuesTest()
        {
            IMovable? objectToMove = null;

            var action = () => new MoveCommand(objectToMove!).Execute();

            action.Should().Throw<Exception>().WithMessage("Невозможно сдвинуть объект!");
        }
    }
}