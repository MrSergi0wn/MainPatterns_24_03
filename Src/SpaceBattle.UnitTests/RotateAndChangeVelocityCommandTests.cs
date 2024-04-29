using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Commands;
using MainPatterns.SpaceBattle.Exceptions;
using MainPatterns.SpaceBattle.ObjectParameters;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.UnitTests
{
    public class RotateAndChangeVelocityCommandTests
    {
        [Fact]
        public void RotateAndChangeVelocityCommandTest()
        {
            var spaceObject = new SpaceObject();

            var parameters = new Parameters()
            {
                Position = new Vector(1, 1),
                Velocity = new Vector(0, 0),
                Rotation = new Vector(3, 3)
            };

            spaceObject.Add(parameters);

            var rotateAndChangeVelocityCommand = new RotateAndChangeVelocityCommand(spaceObject, new Vector(1, 1));

            Assert.Throws<CommandException>(() => rotateAndChangeVelocityCommand.Execute());
        }
    }
}
