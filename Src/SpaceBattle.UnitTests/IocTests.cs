using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Ioc;
using MainPatterns.SpaceBattle.Ioc.Container;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.UnitTests
{
    public class IocTests
    {
        private readonly IIoc ioc;

        public IocTests()
        {
            this.ioc = new Ioc.Ioc();
        }

        [Fact]
        public void IsAlreadyBindTest()
        {
            this.ioc.SetScope("TestScope");

            Assert.False(this.ioc.IsAlreadyBind("TestScope2"));
        }

        [Fact]
        public void UnbindTest()
        {
            this.ioc.Bind("Move", objects => new MoveCommand((SpaceObject)objects[0], (Vector)objects[1]));

            Assert.True(this.ioc.IsAlreadyBind("Move"));

            this.ioc.UnBind("Move");

            Assert.False(this.ioc.IsAlreadyBind("Move"));
        }

        [Fact]
        public void ResolveTest()
        {
            this.ioc.Bind("Move", objects => new MoveCommand((SpaceObject)objects[0], (Vector)objects[1]));

            var spaceObject = new SpaceObject();
            var velocity = new Vector(0, 1);
            var moveCommand = this.ioc.Resolve<ICommand>("Move", spaceObject, velocity);

            Assert.Equal(moveCommand.GetType(), typeof(MoveCommand));
            Assert.Equal(((MoveCommand)moveCommand).spaceObject, spaceObject);
            Assert.Equal(((MoveCommand)moveCommand).velocity, velocity);
        }

        [Fact]
        public void SetContainersWithNullScopeExceptionTest()
        {
            Assert.Throws<Exception>(() => this.ioc.SetScope(string.Empty));
        }

        [Fact]
        public void BindWithNullKeyExceptionTest()
        {   
            Assert.Throws<Exception>(() => this.ioc.Bind("Move", null));
        }

        [Fact]
        public void BindWithNullStrategyExceptionTest()
        {
            Assert.Throws<Exception>(() => this.ioc.Bind(string.Empty, objects => new RotateCommand((SpaceObject)objects[0], (Vector)objects[1])));
        }

        [Fact]
        public void StrategyInDifferentScopes()
        {
            this.ioc.SetScope("StarShip");

            this.ioc.Bind("Move", objects => new MoveCommand((SpaceObject)objects[0], (Vector)objects[1]));

            Assert.True(this.ioc.IsAlreadyBind("Move"));

            this.ioc.SetScope("Comet");

            Assert.False(this.ioc.IsAlreadyBind("Move"));
        }
    }
}
