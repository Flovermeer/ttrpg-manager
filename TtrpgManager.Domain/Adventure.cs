namespace TtrpgManager.Domain;

public class Adventure: EntityWithCoverImage
{

    public Guid CampaignId { get; }
    public string? Summary { get; private set; }

    public Adventure(Guid campaignId, string name, string? summary = null): base(name)
    {
        if (campaignId == Guid.Empty)
        {
            throw new ArgumentException("CampaignId is required.", nameof(campaignId));
        }
        CampaignId = campaignId;
        Summary = summary;
    }

    /// <summary>
    /// Updates the summary text associated with the current instance.
    /// </summary>
    /// <param name="summary">The new summary text to assign. Can be <see langword="null"/> to clear the existing description.</param>
    public void UpdateSummary(string? summary)
    {
        Summary = summary;
    }
}

