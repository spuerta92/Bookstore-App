using Bookstore.Models;
using System.Collections.Generic;

namespace Bookstore.Repository
{
    public interface IBookstoreRepository
    {
        public IEnumerable<Book> GetBooks();
        public Book GetBook(ulong id);
        public void InsertBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(ulong id);
        public int BookCount();
    }
}
