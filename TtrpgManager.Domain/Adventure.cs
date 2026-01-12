namespace TtrpgManager.Domain;

public class Adventure
{
    public Guid Id { get; }
    public Guid CampaignId { get; }

    public string Title { get; private set; }
    public string? Summary { get; private set; }
    public string? CoverImageId { get; private set; }

    public Adventure(Guid campaignId, string title, string? summary = null)
    {
        if (campaignId == Guid.Empty)
            throw new ArgumentException("CampaignId is required.", nameof(campaignId));

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Scenario title is required.", nameof(title));

        Id = Guid.NewGuid();
        CampaignId = campaignId;
        Title = title;
        Summary = summary;
    }

    public void Rename(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Scenario title is required.", nameof(newTitle));

        Title = newTitle;
    }

    public void ChangeSummary(string? summary)
    {
        Summary = summary;
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

