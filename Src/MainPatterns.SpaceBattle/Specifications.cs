using MainPatterns.SpaceBattle.Calculations;

namespace MainPatterns.SpaceBattle
{
    public class Specifications : IObject
    {
        public Vector? Position { get; set; }

        public Vector? Velocity { get; set; }

        public Vector? Rotation { get; set; }
    }
}
