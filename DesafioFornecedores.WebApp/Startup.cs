using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Infra.Data;
using DesafioFornecedores.Infra.Repository;
using DesafioFornecedores.Infra.Services;
using DesafioFornecedores.WebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFornecedores.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        /*public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }*/
        public Startup(IHostEnvironment hostEnvironment){
            var builder = new ConfigurationBuilder()
                              .SetBasePath(hostEnvironment.ContentRootPath)
                              .AddJsonFile("appsettings.json",true,true)
                              .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json",true,true)
                              .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup));
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ProdForneContext>(options => options.UseSqlServer(
                    Configuration.GetConnectionString("ConnectionDevForne")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<ProdForneContext>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProductsRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddAuthorization(options => {
                options.AddPolicy("AdminOnly", policy => policy.RequireUserName("Admin@nttdata.com"));
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
