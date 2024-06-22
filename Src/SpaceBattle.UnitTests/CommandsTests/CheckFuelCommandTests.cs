using Moq;
using SpaceBattle.Actions;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Exceptions;

namespace SpaceBattle.UnitTests.CommandsTests
{
    public class CheckFuelCommandTests
    {
        [Fact]
        public void CheckFuelCommandExceptionTest()
        {
            var objectForFuelBurn = new Mock<IBurningFuel>();
            objectForFuelBurn.SetupGet(o => o.Volume).Returns(0);
            objectForFuelBurn.SetupGet(o => o.Consumption).Returns(5);

            Assert.Throws<CommandException>(() => new CheckFuelCommand(objectForFuelBurn.Object).Execute());
        }
    }
}
