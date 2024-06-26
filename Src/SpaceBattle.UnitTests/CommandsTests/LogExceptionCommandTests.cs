﻿using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;

namespace SpaceBattle.UnitTests.CommandsTests
{
    public class LogExceptionCommandTests
    {
        [Fact]
        public void CheckLogExceptionCommandTest()
        {
            ICommand? command = null;

            var logCommand = new LogExceptionCommand(new RepeatCommand(command!), new Exception());

            logCommand.Execute();

            Assert.NotNull(logCommand.GetLog());
            Assert.Contains(new RepeatCommand(command!).GetType().ToString(), logCommand.GetLog());
        }
    }
}
