using SpaceBattle.Actions;
using SpaceBattle.Exceptions;

namespace SpaceBattle.Commands.Simple
{
    public class CheckFuelCommand : ICommand
    {
        public readonly IBurningFuel burningFuel;

        public CheckFuelCommand(IBurningFuel burningFuel)
        {
            this.burningFuel = burningFuel;
        }

        public void Execute()
        {
            if (this.burningFuel.Volume < this.burningFuel.Consumption) throw new CommandException(this);
        }

        public void Undo() { }
    }
}

