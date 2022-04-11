using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SinavOlusturma.DBContexts;

namespace SinavOlusturma.Pages
{
    public class CreateModel : PageModel
    {
        private readonly SinavOlusturma.DBContexts.SinavOlusturmaContext _context;

        public CreateModel(SinavOlusturma.DBContexts.SinavOlusturmaContext context)
        {
            _context = context;
        }

        public SelectList post_titles { get; set; }

        public IActionResult OnGet()
        {
            string adres = "https://www.wired.com/";
            WebRequest istek = HttpWebRequest.Create(adres);
            WebResponse cevap;
            cevap = istek.GetResponse();
            StreamReader donenBilgiler = new StreamReader(cevap.GetResponseStream());
            string gelen = donenBilgiler.ReadToEnd();
            int IndexBaslangici = gelen.IndexOf(">Trending Stories<") + 18; 
            int IndexBitisi = gelen.Substring(IndexBaslangici).IndexOf(">Longreads<");

            gelen = gelen.Substring(IndexBaslangici, IndexBitisi);

            var lpost_titles = new List<String>();
            string[] contents = new string[6];

            int contentindex = 1;
            string contentsstr = ",";
            while (gelen.IndexOf("data-testid=\"SummaryItemHed\">") > 0)
            {
                IndexBaslangici = gelen.IndexOf("data-testid=\"SummaryItemHed\">") + 29;
                gelen = gelen.Substring(IndexBaslangici, gelen.Length - IndexBaslangici);
                lpost_titles.Add(gelen.Substring(0, gelen.IndexOf("<")));
                IndexBaslangici = gelen.IndexOf("--extra-spacing\">") + 17;
                IndexBitisi = gelen.Substring(IndexBaslangici).IndexOf("<");
                contents[contentindex] = gelen.Substring(IndexBaslangici, IndexBitisi);
                contentsstr = contentsstr + contents[contentindex] + ",";
                contentindex += 1;
            }          

            post_titles = new SelectList(lpost_titles);

            ViewData["result"] = contents;

            return Page();
        }

        [BindProperty]
        public Questions Questions { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
                Questions.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                _context.Questions.Add(Questions);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Create");
        }
    }
}
