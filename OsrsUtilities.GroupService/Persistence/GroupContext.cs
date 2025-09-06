using Microsoft.EntityFrameworkCore;
using OsrsUtilities.GroupService.Persistence.Entities;

namespace OsrsUtilities.GroupService.Persistence;
public class GroupContext(DbContextOptions<GroupContext> options) : DbContext(options)
{
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Character> Characters => Set<Character>();
}
