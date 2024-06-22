using Moq;
using SpaceBattle.Actions;
using SpaceBattle.Commands.Simple;

namespace SpaceBattle.UnitTests.CommandsTests
{
    public class BurnFuelCommandTests
    {
        [Fact]
        public void BurnFuelCommandTest()
        {
            var objectForFuelBurn = new Mock<IBurningFuel>();
            objectForFuelBurn.SetupGet(o => o.Volume).Returns(100);
            objectForFuelBurn.SetupGet(o => o.Consumption).Returns(5);

            new BurnFuelCommand(objectForFuelBurn.Object).Execute();

            objectForFuelBurn.VerifySet(o => o.Volume = 95);
        }
    }
}

