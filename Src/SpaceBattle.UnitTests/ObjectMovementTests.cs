using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.ObjectParameters;
using MainPatterns.SpaceBattle.Objects;
using Vector = MainPatterns.SpaceBattle.Calculations.Vector;

namespace MainPatterns.SpaceBattle.UnitTests
{
    public class ObjectMovementTests
    {
        /// <summary>
        /// ��� �������, ������������ � ����� (12, 5) � ����������� �� ��������� (-7, 3) �������� ������ ��������� ������� �� (5, 8) 
        /// </summary>
        [Fact]
        public void ObjectChangePositionTest()
        {
            var starShip = new SpaceObject();
            starShip.Add(new Parameters());

            var starShipSpecifications = starShip.Get<Parameters>();
            starShipSpecifications.Position = new Vector(new double[]{ 12, 5 });

            new MoveCommand(starShip, new Vector(new double[] { -7, 3 })).Execute();

            Assert.True(starShipSpecifications.Position.Equals(starShipSpecifications.Position,
                new Vector(new double[] { 5, 8 })));
        }

        /// <summary>
        /// ������� �������� ������, � �������� ���������� ��������� ��������� � ������������, �������� � ������
        /// </summary>
        [Fact]
        public void ImpossibleMoveObjectWhenCantGetGetPositionTest()
        {
            Assert.Throws<Exception>(() => new MoveCommand(new SpaceObject(), new Vector(new double[] { -7, 3 })).Execute());
        }

        /// <summary>
        /// ������� �������� ������, � �������� ���������� ��������� �������� ���������� ��������, �������� � ������
        /// </summary>
        [Fact]
        public void ImpossibleToMoveObjectWhenCantGetVelocityTest()
        {
            var starShip = new SpaceObject();
            starShip.Add(new Parameters());

            var starShipSpecifications = starShip.Get<Parameters>();
            starShipSpecifications.Position = new Vector(new double[] { 1, 5 });

            Assert.Throws<Exception>(() => new MoveCommand(starShip, new Vector(double.NaN, double.NaN)).Execute());
        }

        /// <summary>
        /// ������� �������� ������, � �������� ���������� �������� ��������� � ������������, �������� � ������
        /// </summary>
        [Fact]
        public void ObjectWithNanValuesTest()
        {
            var starShip = new SpaceObject();
            starShip.Add(new Parameters());

            var starShipSpecifications = starShip.Get<Parameters>();
            
            Assert.Throws<Exception>(() => starShipSpecifications.Position = new Vector(new double[] { double.NaN, 5 }));
        }
    }
}