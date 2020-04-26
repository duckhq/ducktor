using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ducktor.Models;
using Ducktor.Services;

namespace Ducktor.Pages.Builds
{
    public class EditModel : PageModel
    {
        private readonly BuildService _context;

        [BindProperty]
        public Build Build { get; set; }

        public EditModel(BuildService context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UpdateBuild(Build);

            return RedirectToPage("./Index");
        }
    }
}
