using ManagerLayer.Interface;
using ModelsLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo userRepo;

        public UserManager(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public bool LoginUser(Login loginModel)
        {
            return this.userRepo.LoginUser(loginModel);
        }

        public Register RegisterUser(Register registrationModel)
        {
            return this.userRepo.RegisterUser(registrationModel);
        }

    }
}
