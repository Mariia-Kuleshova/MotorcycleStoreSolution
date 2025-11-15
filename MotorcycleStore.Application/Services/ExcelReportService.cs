using MotorcycleStore.Domain;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.Reports;
using System.Collections.Generic;
using System.IO;

namespace MotorcycleStore.Application.Services
{
    public class ExcelReportService
    {
        public void ExportProductsToExcel(IEnumerable<Product> products)
        {
            // создаём папку для отчётов, если её ещё нет
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MotorcycleReports");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"ProductsReport_{DateTime.Now:yyyyMMdd_HHmm}.xls");

            using (var excel = new RepExcel())
            {
                excel.CreateNewBook(filePath);

                int row = 1;

                // заголовки таблицы
                excel.SetValue("Saturn Data", "A" + row, "ID", "string", true);
                excel.SetValue("Saturn Data", "B" + row, "Name", "string", true);
                excel.SetValue("Saturn Data", "C" + row, "Price", "string", true);
                excel.SetValue("Saturn Data", "D" + row, "Supplier", "string", true);
                row++;

                // данные
                foreach (var p in products)
                {
                    excel.SetValue("Saturn Data", "A" + row, p.Id.ToString(), "string");
                    excel.SetValue("Saturn Data", "B" + row, p.Name, "string");
                    excel.SetValue("Saturn Data", "C" + row, p.Price.ToString("F2"), "double");
                    //excel.SetValue("Saturn Data", "D" + row, p.Supplier?.Name ?? "", "string");
                    row++;
                }

                excel.Save(filePath);
                excel.CloseBook();
            }
        }
    }
}
