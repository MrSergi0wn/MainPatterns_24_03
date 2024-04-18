using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands
{
    public class MoveCommand
    {
        public readonly SpaceObject SpaceObject;

        public readonly Vector Direction;

        private Specifications specifications;

        public MoveCommand(SpaceObject spaceObject, Vector direction)
        {
            this.SpaceObject = spaceObject;
            this.Direction = direction;
            this.specifications = this.SpaceObject.Get<Specifications>();
        }

        public void Execute()
        {
            this.specifications.Position = this.specifications.Position.Sum() Direction;
        }
    }
}
