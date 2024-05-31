using MainPatterns.SpaceBattle.Exceptions;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands.Simple
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

