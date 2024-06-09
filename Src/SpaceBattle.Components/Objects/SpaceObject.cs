using System.Collections.Generic;
using System.Linq;
using SpaceBattle.Components.Actions;

namespace SpaceBattle.Components.Objects
{
    public class SpaceObject : IObject
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
    }
}
