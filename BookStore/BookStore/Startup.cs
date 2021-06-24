using ManagerLayer.Interface;
using ManagerLayer.Manager;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository;
using System.Text;

namespace BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllersWithViews();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IUserRepo, UserRepo>();

            services.AddTransient<IBookManager, BookManager>();
            services.AddTransient<IBookRepo, BookRepo>();

            services.AddTransient<ICartManager, CartManager>();
            services.AddTransient<ICartRepo, CartRepo>();

            services.AddTransient<IWishListManager, WishListManager>();
            services.AddTransient<IWishListRepo, WishListRepo>();

            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepo, CustomerRepo>();

            services.AddTransient<IOrdersManager, OrdersManager>();
            services.AddTransient<IOrdersRepo, OrdersRepo>();
            //services.ConfigureApplicationCookie(config =>
            //{
            //    config.LoginPath = configuration["Application:LoginPath"];
            //});
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            var key = Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuers = new string[] { Configuration["Jwt:Issuer"] },
                    ValidAudiences = new string[] { Configuration["Jwt:Issuer"] },
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true
                };
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
