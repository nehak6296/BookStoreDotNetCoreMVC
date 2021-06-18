using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IUserManager
    {
        Register RegisterUser(Register registrationModel);
        bool LoginUser(Login loginModel);


    }
}
