using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Exceptions;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.UnitTests
{
    public class CheckFuelCommandTests
    {
        [Fact]
        public void CheckFuelCommandExceptionTest()
        {
            Assert.Throws<CommandException>(() => new CheckFuelCommand(new Fuel(0, 2)).Execute());
        }

        //todo Придумать еще тесты
    }
}
