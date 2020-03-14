using BookLib.Controllers.Repository;
using BookLib.Models;
using System.Web.Mvc;

namespace BookLib.Controllers
{
    public class BorrowBookController : Controller
    {
        private readonly BorrowBookRepository borrowBookRepository;

        public BorrowBookController()
        {
            borrowBookRepository = new BorrowBookRepository(new BookLibDbContext());
        }
        // GET: BorrowBook/Add
        [System.Web.Mvc.HttpPost]
        public JsonResult Add(BorrowBook borrowBook)
        {
            if (ModelState.IsValid && borrowBookRepository.Add(borrowBook))
                return Json(new { Success = true , responseText = "successful" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = false, responseText = "already borrowed" }, JsonRequestBehavior.AllowGet);
        }
    }
}