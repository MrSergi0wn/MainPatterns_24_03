using SpaceBattle.Actions;

namespace SpaceBattle.Collisions
{
    public class SpaceGameArea
    {
        private const int GameAreaSize = 100;

        private readonly int gameAreaNumber;

        private const int CellSize = 10;

        private readonly Dictionary<string, List<IMovable>> gameObjectsInAreaCollection = new ();

        public SpaceGameArea(int gameAreaNumber = 0)
        {
            this.gameAreaNumber = gameAreaNumber;
        }

        public void SetObjectsPositionsInGameArea(List<IMovable> objects)
        {
            foreach (var obj in objects)
            {
                var key =
                    $"{(int)(obj.Position.X / (GameAreaSize / CellSize + this.gameAreaNumber))};{(int)(obj.Position.Y / (GameAreaSize / CellSize + this.gameAreaNumber))}";

                if (!this.gameObjectsInAreaCollection.ContainsKey(key))
                {
                    this.gameObjectsInAreaCollection.TryAdd(key, new List<IMovable>() { obj });
                }
                else
                {
                    this.gameObjectsInAreaCollection[key].Add(obj);
                }
            }
        }

        public IEnumerable<IMovable> GetCollisionGameAreaCollection()
        {
            //return this.gameObjectsInAreaCollection.Values.Where(objects => objects.Count > 1).SelectMany(objects => objects);

            foreach (var objects in this.gameObjectsInAreaCollection.Values)
            {
                if (objects.Count > 1) // object collision logic here - now all from locality in collision
                {
                    foreach (var obj in objects)
                    {
                        yield return obj;
                    }
                }
            }
        }
    }
}
