﻿using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRepo
    {       
        List<Books> GetAllBooks();
    }

}
