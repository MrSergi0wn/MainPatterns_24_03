using System.Numerics;

namespace SpaceBattle.Actions
{
    public interface IMovable
    {
        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; }
    }
}
