using SpaceBattle.Components.Actions;
using SpaceBattle.Components.Calculations;

namespace SpaceBattle.ObjectParameters
{
    public class Parameters : IObject, IMovable, IRotatable
    {
        private Vector? position;

        private Vector? velocity;

        private Vector? rotation;

        public Vector? Position
        {
            get => position;
            set
            {
                ValidateValue(value);
                position = value;
            }
        }

        public Vector? Velocity
        {
            get => velocity;
            set
            {
                ValidateValue(value);
                velocity = value;
            }
        }

        public Vector? Rotation
        {
            get => rotation;
            set
            {
                ValidateValue(value);
                rotation = value;
            }
        }

        private void ValidateValue(Vector? vector)
        {
            if (new double[] { vector!.x, vector.y }.Any(member => double.IsNaN(member) || double.IsInfinity(member)))
                throw new Exception();
        }
    }
}
