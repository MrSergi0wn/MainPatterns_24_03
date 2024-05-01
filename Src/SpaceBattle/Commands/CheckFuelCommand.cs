using MainPatterns.SpaceBattle.Exceptions;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands
{
    public class CheckFuelCommand : ICommand
    {
        public readonly Fuel Fuel;

        public CheckFuelCommand(Fuel fuel)
        {
            this.Fuel = fuel;
        }

        public void Execute()
        {
            if (this.Fuel.FuelVolume < this.Fuel.Consumption) throw new CommandException(this);
        }

        public void Undo() {}
    }
}

