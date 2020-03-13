using System.Web.Mvc;

namespace BookLib.Controllers.Repository
{
    public class BorrowerController : Controller
    {
        private BorrowerRepository borrowerRepository;

        public BorrowerController()
        {
            borrowerRepository = new BorrowerRepository(new BookLibDbContext());
        }
        //// GET: Borrower
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult GetAll()
        {
            var borrowers = borrowerRepository.GetAll();
            if (ModelState.IsValid)
                return Json(borrowers, JsonRequestBehavior.AllowGet);
            else
                return Json(borrowers, JsonRequestBehavior.AllowGet);

        }
    }
}