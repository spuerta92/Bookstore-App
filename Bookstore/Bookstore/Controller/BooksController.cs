using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Controller
{
    [ApiController]
    [Route("Books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookstoreRepository _repository;

        public BooksController(IBookstoreRepository repository)
        {
            _repository = repository;
        }

        // GET /books/{id}
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(ulong id)
        {
            if(_repository.GetBook(id) is null)
            {
                return NotFound();
            }
            return _repository.GetBook(id);
        }

        // GET /books
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _repository.GetBooks();
        }

        // POST /books
        [HttpPost]
        public ActionResult<Book> InsertBook(Book newbook)
        {
            //var id = _repository.GetBooks()
            //    .OrderByDescending(x => x.Id)
            //    .FirstOrDefault().Id;

            var book = new Book()
            {
                Id = (ulong)_repository.BookCount() + 1,
                Name = newbook.Name,
                Author = newbook.Author,
                Price = newbook.Price,
                Category = newbook.Category,
                Added = newbook.Added,
                Tag = newbook.Tag
            };
            _repository.InsertBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT /books
        [HttpPut("{id}")]
        public ActionResult UpdateBook(ulong id, Book newbook)
        {
            var book = _repository.GetBook(id);
            if (book is null)
            {
                return NotFound();
            }
            book.Name = newbook.Name;
            book.Author = newbook.Author;
            book.Price = newbook.Price;
            book.Category = newbook.Category;
            book.Added = book.Added;
            book.Tag = book.Tag;
            _repository.UpdateBook(book);

            return NoContent();

        }

        // DELETE /books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(ulong id)
        {
            if(_repository.GetBook(id) is null)
            {
                return NotFound();
            }
            _repository.DeleteBook(id);
            return NoContent();
        }
    }
}
