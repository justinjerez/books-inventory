using Microsoft.EntityFrameworkCore;

namespace BookList.Models
{
    /**
     * 
     */
    public class ApplicationDbContext : DbContext
    {
        /**
         *
         */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        /**
         *  Database model Book
         */
        public DbSet<Book> Books { get; set; }
    }
}
