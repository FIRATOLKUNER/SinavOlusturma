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
    public class ListeleModel : PageModel
    {
        private readonly SinavOlusturma.DBContexts.SinavOlusturmaContext _context;

        public ListeleModel(SinavOlusturma.DBContexts.SinavOlusturmaContext context)
        {
            _context = context;
        }

        public IList<Questions> Questions { get;set; }

        public async Task OnGetAsync()
        {
            Questions = await _context.Questions.ToListAsync();
        }
    }
}
