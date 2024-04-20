using MainPatterns.SpaceBattle.Calculations;
using MainPatterns.SpaceBattle.Objects;

namespace MainPatterns.SpaceBattle.Commands
{
    public class MoveCommand
    {
        //public readonly SpaceObject SpaceObject;

        //public readonly Vector Direction;

        //private Specifications specifications;

        public IMovable movable;

        public MoveCommand(IMovable movable)
        {
            this.movable = movable;

            //this.SpaceObject = spaceObject;
            //this.Direction = direction;
            //this.specifications = this.SpaceObject.Get<Specifications>();
        }

        public void Execute()
        {
            movable.SetPosition(new Vector().Sum(movable.GetPosition(), movable.GetVelocity()));
        }
    }
}
