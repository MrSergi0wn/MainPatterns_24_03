using Moq;
using SpaceBattle.Actions;

namespace SpaceBattle.UnitTests.AuthenticationTests
{
    public class TestSetup
    {
        protected Mock<IResolvable> Ioc;

        public TestSetup()
        {
            this.Ioc = new Mock<IResolvable>();
        }
    }
}
