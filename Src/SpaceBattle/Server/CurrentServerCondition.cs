using System.Collections.Concurrent;
using SpaceBattle.Commands;

namespace SpaceBattle.Server
{
    public abstract class CurrentServerCondition
    {
        protected readonly GameServer gameServer;

        protected CurrentServerCondition(GameServer gameServer)
        {
            this.gameServer = gameServer;
        }

        public abstract void Handle(KeyValuePair<int, ConcurrentQueue<ICommand>> game);
    }
}
