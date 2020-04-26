using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ducktor.Models;
using Ducktor.Services;

namespace Ducktor.Pages.Builds
{
    public class IndexModel : PageModel
    {
        private readonly BuildService _context;

        public IList<Build> Builds { get; set; }

        public IndexModel(BuildService context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Builds = _context.GetBuilds();
        }
    }
}
