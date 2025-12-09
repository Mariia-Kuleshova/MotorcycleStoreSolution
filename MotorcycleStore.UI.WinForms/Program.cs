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
            //AllocConsole();
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

                    // ? ¬»ѕ–ј¬Ћ≈ЌЌя 2: Repositories - Transient зам≥сть Scoped
                    services.AddTransient<CustomerRepository>();
                    services.AddTransient<SupplierRepository>();
                    services.AddTransient<EmployeeRepository>();
                    services.AddTransient<ProductRepository>();
                    services.AddTransient<OrderRepository>();
                    services.AddTransient<InventoryRepository>();

                    // ? ¬»ѕ–ј¬Ћ≈ЌЌя 3: Services - Transient зам≥сть Scoped
                    services.AddTransient<ICustomerService, CustomerService>();
                    services.AddTransient<ISupplierService, SupplierService>();
                    services.AddTransient<IEmployeeService, EmployeeService>();
                    services.AddTransient<IOrderService, OrderService>();
                    services.AddTransient<IInventoryService, InventoryService>();
                    services.AddTransient<IProductService, ProductService>();
                    services.AddTransient<OrderItemService>(); // ? ƒодано €кщо використовуЇтьс€

                    // ? Navigation Service залишаЇтьс€ Singleton
                    services.AddSingleton<NavigationService>();

                    // ? ¬»ѕ–ј¬Ћ≈ЌЌя 4: ƒодано generators дл€ зв≥т≥в
                    services.AddTransient<ReceiptGenerator>();
                    services.AddTransient<SalesReportGenerator>();

                    // ? ¬»ѕ–ј¬Ћ≈ЌЌя 5: Forms - Transient зам≥сть Scoped
                    services.AddTransient<Form1>();
                    services.AddTransient<LoginForm>();
                    services.AddTransient<MainForm>();

                    services.AddTransient<OrdersUserControl>();
                    services.AddTransient<ReportsUserControl>();
                })
                .Build();

            ServiceProvider = host.Services;

            // ? ≤н≥ц≥ал≥зац≥€ бази даних
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
                db.Database.EnsureCreated();
            }

            // ? «апуск застосунку
            var mainForm = host.Services.GetRequiredService<LoginForm>();
            System.Windows.Forms.Application.Run(mainForm);
        }

        //[System.Runtime.InteropServices.DllImport("kernel32.dll")]
        //private static extern bool AllocConsole();
    }
}

