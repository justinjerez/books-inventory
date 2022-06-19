using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            // Retreive book from the database
            var book = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);

            // If book is null return error message
            if (book == null)
            {
                return Json(new { success = false, message = "Error while deleting book." });
            }

            // If book is not null remove book from the database
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Book deleted successfully." });
        }
    }
}
