namespace TtrpgManager.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; private set;  }
    public string Name { get; private set; } = null!;

    protected BaseEntity() { } // needed for EF Core

    protected BaseEntity(string name)
    {
        Id = Guid.NewGuid();

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required.", nameof(name));
        }
        
        Name = name;
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

