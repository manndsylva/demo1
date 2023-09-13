using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace BookStoreAPI.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> opts) : base(opts)
        {
        }
        public DbSet<Books> BooksStore { get; set; }

    }
}
