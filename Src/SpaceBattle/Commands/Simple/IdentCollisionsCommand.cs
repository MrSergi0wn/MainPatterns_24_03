using SpaceBattle.Actions;
using SpaceBattle.Collisions;
using SpaceBattle.Server;

namespace SpaceBattle.Commands.Simple
{
    public class IdentCollisionsCommand : ICommand
    {
        private readonly GameServer gameServer;

        private readonly List<IMovable> gameObjects;

        private readonly int gameAreaNumber;

        public IdentCollisionsCommand(GameServer gameServer, List<IMovable> gameObjects, int gameAreaNumber = 1)
        {
            this.gameServer = gameServer;
            this.gameObjects = gameObjects;
            this.gameAreaNumber = gameAreaNumber;
        }

        public void Execute()
        {
            for (var i = 0; i < this.gameAreaNumber; i++)
            {
                var spaceGameArea = new SpaceGameArea(i);
                spaceGameArea.SetObjectsPositionsInGameArea(this.gameObjects);

                foreach (var collisionObject in spaceGameArea.GetCollisionGameAreaCollection())
                {
                    if (this.gameServer.CollisionObjects.All(obj => obj != collisionObject))
                    {
                        this.gameServer.CollisionObjects.Add(collisionObject);
                    }
                }
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
