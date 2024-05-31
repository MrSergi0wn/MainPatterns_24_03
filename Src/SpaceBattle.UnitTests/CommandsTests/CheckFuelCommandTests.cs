using MainPatterns.SpaceBattle.Commands.Simple;
using MainPatterns.SpaceBattle.Exceptions;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.UnitTests.CommandsTests
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
