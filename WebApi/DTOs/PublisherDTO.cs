namespace WebApi.DTOs
{
    public class PublisherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Optional
        public TypeResponse City { get; set; }
        public TypeResponse State { get; set; }
        public TypeResponse Country { get; set; }
    }
}
