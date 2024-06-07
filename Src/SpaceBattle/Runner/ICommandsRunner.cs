using SpaceBattle.Commands;

namespace SpaceBattle.Runner;

public interface ICommandsRunner
{
    void AddCommandToTheQueue(ICommand command);

    int GetQueueSize();

    void ExecuteQueue();
}