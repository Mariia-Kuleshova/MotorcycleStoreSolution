using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Application.Services;
using MotorcycleStore.Infrastructure.Data;
using MotorcycleStore.Infrastructure.Repositories;
using MotorcycleStore.UI.WinForms.Forms;
using MotorcycleStore.UI.WinForms.Forms.UseControls;
using System;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms
{
    internal static class Program
    {

        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {
           
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                    services.AddDbContextFactory<StoreDbContext>(options =>
                        options.UseMySql(
                            connectionString,
                            ServerVersion.AutoDetect(connectionString),
                            b => b.MigrationsAssembly("MotorcycleStore.Infrastructure")
                        )
                    );

                   
                    services.AddTransient<CustomerRepository>();
                    services.AddTransient<SupplierRepository>();
                    services.AddTransient<EmployeeRepository>();
                    services.AddTransient<ProductRepository>();
                    services.AddTransient<OrderRepository>();
                    services.AddTransient<InventoryRepository>();

                    
                    services.AddTransient<ICustomerService, CustomerService>();
                    services.AddTransient<ISupplierService, SupplierService>();
                    services.AddTransient<IEmployeeService, EmployeeService>();
                    services.AddTransient<IOrderService, OrderService>();
                    services.AddTransient<IInventoryService, InventoryService>();
                    services.AddTransient<IProductService, ProductService>();
                    services.AddTransient<OrderItemService>(); 

                    services.AddSingleton<NavigationService>();

                   
                    services.AddTransient<ReceiptGenerator>();
                    services.AddTransient<SalesReportGenerator>();

                    
                    services.AddTransient<Form1>();
                    services.AddTransient<LoginForm>();
                    services.AddTransient<MainForm>();

                    services.AddTransient<OrdersUserControl>();
                    services.AddTransient<ReportsUserControl>();
                })
                .Build();

            ServiceProvider = host.Services;

         
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
                db.Database.EnsureCreated();
            }

     
            var mainForm = host.Services.GetRequiredService<LoginForm>();
            System.Windows.Forms.Application.Run(mainForm);
        }

        
    }
}

