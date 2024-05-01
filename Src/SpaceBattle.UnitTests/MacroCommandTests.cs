using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Exceptions;
using MainPatterns.SpaceBattle.ObjectParameters;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.UnitTests
{
    public class MacroCommandTests
    {
        [Fact]
        public void MacroCommandTest()
        {
            var spaceObject = new SpaceObject();

            spaceObject.Add(new Parameters()
            {
                Position = new Vector(1, 1),
                Velocity = new Vector(2, 2),
                Rotation = new Vector(3, 3)
            });

            spaceObject.Add(new Fuel(10, 20));

            var parameters = spaceObject.GetComponent<Parameters>();

            var fuel = spaceObject.GetComponent<Fuel>();

            var macroCommand = new MacroCommand(new List<ICommand>
            {
                new MoveAndBurnFuelCommand(spaceObject, new Vector(1, 1)),
                new CheckFuelCommand(fuel), //CommandException(CheckFuelCommand())
                new RotateAndChangeVelocityCommand(spaceObject, new Vector(2, 2))
            });

            Assert.Throws<CommandException>(() => macroCommand.Execute());

            Assert.True(parameters.Position!.Equals(parameters.Position, new Vector(1, 1)));
            Assert.True(parameters.Velocity!.Equals(parameters.Velocity, new Vector(2, 2)));
            Assert.True(parameters.Rotation!.Equals(parameters.Rotation, new Vector(3, 3)));

            macroCommand.Undo();

            Assert.True(parameters.Position!.Equals(parameters.Position, new Vector(0, 0)));
            Assert.True(parameters.Velocity!.Equals(parameters.Velocity, new Vector(0, 0)));
            Assert.True(parameters.Rotation!.Equals(parameters.Rotation, new Vector(0, 0)));
        }
    }
}

