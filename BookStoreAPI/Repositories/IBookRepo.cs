using Azure;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface IBookRepo
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int Id);
        Task<int>AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync(int bookId, BookModel bookModel);
        Task UpdateBookPatchAsync(int bookId, BookModel bookModel);
        Task DeleteBookAsync(int bookId);
    }
}