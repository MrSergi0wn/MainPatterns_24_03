using System.Collections.Concurrent;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Components.Actions;
using SpaceBattle.Ioc;
using SpaceBattle.MessageBus;

namespace SpaceBattle.Server
{
    public class GameServer
    {
        public Dictionary<int, ConcurrentQueue<ICommand>> Games { get; }

        private readonly IIoc ioc;

        public List<IMovable> CollisionObjects { get; } = new();

        public CurrentConditionOfServer serverCondition { get; set; }

        public bool SoftStopped { get; set; }

        public bool HardStopped { get; set; }

        public GameServer(IIoc ioc, ConcurrentQueue<ICommand> gameCommands)
        {
            this.Games = new Dictionary<int, ConcurrentQueue<ICommand>> { { 1, gameCommands } };
            this.ioc = ioc;
            this.serverCondition = new InitialServerCondition(this);
        }

        public void RunMultithreadCommands()
        {
            foreach (var game in Games)
            {
                Task.Factory.StartNew(() =>
                {
                    while (!HardStopped || (!SoftStopped && !game.Value.Any()))
                    {
                        serverCondition.Handle(game);
                    }
                });
            }
        }

        public void MessageReceived(GameMessage message)
        {
            new InterpretCommand(message, Games, ioc)
                .Execute();
        }
    }
}
