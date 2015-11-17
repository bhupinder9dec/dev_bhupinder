using BooksMvcApp.Models;
using BooksMvcApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksMvcApp.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/
        private IBookServices _bookServices;
        public BooksController(IBookServices bookService)
        {
            _bookServices = bookService;
        }
        public ActionResult Index()
        {

            return View(_bookServices.GetAllBooks());
           
        }

        public ActionResult AddEditBook(int Id=0)
        {
            Book book = new Book();
            if (Id == 0)
            {
                ModelState.Clear();
                book = null;
            }
            else
            {
                book = _bookServices.GetBookById(Id);
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult AddEditBook(Book book)
        {
            Boolean res=false;
            if (book.BookId == 0)
            {
                res=_bookServices.Add(book);
            }
            else
            {
                res = _bookServices.Edit(book);
            }
            if (res == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            //return View();
        }

        public ActionResult DeleteBook(int Id = 0)
        {
            Book book = new Book();
            if (Id == 0)
            {
                ModelState.Clear();
                book = null;
            }
            else
            {
                book = _bookServices.GetBookById(Id);
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult DeleteBook(Book book)
        {
            Boolean res = false;
            if (book.BookId != 0)
            {
                res = _bookServices.Delete(book);
            }
            if (res == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            //return View();
        }

    }
}
