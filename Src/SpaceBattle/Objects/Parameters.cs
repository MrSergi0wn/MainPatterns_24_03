using System.Numerics;
using SpaceBattle.Actions;

namespace SpaceBattle.Objects
{
    public class Parameters : IObject, IMovable, IRotatable
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public int Direction { get; set; }
        public int AngularVelocity { get; }
    }
}