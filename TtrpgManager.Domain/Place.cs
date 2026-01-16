namespace TtrpgManager.Domain;

public class Place: EntityWithCoverImage
{
    public Guid? CampaignId { get; private set; }
    public Guid? AdventureId { get; private set; }
    public string? Description { get; private set; }
    public List<Npc> Npcs { get; private set;  }

    protected Place() { } // EF

    public Place(Guid? campaignId, Guid? adventureId, string name, string? description = null, List<Npc>? npcs = null): base(name)
    {
        if ((campaignId == null && adventureId == null) || (campaignId != null && adventureId != null))
        {
            throw new ArgumentException("Place must belong to either a Campaign or an Adventure (exactly one).");
        }
        CampaignId = campaignId;
        AdventureId = adventureId;
        Description = description;
        Npcs = npcs ?? new();

    }
    /// <summary>
    /// Updates the description associated with the current instance.
    /// </summary>
    /// <param name="newDescription">The new description to assign. Can be <see langword="null"/> to clear the existing description.</param>
    public void UpdateDescription(string? newDescription)
    {
        Description = newDescription;
    }

    /// <summary>
    /// Adds the specified NPC to the collection of NPCs roaming in this Place.
    /// </summary>
    /// <param name="npc">The NPC to add to the collection. Cannot be null.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="npc"/> is null.</exception>
    public void AddNpc(Npc npc)
    {
        if (npc == null)
        {
            throw new ArgumentNullException(nameof(npc), "NPC cannot be null.");
        }
        Npcs.Add(npc);
    }

    /// <summary>
    /// Removes the specified NPC from the collection of NPCs.
    /// </summary>
    /// <param name="npc">The NPC to remove from the collection. Cannot be null.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="npc"/> is null.</exception>
    public void RemoveNpc(Npc npc)
    {
        if (npc == null)
        {
            throw new ArgumentNullException(nameof(npc), "NPC cannot be null.");
        }
        Npcs.Remove(npc);
    }
}

