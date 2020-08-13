using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SalesDetails.App.Customers.Queries.GetCustomerList;
using SalesDetails.App.Interface;
using Microsoft.EntityFrameworkCore;
using SalesDetails.Data;
using SalesDetails.App.Employees.Queries;
using SalesDetails.App.Employees.Queries.GetEmployeeList;
using SalesDetails.App.Products.Queries.GetProductList;
using SalesDetails.App.Sales.Queries.GetSaleDetail;
using SalesDetails.App.Sales.Queries.GetSalesList;
using SalesDetails.App.Sales.Commands.CreateSale;
using SalesDetails.CommonFeatures.Dates;
using SalesDetails.Inventory;
using SalesDetails.App.Sales.Commands.CreateSale.Factory;

namespace SalesDetails.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<IDatabaseService, DatabaseService>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("SalesConnex"))
                    .EnableSensitiveDataLogging()
            );

            services.AddScoped<IGetCustomerListQuery, GetCustomerListQuery>();
            services.AddScoped<IGetEmployeeListQuery, GetEmployeeListQuery>();
            services.AddScoped<IGetProductListQuery, GetProductListQuery>();
            services.AddScoped<IGetSaleDetailQuery, GetSaleDetailQuery>();
            services.AddScoped<IGetSalesListQuery, GetSalesListQuery>();
            services.AddScoped<ICreateSaleCommand, CreateSaleCommand>();
            services.AddScoped<IDateService, DateService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<ISaleFactory, SaleFactory>();
                        
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Sales Details API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // In ASP.NET Core 3.0 `env` will be an IWebHostingEnvironment, not IHostingEnvironment.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Sales Details API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
