using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Repository
{
    public class BookstoreInMemoryRepository : IBookstoreRepository
    {
        private readonly List<Book> books = new List<Book>()
        {
            new Book() { Id = 1, Name = "The Hobbit", Author = "J. R. R. Tolkien", Category = CategoryEnum.Horror, Price = 32.99m, Added = DateTime.Today, Tag = Guid.NewGuid() },
            new Book() { Id = 2, Name = "The Lord Of The Rings", Author = "J. R. R. Tolkien", Category = CategoryEnum.Romance, Price = 12.99m, Added = DateTime.Today, Tag = Guid.NewGuid()  },
            new Book() { Id = 3, Name = "Harry Potter", Author = "J. K. Rowling", Category = CategoryEnum.Thriller, Price = 24.99m, Added = DateTime.Today, Tag = Guid.NewGuid()  },
            new Book() { Id = 4, Name = "Twilight", Author = "Stephenie Meyer", Category = CategoryEnum.Manga, Price = 11.99m, Added = DateTime.Today, Tag = Guid.NewGuid()  },
            new Book() { Id = 5, Name = "Hunger Games", Author = "Suzanne Collins", Category = CategoryEnum.Food, Price = 7.99m, Added = DateTime.Today, Tag = Guid.NewGuid()  },
            new Book() { Id = 6, Name = "The Mortal Instruments", Author = "Cassandra Clare", Category = CategoryEnum.Fantasy, Price = 15.99m, Added = DateTime.Today, Tag = Guid.NewGuid()  },
        };

        public Book GetBook(ulong id)
        {
            return books.Where(book => book.Id == id).SingleOrDefault();
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public void InsertBook(Book book)
        {
            books.Add(book);
        }

        public void UpdateBook(Book newbook)
        {
            var index = books.FindIndex(book => book.Id == newbook.Id);
            books[index] = newbook;
        }

        public void DeleteBook(ulong id)
        {
            var index = books.FindIndex(book => book.Id == id);
            books.RemoveAt(index);
        }

        public int BookCount() => books.Count;
    }
}
