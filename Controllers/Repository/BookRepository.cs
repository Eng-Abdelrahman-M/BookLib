using BookLib.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BookLib.Controllers.Repository
{
    public class BookRepository
    {
        private BookLibDbContext dbContext;
        public BookRepository(BookLibDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<Book> GetAll()
        {
            return dbContext.Books.ToList();
        }

        public bool Delete(int id)
        {
            var item = dbContext.Books.Include(b => b.Id == id);
            dbContext.Entry(item).State = EntityState.Deleted;
            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            
        }

        public bool Add(Book book)
        {
            try
            {
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        


    }
}