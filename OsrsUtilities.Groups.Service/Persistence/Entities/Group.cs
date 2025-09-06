using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsrsUtilities.GroupService.Persistence.Entities;
public class Group(string name)
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = name;

    public List<Character> Characters { get; set; } = [];
}

internal class GroupEntityConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder
            .HasIndex(g => g.Name)
            .IsUnique();
        
        builder
            .Property(g => g.Name)
            .HasMaxLength(25);
    }
}
