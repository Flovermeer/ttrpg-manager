namespace TtrpgManager.Domain;

public class Campaign
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? CoverImageId { get; private set; }

    public Campaign(string name, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Campaign name is required, it cannot be null or empty.", nameof(name));
        }

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Campaign name is required, it cannot be null or empty.", nameof(newName));
        }
        Name = newName;
    }

    public void UpdateDescription(string? newDescription)
    {
        Description = newDescription;
    }

    public void SetCoverImage(string imageId)
    {
        CoverImageId = imageId;
    }

    public void RemoveCoverImage()
    {
        CoverImageId = null;
    }
}
