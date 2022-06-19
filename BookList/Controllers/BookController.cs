using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public IActionResult GetAll()
        {
            return Json(new { data =_db.Book.ToList() });
        }
    }
}
