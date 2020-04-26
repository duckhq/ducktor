using Microsoft.EntityFrameworkCore;

namespace Ducktor.Data
{
    public class DebuggerContext : DbContext
    {
        public DebuggerContext (DbContextOptions<DebuggerContext> options)
            : base(options)
        {
        }

        public DbSet<Ducktor.Models.Build> Build { get; set; }
    }
}
