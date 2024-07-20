using FluentAssertions;
using Moq;
using SpaceBattle.Actions;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Commands.Сomposite;

namespace SpaceBattle.UnitTests.ContainerTests
{
    public class IocContainerTests
    {
        [Fact]
        public void RegisterAndSolveMoveCommandTest()
        {
            var ioc = new IocContainer.IocC();
            var movableObject = new Mock<IMovable>();
            var movableAndFuelBurnableObject = movableObject.As<IBurningFuel>();

            ioc.Resolve<ICommand>("IoC.Register", "Move",
                    (Func<object[], object>)(args => new MacroCommand(new CheckFuelCommand((IBurningFuel)args[0]),
                        new MoveCommand((IMovable)args[0]),
                        new BurnFuelCommand((IBurningFuel)args[0])))
                )
                .Execute();

            var moveCommand = ioc.Resolve<ICommand>("Move", movableAndFuelBurnableObject.Object);

            moveCommand.Should().BeOfType<MacroCommand>();
        }

        [Fact]
        public void RegisterScopeTest()
        {
            var ioc = new IocContainer.IocC();

            ioc.Scopes.Count.Should().Be(0);

            ioc.Resolve<ICommand>("Scopes.New", "firstScope").Execute();

            ioc.Scopes.Count.Should().Be(1);

            ioc.Scopes.First().Value.Name.Should().Be("firstScope");
        }

        [Fact]
        public void CurrentScopeTest()
        {
            var ioc = new IocContainer.IocC();

            ioc.CurrentScope.Value?.Name.Should().Be("DefaultScope");

            ioc.Resolve<ICommand>("Scopes.New", "testScope")
                .Execute();

            ioc.Resolve<ICommand>("Scopes.Current", "testScope")
                .Execute();

            ioc.CurrentScope.Value?.Name.Should().Be("testScope");
        }

        [Fact]
        public void ErrorThrowsWhenTryingSetNotRegisteredScope()
        {
            var ioc = new IocContainer.IocC();

            var action = () => ioc.Resolve<ICommand>("Scopes.Current", "testScope")
                .Execute();

            action.Should()
                .Throw<Exception>();
        }
    }
}
