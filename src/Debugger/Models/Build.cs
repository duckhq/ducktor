using System;

namespace Debugger.Models
{
    public sealed class Build
    {
        public int Id { get; set; }
        public BuildStatus Status { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Finished { get; set; }
    }
}
