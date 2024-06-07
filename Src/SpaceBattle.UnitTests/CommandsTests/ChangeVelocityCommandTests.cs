﻿using SpaceBattle.Commands.Simple;
using SpaceBattle.Components.Calculations;
using SpaceBattle.Components.Objects;
using SpaceBattle.ObjectParameters;

namespace SpaceBattle.UnitTests.CommandsTests
{
    public class ChangeVelocityCommandTests
    {
        [Fact]
        public void ChangeVelocityCommandTest()
        {
            var spaceObject = new SpaceObject();

            var parameters = new Parameters()
            {
                Velocity = new Vector(1, 1)
            };

            spaceObject.Add(parameters);

            var changeVelocityCommand = new ChangeVelocityCommand(spaceObject, new Vector(2, 2));

            changeVelocityCommand.Execute();

            Assert.True(parameters.Velocity.Equals(parameters.Velocity, new Vector(3, 3)));

            changeVelocityCommand.Execute();
            changeVelocityCommand.Execute();

            Assert.True(parameters.Velocity.Equals(parameters.Velocity, new Vector(7, 7)));

            changeVelocityCommand.Undo();

            Assert.True(parameters.Velocity.Equals(parameters.Velocity, new Vector(5, 5)));
        }
    }
}

