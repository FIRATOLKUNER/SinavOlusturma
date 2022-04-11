using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Pages
{
    public class IndexModel : PageModel
    {       

        private readonly SinavOlusturma.DBContexts.SinavOlusturmaContext _context;

        public IndexModel(SinavOlusturma.DBContexts.SinavOlusturmaContext context)
        {
            _context = context;
        }

        public Users Users { get; set; }

        public void OnGet()
        {
            ViewData["Hata"] = "Please type your user name and password";
            ViewData["Giris"] = "Yok";
        }

        [BindProperty]
        public LoginData loginData { get; set; }

        public async Task OnPostAsync()
        {
            
            if (ModelState.IsValid)
            {
                var kayitvarmi = await _context.Users.FirstOrDefaultAsync(m => (m.User_Name == loginData.Username) && (m.User_Password == loginData.Password));
                if (kayitvarmi == null)
                {
                    ViewData["Hata"] = "User name or user password wrong!";
                    ViewData["Giris"] = "Yok";                    
                }
                else
                {
                    //RedirectToPage("Index");
                    ViewData["Giris"] = "Var";
                }

            }
            else
            {
                ViewData["Hata"] = "Error! Please reconnect this page...!";
                ViewData["Giris"] = "Yok";
            }
        }

        public class LoginData
        {
            public string Username { get; set; }

            public string Password { get; set; }
        }


    }
}
