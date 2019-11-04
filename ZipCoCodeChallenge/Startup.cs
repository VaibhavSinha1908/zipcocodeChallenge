using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZipCoCodeChallenge.Interfaces;
using ZipCoCodeChallenge.Models;
using ZipCoCodeChallenge.Services;

namespace ZipCoCodeChallenge
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
            //var server = Configuration["DBServer"] ?? "ms-sql-server";
            //var port = Configuration["DBPort"] ?? "1433";
            //var user = Configuration["DBUser"] ?? "sa";
            //var password = Configuration["DBPassword"] ?? "ZipPay@1234";
            //var database = Configuration["Database"] ?? "ZipPay";

            var connStr = Configuration["Data:ConnectionString"];

            //string connStr = $"server = {server}, {port}; Initial Catalog = {database}; User ID={user}; Password = {password} ";




            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();


            //Use Local SQL to test changes.
            //services.AddDbContextPool<ZipPayContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("ZipCo"));
            //});


            services.AddDbContextPool<ZipPayContext>(options =>
            {
                options.UseSqlServer(connStr);
            });



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            PrepPopulateDb.PrePopulate(app);
        }
    }
}
