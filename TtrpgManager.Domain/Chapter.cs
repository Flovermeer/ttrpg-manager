namespace TtrpgManager.Domain;

public class Chapter: BaseEntity
{
    public Guid AdventureId { get; }

    public int Order { get; private set; }
    public string? Content { get; private set; }

    public Chapter(Guid adventureId, string name, int order, string? content = null): base(name)
    {
        if (adventureId == Guid.Empty)
        {
            throw new ArgumentException("AdventureId is required.", nameof(adventureId));
        }

        if (order <= 0)
        {
            throw new ArgumentException("Chapter order must be >= 1.", nameof(order));
        }

        AdventureId = adventureId;
        Order = order;
        Content = content;
    }

    public void Reorder(int newOrder)
    {
        if (newOrder <= 0)
            throw new ArgumentException("Chapter order must be >= 1.", nameof(newOrder));

        Order = newOrder;
    }

    public void ChangeContent(string? content) => Content = content;
}
