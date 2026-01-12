namespace TtrpgManager.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; }
    public string Name { get; private set; }

    protected BaseEntity(string Name)
    {
        Id = Guid.NewGuid();

        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Name is required.", nameof(Name));
        }
        this.Name = Name;
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Name is required.", nameof(newName));
        }
        Name = newName;
    }

}

