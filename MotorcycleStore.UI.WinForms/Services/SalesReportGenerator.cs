using MotorcycleStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace MotorcycleStore.Application.Services
{
    public class SalesReportGenerator
    {
        private List<Order> _orders;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _currentY;
        private const int LineHeight = 20;
        private const int StartX = 50;

        public void GenerateReport(List<Order> orders, DateTime startDate, DateTime endDate)
        {
            _orders = orders;
            _startDate = startDate;
            _endDate = endDate;
            _currentY = 50;

            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = true; 
            printDoc.PrintPage += PrintReport;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 1000,
                Height = 700
            };

            previewDialog.ShowDialog();
        }

        private void PrintReport(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 10);
            Font smallFont = new Font("Arial", 9);

            int pageWidth = e.PageBounds.Width - 100;

            string title = "ЗВІТ ПРО ПРОДАЖІ";
            SizeF titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, Brushes.Black,
                StartX + (pageWidth - titleSize.Width) / 2, _currentY);
            _currentY += 40;

            string period = $"За період: {_startDate:dd.MM.yyyy} - {_endDate:dd.MM.yyyy}";
            SizeF periodSize = g.MeasureString(period, headerFont);
            g.DrawString(period, headerFont, Brushes.Black,
                StartX + (pageWidth - periodSize.Width) / 2, _currentY);
            _currentY += 35;

            DrawLine(g, pageWidth);

            _currentY += 10;
            g.DrawString("Загальна статистика:", subHeaderFont, Brushes.Black, StartX, _currentY);
            _currentY += 30;

            int ordersCount = _orders.Count;
            decimal totalRevenue = _orders.Sum(o => o.TotalAmount);
            decimal averageCheck = ordersCount > 0 ? totalRevenue / ordersCount : 0;
            int totalProducts = _orders.Sum(o => o.OrderItems.Sum(i => i.Quantity));

            g.DrawString($"• Кількість замовлень: {ordersCount}", regularFont, Brushes.Black, StartX + 20, _currentY);
            _currentY += LineHeight;

            g.DrawString($"• Продано одиниць товару: {totalProducts}", regularFont, Brushes.Black, StartX + 20, _currentY);
            _currentY += LineHeight;

            g.DrawString($"• Загальна сума продажів: {totalRevenue:N2} грн", regularFont, Brushes.Black, StartX + 20, _currentY);
            _currentY += LineHeight;

            g.DrawString($"• Середній чек: {averageCheck:N2} грн", regularFont, Brushes.Black, StartX + 20, _currentY);
            _currentY += 30;

            DrawLine(g, pageWidth);

            _currentY += 10;
            g.DrawString("Статистика по статусах:", subHeaderFont, Brushes.Black, StartX, _currentY);
            _currentY += 25;

            var statusGroups = _orders.GroupBy(o => o.Status)
                .Select(g => new { Status = g.Key, Count = g.Count(), Total = g.Sum(o => o.TotalAmount) })
                .OrderByDescending(x => x.Count);

            foreach (var status in statusGroups)
            {
                g.DrawString($"• {GetStatusName(status.Status)}: {status.Count} замовлень ({status.Total:N0} грн)",
                    regularFont, Brushes.Black, StartX + 20, _currentY);
                _currentY += LineHeight;
            }

            _currentY += 10;
            DrawLine(g, pageWidth);

            _currentY += 10;
            g.DrawString("Топ-5 найпопулярніших товарів:", subHeaderFont, Brushes.Black, StartX, _currentY);
            _currentY += 25;

            var topProducts = _orders
                .SelectMany(o => o.OrderItems)
                .GroupBy(i => i.Product.Name)
                .Select(g => new
                {
                    ProductName = g.Key,
                    Quantity = g.Sum(i => i.Quantity),
                    Revenue = g.Sum(i => i.TotalPrice)
                })
                .OrderByDescending(x => x.Quantity)
                .Take(5);

            int rank = 1;
            foreach (var product in topProducts)
            {
                g.DrawString($"{rank}. {product.ProductName} - {product.Quantity} шт ({product.Revenue:N0} грн)",
                    regularFont, Brushes.Black, StartX + 20, _currentY);
                _currentY += LineHeight;
                rank++;
            }

            _currentY += 10;
            DrawLine(g, pageWidth);

            _currentY += 10;
            g.DrawString("Статистика по працівниках:", subHeaderFont, Brushes.Black, StartX, _currentY);
            _currentY += 25;

            var employeeStats = _orders
                .GroupBy(o => new { o.Employee.FirstName, o.Employee.LastName })
                .Select(g => new
                {
                    EmployeeName = $"{g.Key.FirstName} {g.Key.LastName}",
                    OrdersCount = g.Count(),
                    TotalSales = g.Sum(o => o.TotalAmount)
                })
                .OrderByDescending(x => x.TotalSales);

            foreach (var emp in employeeStats)
            {
                g.DrawString($"• {emp.EmployeeName}: {emp.OrdersCount} замовлень ({emp.TotalSales:N0} грн)",
                    regularFont, Brushes.Black, StartX + 20, _currentY);
                _currentY += LineHeight;
            }

            _currentY += 10;
            DrawLine(g, pageWidth);

            _currentY += 10;
            g.DrawString("Деталі замовлень:", subHeaderFont, Brushes.Black, StartX, _currentY);
            _currentY += 25;

            g.DrawString("Дата", regularFont, Brushes.Black, StartX, _currentY);
            g.DrawString("№ Чеку", regularFont, Brushes.Black, StartX + 100, _currentY);
            g.DrawString("Клієнт", regularFont, Brushes.Black, StartX + 180, _currentY);
            g.DrawString("Товарів", regularFont, Brushes.Black, StartX + 350, _currentY);
            g.DrawString("Сума", regularFont, Brushes.Black, StartX + 450, _currentY);
            g.DrawString("Статус", regularFont, Brushes.Black, StartX + 570, _currentY);
            g.DrawString("Працівник", regularFont, Brushes.Black, StartX + 680, _currentY);
            _currentY += 25;

            DrawDashedLine(g, pageWidth);

            int maxOrders = Math.Min(15, _orders.Count);
            for (int i = 0; i < maxOrders; i++)
            {
                var order = _orders[i];
                int itemsCount = order.OrderItems.Sum(item => item.Quantity);

                g.DrawString(order.OrderDate.ToString("dd.MM.yy"), smallFont, Brushes.Black, StartX, _currentY);
                g.DrawString($"#{order.Id:D5}", smallFont, Brushes.Black, StartX + 100, _currentY);

                string customerName = $"{order.Customer.FirstName} {order.Customer.LastName}";
                if (customerName.Length > 20)
                    customerName = customerName.Substring(0, 17) + "...";
                g.DrawString(customerName, smallFont, Brushes.Black, StartX + 180, _currentY);

                g.DrawString(itemsCount.ToString(), smallFont, Brushes.Black, StartX + 370, _currentY);
                g.DrawString($"{order.TotalAmount:N0}", smallFont, Brushes.Black, StartX + 450, _currentY);
                g.DrawString(GetStatusName(order.Status), smallFont, Brushes.Black, StartX + 570, _currentY);

                string empName = $"{order.Employee.FirstName} {order.Employee.LastName}";
                if (empName.Length > 15)
                    empName = empName.Substring(0, 12) + "...";
                g.DrawString(empName, smallFont, Brushes.Black, StartX + 680, _currentY);

                _currentY += 18;
            }

            if (_orders.Count > 15)
            {
                _currentY += 10;
                g.DrawString($"... та ще {_orders.Count - 15} замовлень", smallFont, Brushes.Gray, StartX + 20, _currentY);
            }

            _currentY += 20;
            DrawLine(g, pageWidth);

            _currentY += 15;
            string footer = $"Звіт згенеровано: {DateTime.Now:dd.MM.yyyy HH:mm}";
            g.DrawString(footer, smallFont, Brushes.Gray, StartX, _currentY);
        }

        private void DrawLine(Graphics g, int width)
        {
            g.DrawLine(Pens.Black, StartX, _currentY, StartX + width, _currentY);
            _currentY += 5;
        }

        private void DrawDashedLine(Graphics g, int width)
        {
            Pen dashedPen = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            g.DrawLine(dashedPen, StartX, _currentY, StartX + width, _currentY);
            _currentY += 5;
        }

        private string GetStatusName(Domain.Enums.OrderStatus status)
        {
            return status switch
            {
                Domain.Enums.OrderStatus.Pending => "Очікує",
                Domain.Enums.OrderStatus.Completed => "Виконано",
                Domain.Enums.OrderStatus.Cancelled => "Скасовано",
                _ => status.ToString()
            };
        }
    }
}