using BookList.Models;
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
    }
}
