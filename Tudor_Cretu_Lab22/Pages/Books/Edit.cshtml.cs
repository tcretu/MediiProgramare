using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tudor_Cretu_Lab22.Data;
using Tudor_Cretu_Lab22.Models;

namespace Tudor_Cretu_Lab22.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Tudor_Cretu_Lab22.Data.Tudor_Cretu_Lab22Context _context;

        public EditModel(Tudor_Cretu_Lab22.Data.Tudor_Cretu_Lab22Context context)
        {
            _context = context;
        }

        [BindProperty] public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }


            Book = await _context.Book
                .Include(b => b.Publisher).Include(b => b.Author)
                .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Book);

            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
                "PublisherName");
            ViewData["AuthorID"] = new SelectList(
                _context.Set<Author>()
                    .Select(a => new
                    {
                        a.ID,
                        FullName = a.FirstName + " " + a.LastName
                    }),
                "ID",
                "FullName"
            );

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
            selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            //se va include Author conform cu sarcina de la lab 2
            var bookToUpdate = await _context.Book
                .Include(i => i.Publisher).Include(i => i.Author)
                .Include(i => i.BookCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }

            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Book>(
                    bookToUpdate,
                    "Book",
                    i => i.Title, i => i.Author,
                    i => i.Price, i => i.PublishingDate, i => i.PublisherID, i => i.AuthorID))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();
        }
    }

}

