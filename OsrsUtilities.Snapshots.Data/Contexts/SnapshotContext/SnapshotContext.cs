using Microsoft.EntityFrameworkCore;

namespace OsrsUtilities.Snapshots.Data.Contexts.SnapshotContext;
public class SnapshotContext(DbContextOptions<SnapshotContext> options) : DbContext(options)
{
}
