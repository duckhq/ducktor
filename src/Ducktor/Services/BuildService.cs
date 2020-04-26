using Ducktor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Ducktor.Services
{
    public sealed class BuildService
    {
        private int _counter;
        private readonly List<Build> _builds;
        private readonly ProjectNameGenerator _generator;

        public BuildService(ProjectNameGenerator generator)
        {
            _builds = new List<Build>();
            _generator = generator;
        }

        public IList<Build> GetBuilds()
        {
            return _builds;
        }

        public Build GetBuild(int id)
        {
            return _builds.FirstOrDefault(x => x.Id == id);
        }

        public void AddBuild(Build build)
        {
            build.Id = Interlocked.Increment(ref _counter);
            build.Started = DateTime.Now;
            build.Project = _generator.GetProjectName();
            build.Definition = "Debug";
            build.Branch = "master";

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

        public void DeleteBuild(int id)
        {
            _builds.RemoveAll(x => x.Id == id);
        }
    }
}
