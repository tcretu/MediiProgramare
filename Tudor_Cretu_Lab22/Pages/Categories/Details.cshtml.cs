using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tudor_Cretu_Lab22.Data;
using Tudor_Cretu_Lab22.Models;

namespace Tudor_Cretu_Lab22.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Tudor_Cretu_Lab22.Data.Tudor_Cretu_Lab22Context _context;

        public DetailsModel(Tudor_Cretu_Lab22.Data.Tudor_Cretu_Lab22Context context)
        {
            _context = context;
        }

      public Category Category { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
