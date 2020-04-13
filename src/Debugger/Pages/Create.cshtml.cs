using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Debugger.Models;
using Debugger.Services;

namespace Debugger.Pages.Builds
{
    public class CreateModel : PageModel
    {
        private readonly BuildService _context;

        public CreateModel(BuildService context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Build Build { get; set; } = new Build { Status = BuildStatus.Success };

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AddBuild(Build);

            return RedirectToPage("./Index");
        }
    }
}
