using Microsoft.AspNetCore.Http;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IBookManager
    {
        List<Books> GetAllBooks();
        bool UploadImage(int BookId, IFormFile image);
    }
}
