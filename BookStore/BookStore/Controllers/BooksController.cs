using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookManager booksManager;
        public BooksController(IBookManager booksManager)
        {
            this.booksManager = booksManager;
        }
        //GET: Books
        public ActionResult GetAllBooks()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult GetAllBooks(Books book)
        {
            try
            {
                var result = this.booksManager.GetAllBooks();
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception)
            {
                return ViewBag.Message = "sucessfully";
            }
        }

    }
}
