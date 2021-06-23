using ManagerLayer.Interface;
using Microsoft.AspNetCore.Http;
using ModelsLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Manager
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepo bookRepository;

        public BookManager(IBookRepo bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public List<Books> GetAllBooks()
        {
            return this.bookRepository.GetAllBooks();
        }

        public bool UploadImage(int BookId, IFormFile image)
        {
            return this.bookRepository.UploadImage(BookId, image);
        }
    }
}
