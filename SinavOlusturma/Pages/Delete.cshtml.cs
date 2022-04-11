using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinavOlusturma.DBContexts;

namespace SinavOlusturma.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly SinavOlusturma.DBContexts.SinavOlusturmaContext _context;

        public DeleteModel(SinavOlusturma.DBContexts.SinavOlusturmaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Questions Questions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Questions = await _context.Questions.FirstOrDefaultAsync(m => m.Id == id);

            if (Questions == null)
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

            Questions = await _context.Questions.FindAsync(id);

            if (Questions != null)
            {
                _context.Questions.Remove(Questions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Listele");
        }
    }
}
