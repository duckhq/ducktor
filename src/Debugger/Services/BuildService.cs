using Debugger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Debugger.Services
{
    public sealed class BuildService
    {
        private int _counter;
        private readonly List<Build> _builds;

        public BuildService()
        {
            _builds = new List<Build>();
        }

        public IList<Build> GetBuilds()
        {
            return _builds;
        }

        public void AddBuild(Build build)
        {
            build.Id = Interlocked.Increment(ref _counter);
            build.Started = DateTime.Now;
            if (build.Status != BuildStatus.Queued && build.Status != BuildStatus.Skipped)
            {
                build.Finished = DateTime.Now;
            }

            _builds.Add(build);
        }

        public void UpdateBuild(Build build)
        {
            var other = GetBuild(build.Id);
            if (other != null)
            {
                other.Status = build.Status;
                if (other.Status == BuildStatus.Queued || other.Status == BuildStatus.Skipped)
                {
                    other.Finished = null;
                } 
                else
                {
                    other.Finished = DateTime.Now;
                }
            }
        }

        public Build GetBuild(int id)
        {
            return _builds.FirstOrDefault(x => x.Id == id);
        }
    }
}
