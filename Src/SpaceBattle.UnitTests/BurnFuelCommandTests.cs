using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.UnitTests
{
    public class BurnFuelCommandTests
    {
        [Fact]
        public void BurnFuelCommandTest()
        {
            var fuel = new Fuel(10, 2);

            var burnFuelCommand = new BurnFuelCommand(fuel);

            Assert.True(fuel.FuelVolume == 10);

            burnFuelCommand.Execute();
            Assert.True(fuel.FuelVolume == 8);

            fuel.Add(1);
            Assert.True(fuel.FuelVolume == 9);

            fuel.Add(100);
            Assert.True(fuel.FuelVolume == 10);

            fuel = new Fuel(10, 100);
            new BurnFuelCommand(fuel).Execute();
            Assert.True(fuel.FuelVolume == 0);
        }
    }
}

