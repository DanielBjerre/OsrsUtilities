using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsrsUtilities.GroupService.Persistence.Entities;
public class Character(Guid groupId, string characterId)
{
    public string CharacterId { get; set; } = characterId;
    public Guid GroupId { get; set; } = groupId;


    public Group? Group { get; set; }
}

internal class CharacterEntityConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasKey(c => new { c.GroupId, c.CharacterId });
    }
}
