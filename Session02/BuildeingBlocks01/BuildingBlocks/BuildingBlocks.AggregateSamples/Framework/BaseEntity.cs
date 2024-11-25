namespace BuildingBlocks.AggregateSamples.Framework;
public abstract class BaseEntity<TId>(TId id)
{
    public TId Id { get; set; } = id;
}
