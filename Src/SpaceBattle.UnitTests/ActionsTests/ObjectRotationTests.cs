using SpaceBattle.Commands.Simple;
using SpaceBattle.Components.Calculations;
using SpaceBattle.Components.Objects;
using SpaceBattle.ObjectParameters;

namespace SpaceBattle.UnitTests.ActionsTests
{
    public class ObjectRotationTests
    {
        /// <summary>
        /// Для объекта, у которого параметр поворот (12, 5), движение меняет угол объекта на (5, 8) 
        /// </summary>
        [Fact]
        public void ObjectChangeRotationTest()
        {
            var starShip = new SpaceObject();
            starShip.Add(new Parameters());

            var starShipSpecifications = starShip.GetComponent<Parameters>();
            starShipSpecifications.Rotation = new Vector(new double[] { 12, 5 });

            new RotateCommand(starShip, new Vector(new double[] { 5, 8 })).Execute();

            Assert.True(starShipSpecifications.Rotation.Equals(starShipSpecifications.Rotation,
                new Vector(new double[] { 17, 13 })));
        }

        /// <summary>
        /// Попытка повернуть объект, у которого невозможно прочитать наклон, приводит к ошибке
        /// </summary>
        [Fact]
        public void ImpossibleRotateObjectWhenCantGetRotationTest()
        {
            Assert.Throws<Exception>(() => new RotateCommand(new SpaceObject(), new Vector(new double[] { -7, 3 })).Execute());
        }

        /// <summary>
        /// Попытка повернуть объект, у которого невозможно изменить наклон, приводит к ошибке
        /// </summary>
        [Fact]
        public void ObjectWithNanValuesTest()
        {
            var starShip = new SpaceObject();
            starShip.Add(new Parameters());

            var starShipSpecifications = starShip.GetComponent<Parameters>();

            Assert.Throws<Exception>(() => starShipSpecifications.Rotation = new Vector(new double[] { double.NaN, 5 }));
        }
    }
}
