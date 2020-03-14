using BookLib.Controllers.Repository;
using BookLib.Models;
using System.Web.Mvc;

namespace BookLib.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookRepository bookRepository;


        public HomeController()
        {
            bookRepository = new BookRepository(new BookLibDbContext());
        }
        public ActionResult Index()
        {
            return View(bookRepository.GetAll());
        }


        [HttpPost]
        public JsonResult Add(Book book)
        {
            if (ModelState.IsValid && bookRepository.Add(book))
                return Json(new {Success = true}, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);

        }

        //[HttpPost]
        //public ActionResult Borrow(BorrowBook borrowBook)
        //{
        //    if (ModelState.IsValid && borrowBookRepository.Add(borrowBook))
        //        return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        //    else
        //        return Json(new { Success = false }, JsonRequestBehavior.AllowGet);

        //}

        


    }
}