using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Application.Services;
using MotorcycleStore.Infrastructure.Data;
using MotorcycleStore.Infrastructure.Repositories;
using MotorcycleStore.UI.WinForms.Forms;

namespace MotorcycleStore.UI.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            AllocConsole();
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                    services.AddDbContext<StoreDbContext>(options =>
                        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
                    services.AddDbContext<StoreDbContext>(options =>
                        options.UseMySql(
                            connectionString,
                            ServerVersion.AutoDetect(connectionString),
                            b => b.MigrationsAssembly("MotorcycleStore.Infrastructure") 

                        )
                    );

                    services.AddScoped<CustomerRepository>();
                    services.AddScoped<SupplierRepository>();
                    services.AddScoped<EmployeeRepository>();
                    services.AddScoped<ProductRepository>();
                    services.AddScoped<OrderRepository>();
                    services.AddScoped<InventoryRepository>();

                    services.AddScoped<ICustomerService, CustomerService>();
                    services.AddScoped<ISupplierService, SupplierService>();
                    services.AddScoped<IEmployeeService, EmployeeService>();
                    services.AddScoped<IOrderService, OrderService>();
                    services.AddScoped<IInventoryService, InventoryService>();
                    services.AddScoped<IProductService, ProductService>();

                    services.AddScoped<Form1>();
                    services.AddScoped<LoginForm>();
                    services.AddScoped<ProductsForm>();
                })
                .Build();


            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
                db.Database.EnsureCreated();
            }

            //System.Windows.Forms.Application.Run(new Form1());
            var mainForm = host.Services.GetRequiredService<ProductsForm>();
            System.Windows.Forms.Application.Run(mainForm);
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
    }
}

