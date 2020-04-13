using Microsoft.EntityFrameworkCore;

namespace Debugger.Data
{
    public class DebuggerContext : DbContext
    {
        public DebuggerContext (DbContextOptions<DebuggerContext> options)
            : base(options)
        {
        }

        public DbSet<Debugger.Models.Build> Build { get; set; }
    }
}
