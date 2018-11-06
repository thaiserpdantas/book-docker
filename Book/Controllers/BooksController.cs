using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public BooksController(BookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        [HttpGet]
        public List<Book> Get()
        {
            return _bookRepository.Books.ToList();
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookRepository.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _bookRepository.Add(book);
            _bookRepository.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var book = _bookRepository.Books.FirstOrDefault(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
