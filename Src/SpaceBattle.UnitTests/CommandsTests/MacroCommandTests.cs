using Moq;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Сomposite;

namespace SpaceBattle.UnitTests.CommandsTests
{
    public class MacroCommandTests
    {
        [Fact]
        public void MacroCommandTest()
        {
            var firstCommand = new Mock<ICommand>();
            var secondCommand = new Mock<ICommand>();
            var thirdCommand = new Mock<ICommand>();

            new MacroCommand(firstCommand.Object, secondCommand.Object, thirdCommand.Object).Execute();

            firstCommand.Verify(fc => fc.Execute(), Times.Once);
            firstCommand.Verify(sc => sc.Execute(), Times.Once);
            firstCommand.Verify(tc => tc.Execute(), Times.Once);
        }
    }
}

