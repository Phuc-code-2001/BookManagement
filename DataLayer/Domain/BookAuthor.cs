using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    [Table("BookAuthors")]

    public class BookAuthor
    {
        [Key]
        public int Id { get; set; }

        // Relationship
        [Required]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [Required]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Book Book { get; set; }


        // Extentions Properties
        [Required]
        public int AuthorOrder { get; set; } = 0;
        [Required]
        public float RoyaltyPercentage { get; set; }

    }
}
