using MainPatterns.SpaceBattle.Commands;

namespace MainPatterns.SpaceBattle.Runner;

public interface ICommandsRunner
{
    void AddCommandToTheQueue(ICommand command);

    int GetQueueSize();

    void ExecuteQueue();
}