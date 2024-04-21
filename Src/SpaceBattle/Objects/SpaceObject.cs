using MainPatterns.SpaceBattle.Interfaces;
using System.ComponentModel;

namespace MainPatterns.SpaceBattle.Objects
{
    public class SpaceObject
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

        public T Get<T>() where T : IObject
        {
            return (T)Objects.FirstOrDefault(obj => obj.GetType() == typeof(T))!;
        }
    }
}
