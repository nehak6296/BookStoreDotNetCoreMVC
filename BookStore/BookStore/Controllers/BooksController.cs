using ManagerLayer.Interface;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]       
        public IActionResult UploadImage(int BookId, IFormFile image)
        {
            try
            {
                //var imageUpload = CloudImageLink(image);
                bool result = this.booksManager.UploadImage(BookId, image);
                if (result == true)
                {
                    return Json(new { status = true, Message = "Image added ", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "image not added " });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}