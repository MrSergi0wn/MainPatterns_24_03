using Moq;
using SpaceBattle.Actions;

namespace SpaceBattle.UnitTests.MessageBusTests
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
