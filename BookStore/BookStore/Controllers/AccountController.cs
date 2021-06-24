using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.IdentityModel.Tokens;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IConfiguration configuration;
        public AccountController(IUserManager userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            //ViewBag.xyz = "Success";
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login,string returnUrl)
        {
            try
            {
                if (IsValid(login))
                {
                    var jwtToken = GenerateJwtToken(login);
                    //FormsAuthentication.SetAuthCookie(login.Email, false);
                    // ViewBag.Message = "User Logged in successfully";                   
                    //return RedirectToAction("GetAllBooks","Books");

                    var identity = new ClaimsIdentity(new[] {
                                     new Claim(ClaimTypes.Email, login.Email)
                    }, 
                    CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var Login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return Redirect(jwtToken);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsValid(Login login)
        {
            return this.userManager.LoginUser(login);
        }
        [HttpPost]
        public ActionResult Register(Register register)
        {
            try
            {
                var result = this.userManager.RegisterUser(register);
                ViewBag.Message = "User registered successfully";
                
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                return ViewBag.Message = "Unsuccessfull";
            }
        }

        private string GenerateJwtToken(Login user)
        {
            var securityKey = Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]);

            var claims = new Claim[] {
                    new Claim(ClaimTypes.Email,user.Email),

                };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
              configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(7),
              signingCredentials: credentials);


            //var jwtToken = new JwtToken
            //{
            //    RefreshToken = new RefreshTokenGenerator().GenerateRefreshToken(32),
            //    Token = new JwtSecurityTokenHandler().WriteToken(token)
            //};

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
