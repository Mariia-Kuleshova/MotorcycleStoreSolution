using MotorcycleStore.Domain.Models;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace MotorcycleStore.Application.Services
{
    public class ReceiptGenerator
    {
        private Order _order;
        private int _currentLine;
        private const int LineHeight = 20;
        private const int StartX = 50;
        private int _currentY;

        public void GenerateReceipt(Order order)
        {
            _order = order;
            _currentLine = 0;
            _currentY = 50;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintReceipt;

            
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600
            };

            previewDialog.ShowDialog();
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 10);
            Font smallFont = new Font("Arial", 9);

            int receiptWidth = 400;

            string title = "MotoUa";
            SizeF titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, Brushes.Black,
                StartX + (receiptWidth - titleSize.Width) / 2, _currentY);
            _currentY += 30;

            DrawLine(g, receiptWidth);


            g.DrawString($"Дата: {_order.OrderDate:dd.MM.yyyy}", regularFont, Brushes.Black, StartX, _currentY);
            g.DrawString($"Час: {_order.OrderDate:HH:mm}", regularFont, Brushes.Black, StartX + 200, _currentY);
            _currentY += LineHeight;

            g.DrawString($"Чек №: {_order.Id:D5}", headerFont, Brushes.Black, StartX, _currentY);
            _currentY += 25;

            DrawLine(g, receiptWidth);


            g.DrawString($"Продавець: {_order.Employee.FirstName} {_order.Employee.LastName}",
                regularFont, Brushes.Black, StartX, _currentY);
            _currentY += LineHeight;

            g.DrawString($"Клієнт: {_order.Customer.FirstName} {_order.Customer.LastName}",
                regularFont, Brushes.Black, StartX, _currentY);
            _currentY += 25;

            DrawLine(g, receiptWidth);


            g.DrawString("№", headerFont, Brushes.Black, StartX, _currentY);
            g.DrawString("Товар", headerFont, Brushes.Black, StartX + 30, _currentY);
            g.DrawString("Ціна", headerFont, Brushes.Black, StartX + 200, _currentY);
            g.DrawString("К-сть", headerFont, Brushes.Black, StartX + 270, _currentY);
            g.DrawString("Сума", headerFont, Brushes.Black, StartX + 330, _currentY);
            _currentY += 25;

            DrawDashedLine(g, receiptWidth);


            int itemNumber = 1;
            foreach (var item in _order.OrderItems)
            {
       
                g.DrawString(itemNumber.ToString(), regularFont, Brushes.Black, StartX, _currentY);

                string productName = item.Product.Name.Length > 20
                    ? item.Product.Name.Substring(0, 17) + "..."
                    : item.Product.Name;
                g.DrawString(productName, regularFont, Brushes.Black, StartX + 30, _currentY);

    
                g.DrawString(item.UnitPrice.ToString("N0"), regularFont, Brushes.Black, StartX + 200, _currentY);

                g.DrawString(item.Quantity.ToString(), regularFont, Brushes.Black, StartX + 270, _currentY);

                g.DrawString(item.TotalPrice.ToString("N0"), regularFont, Brushes.Black, StartX + 330, _currentY);

                _currentY += LineHeight;
                itemNumber++;
            }

            _currentY += 5;
            DrawLine(g, receiptWidth);
            decimal subtotal = _order.OrderItems.Sum(i => i.TotalPrice);
            decimal vat = subtotal * 0.20m; 
            decimal total = subtotal;

            g.DrawString("Разом:", headerFont, Brushes.Black, StartX + 200, _currentY);
            g.DrawString($"{subtotal:N0} грн", headerFont, Brushes.Black, StartX + 300, _currentY);
            _currentY += 25;


            DrawLine(g, receiptWidth);

            g.DrawString("До сплати:", titleFont, Brushes.Black, StartX + 150, _currentY);
            g.DrawString($"{total:N0} грн", titleFont, Brushes.Black, StartX + 300, _currentY);
            _currentY += 30;

            DrawLine(g, receiptWidth);


            _currentY += 10;
            g.DrawString($"Спосіб оплати: {GetPaymentMethodName(_order.PaymentMethod)}",
                regularFont, Brushes.Black, StartX, _currentY);
            _currentY += LineHeight;

            if (!string.IsNullOrEmpty(_order.Comments))
            {
                g.DrawString($"Коментар: {_order.Comments}", smallFont, Brushes.Gray, StartX, _currentY);
                _currentY += LineHeight;
            }


            _currentY += 20;
            string footer = "Дякуємо за покупку!";
            SizeF footerSize = g.MeasureString(footer, headerFont);
            g.DrawString(footer, headerFont, Brushes.Black,
                StartX + (receiptWidth - footerSize.Width) / 2, _currentY);
            _currentY += 25;

            string website = "www.motoua.com";
            SizeF websiteSize = g.MeasureString(website, smallFont);
            g.DrawString(website, smallFont, Brushes.Gray,
                StartX + (receiptWidth - websiteSize.Width) / 2, _currentY);
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

        private string GetPaymentMethodName(string method)
        {
            return method switch
            {
                "Cash" => "Готівка",
                "Card" => "Картка",
                "Transfer" => "Переказ",
                _ => method
            };
        }
    }
}