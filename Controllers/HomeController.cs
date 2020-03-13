using BookLib.Controllers.Repository;
using BookLib.Models;
using System.Web.Mvc;

namespace BookLib.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookRepository bookRepository;
        private readonly BorrowerRepository borrowerRepository;
        private readonly BorrowBookRepository borrowBookRepository;


        public HomeController()
        {
            BookLibDbContext context = new BookLibDbContext();
            bookRepository = new BookRepository(context);
            borrowerRepository = new BorrowerRepository(context);
            borrowBookRepository=new BorrowBookRepository(context);
        }
        public ActionResult Index()
        {
            return View(bookRepository.GetAll());
        }


        [HttpPost]
        public ActionResult Add(Book book)
        {
            if (ModelState.IsValid && bookRepository.Add(book))
                return Json(new {Success = true}, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Borrow(BorrowBook borrowBook)
        {
            if (ModelState.IsValid && borrowBookRepository.Add(borrowBook))
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);

        }

        


    }
}