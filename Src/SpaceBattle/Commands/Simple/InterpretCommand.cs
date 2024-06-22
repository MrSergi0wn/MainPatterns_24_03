using System.Collections.Concurrent;
using System.Numerics;
using SpaceBattle.Actions;
using SpaceBattle.MessageBus;

namespace SpaceBattle.Commands.Simple
{
    public class InterpretCommand : ICommand
    {
        private readonly GameMessage message;

        private readonly Dictionary<int, ConcurrentQueue<ICommand>> games;

        private readonly IResolvable ioc;

        public InterpretCommand(GameMessage message, Dictionary<int, ConcurrentQueue<ICommand>> games, IResolvable ioc)
        {
            this.message = message;
            this.games = games;
            this.ioc = ioc;
        }

        public void Execute()
        {
            var gameQueue = games[message.GameId];

            var gameObject = ioc.Resolve<IMovable>(message.GameObjectId!);

            var velocity = float.Parse(message.ArgsJson!);

            var command = ioc.Resolve<ICommand>(message.GameOperationId!, gameObject, new Vector2(velocity));

            gameQueue.Enqueue(command);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
