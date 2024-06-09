namespace SpaceBattle.MessageBus
{
    public class GameMessage
    {
        public int GameId { get; init; }

        public string? GameObjectId { get; init; }

        public string? GameOperationId { get; init; }

        public string? ArgsJson { get; init; }
    }
}
