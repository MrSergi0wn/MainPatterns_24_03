using SpaceBattle.Commands.Simple;
using SpaceBattle.Components.Objects;
using SpaceBattle.Exceptions;

namespace SpaceBattle.UnitTests.CommandsTests
{
    public class CheckFuelCommandTests
    {
        [Fact]
        public void CheckFuelCommandExceptionTest()
        {
            Assert.Throws<CommandException>(() => new CheckFuelCommand(new Fuel(0, 2)).Execute());
        }
    }
}
