using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Application.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms.Forms.UseControls
{
    public partial class ReportsUserControl : UserControl
    {
        private readonly IOrderService _orderService;
        private readonly ReceiptGenerator _receiptGenerator;
        private readonly SalesReportGenerator _salesReportGenerator;

        public ReportsUserControl(IOrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
            _receiptGenerator = new ReceiptGenerator();
            _salesReportGenerator = new SalesReportGenerator();
        }

        private async void ReportsUserControl_Load(object sender, EventArgs e)
        {
            // Встановлюємо дати за замовчуванням (поточний місяць)
            StartDatePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            EndDatePicker.Value = DateTime.Now;

            // Завантажуємо замовлення для списку чеків
            await LoadOrdersForReceipts();
        }

        private async System.Threading.Tasks.Task LoadOrdersForReceipts()
        {
            try
            {
                var orders = await _orderService.GetAllAsync();
                var ordersWithDetails = orders
                    .OrderByDescending(o => o.OrderDate)
                    .Take(50) // Останні 50 замовлень
                    .Select(o => new
                    {
                        o.Id,
                        OrderNumber = $"#{o.Id:D5}",
                        Date = o.OrderDate.ToString("dd.MM.yyyy HH:mm"),
                        Customer = $"{o.Customer.FirstName} {o.Customer.LastName}",
                        Total = $"{o.TotalAmount:N2} грн",
                        Order = o
                    })
                    .ToList();

                ReceiptsDataGridView.DataSource = ordersWithDetails;
                ReceiptsDataGridView.Columns["Order"].Visible = false;
                ReceiptsDataGridView.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження замовлень: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReceiptButton_Click(object sender, EventArgs e)
        {
            if (ReceiptsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть замовлення для друку чека!",
                    "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = ReceiptsDataGridView.SelectedRows[0];
                dynamic orderData = selectedRow.DataBoundItem;
                var order = orderData.Order;

                _receiptGenerator.GenerateReceipt(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка друку чека: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GenerateReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = StartDatePicker.Value.Date;
                DateTime endDate = EndDatePicker.Value.Date.AddDays(1).AddSeconds(-1);

                if (startDate > endDate)
                {
                    MessageBox.Show("Початкова дата не може бути пізніше кінцевої!",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var allOrders = await _orderService.GetAllAsync();
                var filteredOrders = allOrders
                    .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                    .OrderBy(o => o.OrderDate)
                    .ToList();

                if (!filteredOrders.Any())
                {
                    MessageBox.Show("За вибраний період замовлень не знайдено!",
                        "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _salesReportGenerator.GenerateReport(filteredOrders, startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка генерації звіту: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuickReportTodayButton_Click(object sender, EventArgs e)
        {
            StartDatePicker.Value = DateTime.Today;
            EndDatePicker.Value = DateTime.Today;
            GenerateReportButton_Click(sender, e);
        }

        private void QuickReportWeekButton_Click(object sender, EventArgs e)
        {
            StartDatePicker.Value = DateTime.Today.AddDays(-7);
            EndDatePicker.Value = DateTime.Today;
            GenerateReportButton_Click(sender, e);
        }

        private void QuickReportMonthButton_Click(object sender, EventArgs e)
        {
            StartDatePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            EndDatePicker.Value = DateTime.Today;
            GenerateReportButton_Click(sender, e);
        }

        private async void SearchReceiptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SearchReceiptTextBox.Text))
                {
                    await LoadOrdersForReceipts();
                    return;
                }

                var searchTerm = SearchReceiptTextBox.Text.Trim().ToLower();
                var allOrders = await _orderService.GetAllAsync();

                var filteredOrders = allOrders
                    .Where(o =>
                        o.Id.ToString().Contains(searchTerm) ||
                        o.Customer.FirstName.ToLower().Contains(searchTerm) ||
                        o.Customer.LastName.ToLower().Contains(searchTerm) ||
                        o.Customer.Phone.Contains(searchTerm))
                    .OrderByDescending(o => o.OrderDate)
                    .Select(o => new
                    {
                        o.Id,
                        OrderNumber = $"#{o.Id:D5}",
                        Date = o.OrderDate.ToString("dd.MM.yyyy HH:mm"),
                        Customer = $"{o.Customer.FirstName} {o.Customer.LastName}",
                        Total = $"{o.TotalAmount:N2} грн",
                        Order = o
                    })
                    .ToList();

                ReceiptsDataGridView.DataSource = filteredOrders;
                ReceiptsDataGridView.Columns["Order"].Visible = false;
                ReceiptsDataGridView.Columns["Id"].Visible = false;

                if (!filteredOrders.Any())
                {
                    MessageBox.Show("Нічого не знайдено!",
                        "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка пошуку: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}