using BookLib.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BookLib.Controllers.Repository
{
    public class BorrowBookRepository
    {
        private BookLibDbContext dbContext;
        public BorrowBookRepository(BookLibDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Add(BorrowBook borrowBook)
        {
            try
            {
                dbContext.BorrowBooks.Add(borrowBook);
                dbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public ICollection<BorrowBook> GetAll()
        {
            return dbContext.BorrowBooks.ToList();
        }
    }
}