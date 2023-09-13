using Azure;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo bookRepo;
        public BookController(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var book = await bookRepo.GetAllBooksAsync();
            return Ok(book);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int Id)
        {
            var book = await bookRepo.GetBookByIdAsync(Id);
            return Ok(book);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookModel)
        {
            var id = await bookRepo.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById), new { id = id, controller = "books" }, id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel, [FromRoute] int id)
        {
            await bookRepo.UpdateBookAsync(id, bookModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] BookModel bookModel, [FromRoute] int id)
        {
            await bookRepo.UpdateBookPatchAsync(id, bookModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await bookRepo.DeleteBookAsync(id);
            return Ok();
        }
    }
}
