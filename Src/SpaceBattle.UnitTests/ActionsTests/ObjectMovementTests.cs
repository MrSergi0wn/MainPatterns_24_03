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
        /// ��� �������, ������������ � ����� (12, 5) � ����������� �� ��������� (-7, 3) �������� ������ ��������� ������� �� (5, 8) 
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
        /// ������� �������� ������, � �������� ���������� ��������� ��������� � ������������, �������� � ������
        /// </summary>
        [Fact]
        public void ImpossibleMoveObjectWhenCantGetGetPositionTest()
        {
            var objectToMove = new Mock<IMovable>();
            objectToMove.SetupGet(o => o.Position).Returns(new Vector2(float.NaN, 0));

            var action = () => new MoveCommand(objectToMove.Object).Execute();

            action.Should().Throw<Exception>().WithMessage("���������� �������� ��������� �������!");
        }

        /// <summary>
        /// ������� �������� ������, � �������� ���������� ��������� �������� ���������� ��������, �������� � ������
        /// </summary>
        [Fact]
        public void ImpossibleToMoveObjectWhenCantGetVelocityTest()
        {
            var objectToMove = new Mock<IMovable>();
            objectToMove.SetupGet(o => o.Velocity).Returns(new Vector2(float.NaN, 0));
            var mover = new MoveCommand(objectToMove.Object);

            var action = () => new MoveCommand(objectToMove.Object).Execute();

            action.Should().Throw<Exception>().WithMessage("���������� �������� �������� �������!");
        }

        /// <summary>
        /// ������� �������� ������, � �������� ���������� �������� ��������� � ������������, �������� � ������
        /// </summary>
        [Fact]
        public void ObjectWithNanValuesTest()
        {
            IMovable? objectToMove = null;

            var action = () => new MoveCommand(objectToMove!).Execute();

            action.Should().Throw<Exception>().WithMessage("���������� �������� ������!");
        }
    }
}