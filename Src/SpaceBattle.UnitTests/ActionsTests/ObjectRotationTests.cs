using System.Numerics;
using Moq;
using SpaceBattle.Actions;
using SpaceBattle.Commands.Simple;

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
            var objectToRotate = new Mock<IRotatable>();
            objectToRotate.SetupGet(o => o.Direction).Returns(0);
            objectToRotate.SetupGet(o => o.AngularVelocity).Returns(10);
            objectToRotate.SetupGet(o => o.Direction).Returns(5);

            new RotateCommand(objectToRotate.Object).Execute();

            objectToRotate.VerifySet(o => o.Direction = 5);
        }

        /// <summary>
        /// Попытка повернуть объект, у которого невозможно прочитать наклон, приводит к ошибке
        /// </summary>
        [Fact]
        public void ImpossibleRotateObjectWhenCantGetRotationTest()
        {
            Assert.Throws<Exception>(() => new RotateCommand(null!).Execute());
        }

        /// <summary>
        /// Попытка повернуть объект, у которого невозможно изменить наклон, приводит к ошибке
        /// </summary>
        [Fact]
        public void ObjectWithNanValuesTest()
        {
            var objectToRotate = new Mock<IRotatable>();
            objectToRotate.SetupGet(o => o.Direction).Returns(0);
            objectToRotate.SetupGet(o => o.AngularVelocity).Returns(0);
            objectToRotate.SetupGet(o => o.Direction).Returns(0);

            Assert.Throws<Exception>(() => new RotateCommand(objectToRotate.Object).Execute());
        }
    }
}
