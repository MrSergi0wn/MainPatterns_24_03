using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands
{
    public class BurnFuelCommand : ICommand
    {
        public readonly Fuel Fuel;

        public BurnFuelCommand(Fuel fuel)
        {
            this.Fuel = fuel;
        }

        public void Execute()
        {
            this.Fuel.Burn();
        }

        public void Undo()
        {
            this.Fuel.Add(this.Fuel.Consumption);
        }
    }
}
