using BookLib.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BookLib.Controllers.Repository
{
    public class BorrowerRepository
    {
        private BookLibDbContext dbContext;
        public BorrowerRepository(BookLibDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Add(Borrower borrower)
        {
            try
            {
                dbContext.Borrowers.Add(borrower);
                dbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public ICollection<Borrower> GetAll()
        {
            return dbContext.Borrowers.ToList();
        }



    }
}