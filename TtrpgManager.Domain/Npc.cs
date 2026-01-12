using TtrpgManager.Domain;

public class Npc: EntityWithCoverImage
{
    public Guid? CampaignId { get; private set; }
    public Guid? AdventureId { get; private set; }
    public int Age { get; private set; }
    public string Occupation { get; private set; }
    public bool IsFriendly { get; private set; }


    public Npc(Guid? campaignId, Guid? adventureId, string name, int age, string occupation, bool isFriendly = true) : base(name)
    {
        if ((campaignId == null && adventureId == null) || (campaignId != null && adventureId != null))
        {
            throw new ArgumentException("Npc must belong to either a Campaign or an Adventure (exactly one).");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("NPC name is required.", nameof(name));
        }

        CampaignId = campaignId;
        AdventureId = adventureId;
        Age = age;
        Occupation = occupation;
        IsFriendly = isFriendly;
    }

    /// <summary>
    /// Updates the relation status to indicate whether the Npc is friendly.
    /// </summary>
    /// <param name="isFriendly">A value indicating whether the relation should be set as friendly. Set to <see langword="true"/> to mark the
    /// relation as friendly; otherwise, <see langword="false"/>.</param>
    public void UpdateRelation(bool isFriendly)
    {
        IsFriendly = isFriendly;
    }

    /// <summary>
    /// Updates the occupation of the Npc.
    /// </summary>
    /// <param name="occupation">The new occupation value to assign. Cannot be null, empty, or consist only of white-space characters.</param>
    /// <exception cref="ArgumentException">Thrown if the occupation parameter is null, empty, or consists only of white-space characters.</exception>
    public void UpdateOccupation(string occupation)
    {
        if (string.IsNullOrWhiteSpace(occupation))
        {
            throw new ArgumentException("Occupation cannot be null or empty.", nameof(occupation));
        }
        Occupation = occupation;
    }

    /// <summary>
    /// Updates the age value of the Npc.
    /// </summary>
    /// <param name="age">The new age to set. Must be zero or greater.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="age"/> is less than zero.</exception>
    public void UpdateAge(int age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Age cannot be negative.", nameof(age));
        }
        Age = age;
    }
}

