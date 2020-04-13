using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Debugger.Models;

namespace Debugger.Pages.Builds
{
    public class DeleteModel : PageModel
    {
        private readonly Debugger.Data.DebuggerContext _context;

        public DeleteModel(Debugger.Data.DebuggerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Build Build { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Build = await _context.Build.FirstOrDefaultAsync(m => m.Id == id);

            if (Build == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Build = await _context.Build.FindAsync(id);

            if (Build != null)
            {
                _context.Build.Remove(Build);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
