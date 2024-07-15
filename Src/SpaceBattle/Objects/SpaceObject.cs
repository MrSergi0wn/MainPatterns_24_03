using System.Numerics;
using SpaceBattle.Actions;

namespace SpaceBattle.Objects
{
    public class SpaceObject : IObject, IMovable
    {
        private List<IObject> Objects { get; }

        public SpaceObject()
        {
            this.Objects = new List<IObject>();
        }

        public void Add(IObject obj)
        {
            this.Objects.Add(obj);
        }

        public T GetComponent<T>() where T : IObject
        {
            return (T)Objects.FirstOrDefault(obj => obj.GetType() == typeof(T))!;
        }

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
    }
}
