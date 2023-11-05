using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tudor_Cretu_Lab22.Data;
using Tudor_Cretu_Lab22.Models;

namespace Tudor_Cretu_Lab22.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Tudor_Cretu_Lab22.Data.Tudor_Cretu_Lab22Context _context;

        public IndexModel(Tudor_Cretu_Lab22.Data.Tudor_Cretu_Lab22Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                Author = await _context.Author.ToListAsync();
            }
        }
    }
}
