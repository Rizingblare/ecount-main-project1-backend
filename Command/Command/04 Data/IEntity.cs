namespace Command
{
    public interface IEntityKey
    {

    }
    public interface IEntity<TKey>
        where TKey : IEntityKey
    {
        TKey Key { get; }
    }
}
