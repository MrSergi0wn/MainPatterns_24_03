using SpaceBattle.Components.Objects;
using SpaceBattle.Exceptions;

namespace SpaceBattle.Commands.Simple
{
    public class CheckFuelCommand : ICommand
    {
        public readonly Fuel Fuel;

        public CheckFuelCommand(Fuel fuel)
        {
            Fuel = fuel;
        }

        public void Execute()
        {
            if (Fuel.FuelVolume < Fuel.Consumption) throw new CommandException(this);
        }

        public void Undo() { }
    }
}

