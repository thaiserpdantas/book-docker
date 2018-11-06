using Microsoft.EntityFrameworkCore;

namespace Book
{
    public class BookRepository : DbContext
    {
        public BookRepository(DbContextOptions<BookRepository> options)
            : base(options)
        {
        }
        public DbSet<Book> BookItems { get; set; }
    }
}
