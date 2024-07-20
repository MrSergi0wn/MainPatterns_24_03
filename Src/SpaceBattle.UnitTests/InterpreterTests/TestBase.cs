using Moq;
using SpaceBattle.Actions;

namespace SpaceBattle.UnitTests.InterpreterTests
{
    public class TestBase
    {
        protected Mock<IResolvable> Ioc;

        public TestBase()
        {
            this.Ioc = new Mock<IResolvable>();
        }
    }
}
