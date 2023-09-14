using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BookStoreAPI.Repositories
{
    public class BookRepo : IBookRepo
    {
        private readonly BookStoreContext Bookcontext;
        private readonly IMapper _mapper;
        public BookRepo(BookStoreContext context, IMapper mapper)
        {
            _mapper = mapper;
            Bookcontext = context;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await Bookcontext.BooksStore.ToListAsync();
            //Select(c => new BookModel()
            /*{
                id = c.id,
                title = c.title,
                description = c.description
            }).ToListAsync();*/
            return _mapper.Map<List<BookModel>>(records);    
        }
        public async Task<BookModel> GetBookByIdAsync(int Id)
        {
            /*var records = await Bookcontext.BooksStore.Where(c=>c.id==Id).Select(c => 
                new BookModel()
            {
                id = c.id,
                title = c.title,
                description = c.description
            }).FirstOrDefaultAsync();

            return records;*/
            var book = await Bookcontext.BooksStore.FindAsync(Id);
            return _mapper.Map<BookModel>(book);
        }
        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                title = bookModel.title,
                description = bookModel.description
            };
            await Bookcontext.BooksStore.AddAsync(book);
            await Bookcontext.SaveChangesAsync();
            return book.id;
        }
        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            var book = new Books()
            {
                id = bookId,
                title = bookModel.title,
                description = bookModel.description
            };
            Bookcontext.BooksStore.Update(book);
            await Bookcontext.SaveChangesAsync();
        }
        public async Task UpdateBookPatchAsync(int bookId, BookModel bookModel)
        {
            var book = await Bookcontext.BooksStore.FindAsync(bookId);
            if (book != null)
            {
                Bookcontext.BooksStore.Add(book);
                await Bookcontext.SaveChangesAsync();
            }
        }
        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books() { id = bookId };

            Bookcontext.BooksStore.Remove(book);

            await Bookcontext.SaveChangesAsync();
        }
    }
}
