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
    public class DetailsModel : PageModel
    {
        private readonly SinavOlusturma.DBContexts.SinavOlusturmaContext _context;

        public DetailsModel(SinavOlusturma.DBContexts.SinavOlusturmaContext context)
        {
            _context = context;
        }

        String[] Answers = new string[5];

        public Questions Questions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Questions = await _context.Questions.FirstOrDefaultAsync(m => m.IsComplete == "False");

            if (Questions == null)
            {
                return RedirectToPage("./Error");
            }
            else
            {
                Answers[1] = Questions.Question1_Answer;
                Answers[2] = Questions.Question2_Answer;
                Answers[3] = Questions.Question3_Answer;
                Answers[4] = Questions.Question4_Answer;
            }
            ViewData["check"] = Answers;
            return Page();
        }
    }
}
