using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookList.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db; // Getting the database connection

        // Passing the database connection to the page through dependency injection
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            // Find the book
            var book = await _db.Book.FindAsync(id);

            // Check if the book was fouund
            if(book == null)
            {
                return NotFound();
            }

            // Remove the book from the database
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            // Return to back to the list
            return RedirectToAction("Index");
        }
    }
}
