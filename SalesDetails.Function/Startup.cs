using System;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using SalesDetails.App.Customers.Queries.GetCustomerList;
using SalesDetails.App.Employees.Queries;
using SalesDetails.App.Employees.Queries.GetEmployeeList;
using SalesDetails.App.Interface;
using SalesDetails.App.Products.Queries.GetProductList;
using SalesDetails.App.Sales.Commands.CreateSale;
using SalesDetails.App.Sales.Commands.CreateSale.Factory;
using SalesDetails.App.Sales.Queries.GetSaleDetail;
using SalesDetails.App.Sales.Queries.GetSalesList;
using SalesDetails.CommonFeatures.Dates;
using SalesDetails.Data;
using SalesDetails.Function;
using SalesDetails.Inventory;

[assembly: WebJobsStartup(typeof(StartUp))]
namespace SalesDetails.Function
{
    public class StartUp : IWebJobsStartup
    {
        private readonly ILogger _logger;

        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StartUp"/> class.
        /// </summary>
        public StartUp()
        {
            var functionLoggerFactory = new LoggerFactory();
            _logger = functionLoggerFactory.CreateLogger(LogCategories.CreateFunctionUserCategory("Common"));
        }

        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(IWebJobsBuilder builder)
        {
            ApplyConfiguration(builder, builder.Services);
            ConfigureServices(builder.Services);
        }

        private void ApplyConfiguration(IWebJobsBuilder builder, IServiceCollection services)
        {
            //Get the current config and merge it into a new ConfigurationBuilder to keep the old settings
            var configurationBuilder = new ConfigurationBuilder();
            var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(IConfiguration));
            if (descriptor?.ImplementationInstance is IConfigurationRoot configuration)
            {
                configurationBuilder.AddConfiguration(configuration);
            }

            configurationBuilder
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            
            var builtConfig = configurationBuilder.Build();
                       
            builder.Services.Replace(ServiceDescriptor.Singleton(typeof(IConfiguration), builtConfig));

            var tempServiceProvider = builder.Services.BuildServiceProvider();
            ApplyConfiguration(tempServiceProvider.GetRequiredService<IConfiguration>());
        }

        /// <summary>
        /// Applies the configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void ApplyConfiguration(IConfiguration config)
        {
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (Configuration == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(Configuration)} must be set before performing {nameof(ConfigureServices)}");
            }

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

        }
    }
}

