using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Interfaces;

namespace MainPatterns.SpaceBattle
{
    public class Specifications : IMovable, IRotatable, IObject
    {
        private Vector position;

        private Vector? velocity;

        private Vector? rotation;

        public Vector Position
        {
            get => this.position;
            set
            {
                this.ValidateValue(value);
                this.position = value;
            }
        }

        public Vector? Velocity
        {
            get => this.velocity;
            set
            {
                this.ValidateValue(value);
                this.velocity = value;
            }
        }

        public Vector? Rotation
        {
            get => this.rotation;
            set
            {
                this.ValidateValue(value);
                this.rotation = value;
            }
        }

        private void ValidateValue(Vector? vector)
        {

            float[] nums = new float[3] { vector.X, vector.Y};
            foreach (float num in nums)
            {
                if (float.IsNaN(num)) throw new ArgumentOutOfRangeException();
                if (float.IsInfinity(num)) throw new ArgumentOutOfRangeException();
            }
        }
    }
}
