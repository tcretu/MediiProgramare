using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tudor_Cretu_Lab22.Models;

namespace Tudor_Cretu_Lab22.Data
{
    public class Tudor_Cretu_Lab22Context : DbContext
    {
        public Tudor_Cretu_Lab22Context (DbContextOptions<Tudor_Cretu_Lab22Context> options)
            : base(options)
        {
        }

        public DbSet<Tudor_Cretu_Lab22.Models.Book> Book { get; set; } = default!;

        public DbSet<Tudor_Cretu_Lab22.Models.Publisher>? Publisher { get; set; }

        public DbSet<Tudor_Cretu_Lab22.Models.Author>? Author { get; set; }
    }
}
