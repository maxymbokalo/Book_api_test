using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using book_api_task.Domain.Interfaces;
using book_api_task.Domain.Core;

namespace book_api_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookRepository repository;
        public BooksController(IBookRepository repo)
        {
            repository = repo;
        }
        // GET api/books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return repository.GetBookList();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            Book book = repository.GetBook(id);
            if (book == null)
                return NotFound();
            return new ObjectResult(book);

        }

        // POST api/books
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            repository.Create(book);
            return Ok(book);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            

            repository.Update(id,book);
            return Ok(book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book book = repository.GetBookList().FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            repository.Delete(id);
            return Ok(book);
        }
    }
}
