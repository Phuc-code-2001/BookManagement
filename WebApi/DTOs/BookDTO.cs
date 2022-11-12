namespace WebApi.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TypeResponse Type { get; set; }
        public decimal Price { get; set; } // Giá bìa sách
        public decimal Advanced { get; set; } // Tiền phải trả để mua đứt bản quyền
        public decimal Royalty { get; set; } // Tiền phải trả khi nhượng quyền
        public decimal YTDSales { get; set; } = 0; // Tiền bán sách từ đầu năm
        public string Note { get; set; }
        public PublisherDTO Publisher { get; set; }

        public string PublishedDate { get; set; }
    }
}
