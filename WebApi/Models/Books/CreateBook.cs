using DataLayer.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Books
{
    public class CreateBook
    {
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

        public string Note { get; set; }

        // Relationship
        public int PublisherId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; } = DateTime.Now;
    }
}
