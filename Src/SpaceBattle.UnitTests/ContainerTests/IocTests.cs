using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Commands.Simple;
using MainPatterns.SpaceBattle.Ioc;
using MainPatterns.SpaceBattle.Ioc.Container;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.UnitTests.ContainerTests
{
    public class IocTests
    {
        private readonly IIoc ioc;

        public IocTests()
        {
            ioc = new Ioc.Ioc();
        }

        [Fact]
        public void IsAlreadyBindTest()
        {
            ioc.SetScope("TestScope");

            Assert.False(ioc.IsAlreadyBind("TestScope2"));
        }

        [Fact]
        public void UnbindTest()
        {
            ioc.Bind("Move", objects => new MoveCommand((SpaceObject)objects[0], (Vector)objects[1]));

            Assert.True(ioc.IsAlreadyBind("Move"));

            ioc.UnBind("Move");

            Assert.False(ioc.IsAlreadyBind("Move"));
        }

        [Fact]
        public void ResolveTest()
        {
            ioc.Bind("Move", objects => new MoveCommand((SpaceObject)objects[0], (Vector)objects[1]));

            var spaceObject = new SpaceObject();
            var velocity = new Vector(0, 1);
            var moveCommand = ioc.Resolve<ICommand>("Move", spaceObject, velocity);

            Assert.True(typeof(MoveCommand) == moveCommand.GetType());
            Assert.Equal(((MoveCommand)moveCommand).spaceObject, spaceObject);
            Assert.Equal(((MoveCommand)moveCommand).velocity, velocity);
        }

        [Fact]
        public void SetContainersWithNullScopeExceptionTest()
        {
            Assert.Throws<Exception>(() => ioc.SetScope(string.Empty));
        }

        [Fact]
        public void BindWithNullKeyExceptionTest()
        {
            Assert.Throws<Exception>(() => ioc.Bind("Move", null!));
        }

        [Fact]
        public void BindWithNullStrategyExceptionTest()
        {
            Assert.Throws<Exception>(() => ioc.Bind(string.Empty, objects => new RotateCommand((SpaceObject)objects[0], (Vector)objects[1])));
        }

        [Fact]
        public void StrategyInDifferentScopes()
        {
            ioc.SetScope("StarShip");

            ioc.Bind("Move", objects => new MoveCommand((SpaceObject)objects[0], (Vector)objects[1]));

            Assert.True(ioc.IsAlreadyBind("Move"));

            ioc.SetScope("Comet");

            Assert.False(ioc.IsAlreadyBind("Move"));
        }
    }
}
