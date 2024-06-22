
using SpaceBattle.Actions;

namespace SpaceBattle.Commands.Simple
{
    public class BurnFuelCommand : ICommand
    {
        public readonly IBurningFuel burningFuel;

        public BurnFuelCommand(IBurningFuel burningFuel)
        {
            this.burningFuel = burningFuel;
        }

        public void Execute()
        {
            this.burningFuel.Volume -= this.burningFuel.Consumption;
        }

        public void Undo()
        {
            this.burningFuel.Volume += this.burningFuel.Consumption;
        }
    }
}

