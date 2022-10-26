using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string Title { get; set; }
        [Required]
        public BookType Type { get; set; }
        [Required]
        public decimal Price { get; set; } // Giá bìa sách
        [Required]
        public decimal Advanced { get; set; } // Tiền phải trả để mua đứt bản quyền
        [Required]
        public decimal Royalty { get; set; } // Tiền phải trả khi nhượng quyền

        public decimal YTDSales { get; set; } = 0; // Tiền bán sách từ đầu năm

        public string Note { get; set; }

		// Relationship
		[ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public DateTime PublishedDate { get; set; }

    }

    
}
