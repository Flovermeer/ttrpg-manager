namespace TtrpgManager.Domain;

public abstract class EntityWithCoverImage: BaseEntity
{
    public string? CoverImageId { get; private set; }

    protected EntityWithCoverImage() { } // needed for EF Core

    protected EntityWithCoverImage(string name) : base(name)
    {
    }

    public void SetCoverImage(string imageId)
    {
        if (string.IsNullOrWhiteSpace(imageId)) 
        {
            throw new ArgumentException("Image id is required.", nameof(imageId));
        }
        CoverImageId = imageId;
    }

    public void RemoveCoverImage()
    {
        CoverImageId = null;
    }

}

