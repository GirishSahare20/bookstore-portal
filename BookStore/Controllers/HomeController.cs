using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using BookGatewayService;
using KCN.ViewModels;
using BookStore.Infastructure;
namespace KCN.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepository;
       

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {

            ViewBag.Message = TempData["Message"];
            return View();
        }
        [HttpGet]
        public JsonResult GetBookDetails()
        {
            var books = _bookRepository.GetAllBooks().Select(x => new BookViewModel
            {
                BookID = x.BookID,
            Name = x.Name,
            ISBN = x.ISBN,
            Author = x.Author,
            Description = x.Description,
            Photo = x.Photo,
            Price = x.Price,
            Stock = x.Stock,
            SId = ApiSecurity.EnryptString( x.BookID.ToString())
            });
         
            return Json(books, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetSearchBooksDetails(SearchBookViewModel oSearch)
        {
           // var books = _bookRepository.GetAllBooks().AsEnumerable();
            var books = from r in _bookRepository.GetAllBooks()
                                            where
                                            (r.Name == oSearch.Name || oSearch.Name.Length == 0)
                                            && (r.ISBN == oSearch.ISBN || oSearch.ISBN.Length == 0)
                                            && (r.Description == oSearch.Description || oSearch.Description.Length == 0)
                                            && (r.Author == oSearch.Author || oSearch.Author.Length == 0)
                                            select r;

            return Json(books, JsonRequestBehavior.AllowGet);
        }
       
        [HttpGet]
        [MyAuthorize]
        [Authorize]
        public ActionResult ViewDetail(int id)
        {
            var books = _bookRepository.GetBook(id);           

            return View(books);
        }
        [Authorize]
        [HttpPost]
        public ActionResult ViewDetail(FormCollection formCollection)
        {
            try
            {
                PurchaseDetail purchaseDetail = new PurchaseDetail();
                // Retrieve form data using form collection
                purchaseDetail.BookID = Convert.ToInt32(formCollection["BookID"]);
                purchaseDetail.Amount = Convert.ToDouble(formCollection["Price"]);
                purchaseDetail.transactionstatus = "Success";
                purchaseDetail.transactionType = formCollection["PayType"];
                purchaseDetail.PurchaseID = 0;
                purchaseDetail.PurchasedOn = DateTime.Now;
                purchaseDetail.Userid = 1;
                BookGateway.BookGatewayFactory bookFactory = new BookGateway.BookGatewayFactory();
                IBookGateway bookGateway = bookFactory.GetBookGateway(purchaseDetail.transactionType);

                PurchaseDetail opurchaseDetail = bookGateway.SavePaymentDetails(purchaseDetail);
                TempData["Message"] = "<span style='color:blue;'>Book purchased successfully</span>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "<span style='color:red;'>" + ex.Message+ "</span>";


            }

            return View();
        }
       
    }
}