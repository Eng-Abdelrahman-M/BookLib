using BookLib.Models;
using System.Data.Entity;

namespace BookLib.Controllers
{
    public class BookLibDbContext : DbContext
    {
        public BookLibDbContext() : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BorrowBook>().HasKey(bb => new { bb.BookId, bb.BorrowerId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<BorrowBook> BorrowBooks { get; set; }
    }
}