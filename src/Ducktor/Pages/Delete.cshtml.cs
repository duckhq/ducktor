using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ducktor.Models;
using Ducktor.Services;

namespace Ducktor.Pages.Builds
{
    public class DeleteModel : PageModel
    {
        private readonly BuildService _context;

        public DeleteModel(BuildService context)
        {
            _context = context;
        }

        [BindProperty]
        public Build Build { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Build = _context.GetBuild(id.Value);
            if (Build == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _context.DeleteBuild(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
