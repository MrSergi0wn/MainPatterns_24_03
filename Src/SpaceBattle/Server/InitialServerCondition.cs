using System.Collections.Concurrent;
using SpaceBattle.Commands;
using SpaceBattle.Exceptions;

namespace SpaceBattle.Server
{
    public class InitialServerCondition : CurrentConditionOfServer
    {
        public InitialServerCondition(GameServer gameServer) : base(gameServer)
        {
        }

        public override void Handle(KeyValuePair<int, ConcurrentQueue<ICommand>> game)
        {
            try
            {
                game.Value.TryDequeue(out var command);
                command?.Execute();
            }
            catch (HardStopMultitreadException)
            {
                gameServer.HardStopped = true;
            }
            catch (SoftStopMultitreadException)
            {
                gameServer.SoftStopped = true;
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
