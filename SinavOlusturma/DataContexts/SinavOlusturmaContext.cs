using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.DBContexts
{
    public class SinavOlusturmaContext : DbContext
    {
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Users> Users { get; set; }

        public SinavOlusturmaContext(DbContextOptions<SinavOlusturmaContext> options) 
            : base(options)
        {

        }

    }


     
}
