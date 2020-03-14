using BookLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLib.Controllers.Repository
{
    public class BorrowBookRepository
    {
        private readonly BookLibDbContext dbContext;
        public BorrowBookRepository(BookLibDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Add(BorrowBook borrowBook)
        {
            try
            {
                dbContext.BorrowBooks.Add(borrowBook);
                var book = dbContext.Books.SingleOrDefault(b => b.Id == borrowBook.BookId);
                if (book != null)
                {
                    if (book.AvailableNumber > 0)
                        book.AvailableNumber--;
                    else
                        return false;
                }
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
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