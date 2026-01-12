namespace TtrpgManager.Domain;

public class Campaign: EntityWithCoverImage
{
    public string? Description { get; private set; }

    public Campaign(string name, string? description = null): base(name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Campaign name is required, it cannot be null or empty.", nameof(name));
        }

        Description = description;
    }

    /// <summary>
    /// Updates the description associated with the current instance.
    /// </summary>
    /// <param name="newDescription">The new description to assign. Can be <see langword="null"/> to clear the existing description.</param>
    public void UpdateDescription(string? newDescription)
    {
        Description = newDescription;
    }
}
