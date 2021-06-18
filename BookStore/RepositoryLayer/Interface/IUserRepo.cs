using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRepo
    {
        bool LoginUser(Login loginModel);
        Register RegisterUser(Register registrationModel);
    }
}
