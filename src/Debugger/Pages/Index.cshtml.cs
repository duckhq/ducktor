using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Debugger.Models;
using Debugger.Services;

namespace Debugger.Pages.Builds
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
