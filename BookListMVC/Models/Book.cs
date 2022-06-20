using System.ComponentModel.DataAnnotations;

namespace BookListMVC.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        public string Description { get; set;  }

        [Required]
        public string ISBN { get; set; }

    }
}
