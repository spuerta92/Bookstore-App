using System;

namespace Bookstore.Models
{
    public class Book
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public CategoryEnum Category { get; set; }
        public decimal Price { get; set; }
        public Guid Tag { get; set; }
        public DateTime Added { get; set; }
    }
}
