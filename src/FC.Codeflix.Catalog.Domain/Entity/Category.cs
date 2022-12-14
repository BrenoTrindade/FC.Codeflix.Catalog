using FC.Codeflix.Catalog.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace FC.Codeflix.Catalog.Domain.Entity;
public class Category
{

    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }

    public Category(string name, string description, bool isActive = true)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = isActive;
        CreatedAt = DateTime.Now;
        Validate();
    }
    public void Activate()
    {
        IsActive = true;
        Validate();
    }
    public void Deactivate()
    {
        IsActive = false;
        Validate();
    }

    public void Update(string name, string? description = null)
    {
        Name = name;
        Description = description ?? Description;
        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
           throw new EntityValidationException($"{nameof(Name)} should not be empty or null");
        if (Description is null)
            throw new EntityValidationException($"{nameof(Description)} should not be empty or null");
        if(Name.Length < 3)
            throw new EntityValidationException($"{nameof(Name)} should be at least 3 characters long");
        if (Name.Length > 255)
            throw new EntityValidationException($"{nameof(Name)} should be less or equal 255 characters long");
        if (Description.Length > 10000)
            throw new EntityValidationException($"{nameof(Description)} should be less or equal 10000 characters long");
    }
}
