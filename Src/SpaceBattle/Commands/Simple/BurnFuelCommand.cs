using SpaceBattle.Components.Objects;

namespace SpaceBattle.Commands.Simple
{
    public class BurnFuelCommand : ICommand
    {
        public readonly Fuel Fuel;

        public BurnFuelCommand(Fuel fuel)
        {
            Fuel = fuel;
        }

        public void Execute()
        {
            Fuel.Burn();
        }

        public void Undo()
        {
            Fuel.Add(Fuel.Consumption);
        }
    }
}

