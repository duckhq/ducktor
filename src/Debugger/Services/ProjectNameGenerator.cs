using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debugger.Services
{
    public sealed class ProjectNameGenerator
    {
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        public string[] _projects = new string[]
        {
            "Astro", "Bender", "Cauldron",
            "Durango", "Edison", "Firefly",
            "Hades", "Jupiter", "Lobster",
            "Mercury", "Nitro", "Orion",
            "Pluto", "Quantum", "Rhinestone",
            "Seawolf", "Topaz", "Voyager",
            "Whistler", "Xena", "Yoda",
            "Zeus"
        };

        public string GetProjectName()
        {
            return _projects[_random.Next(0, _projects.Length)];
        }
    }
}
