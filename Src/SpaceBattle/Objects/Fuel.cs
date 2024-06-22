using SpaceBattle.Actions;

namespace SpaceBattle.Objects
{
    public class Fuel : IObject
    {
        public int FuelVolume { get; set; }

        public int Consumption { get; set; }

        private const int MaxFuelVolume = 10;

        public Fuel(int fuelVolume, int consumption)
        {
            FuelVolume = fuelVolume;
            Consumption = consumption;
        }

        public void Add(int fuel)
        {
            this.FuelVolume += fuel;

            if (this.FuelVolume > MaxFuelVolume) this.FuelVolume = MaxFuelVolume;
        }

        public void Burn()
        {
            if (this.Consumption >= MaxFuelVolume)
            {
                this.FuelVolume = 0;
            }
            else
            {
                this.FuelVolume -= this.Consumption;
            }
        }
    }
}
