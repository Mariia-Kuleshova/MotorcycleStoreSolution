using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Enums;
using MotorcycleStore.Domain.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms.Forms
{
    public partial class OrdersForm : Form
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private int? _selectedOrderId = null;
        private readonly NavigationService _nav;

        public OrdersForm(
            IOrderService orderService,
            ICustomerService customerService,
            IEmployeeService employeeService, NavigationService nav)
        {
            InitializeComponent();
            _orderService = orderService;
            _customerService = customerService;
            _employeeService = employeeService;
            _nav = nav;
        }

        private async void OrdersForm_Load(object sender, EventArgs e)
        {
            await LoadData();
            InitializeComboBoxes();
        }

        private async System.Threading.Tasks.Task LoadData()
        {
            try
            {
                // Завантажити замовників
                var customers = await _customerService.GetAllAsync();
                CustomerComboBox.DataSource = customers.ToList();
                CustomerComboBox.DisplayMember = "FullName";
                CustomerComboBox.ValueMember = "Id";

                // Завантажити працівників
                var employees = await _employeeService.GetAllAsync();
                EmployeeComboBox.DataSource = employees.ToList();
                EmployeeComboBox.DisplayMember = "FullName";
                EmployeeComboBox.ValueMember = "Id";

                // Завантажити замовлення
                await LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async System.Threading.Tasks.Task LoadOrders()
        {
            try
            {
                var orders = await _orderService.GetAllAsync();
                OrdersDataGridView.Rows.Clear();

                foreach (var order in orders)
                {
                    OrdersDataGridView.Rows.Add(
                        order.Id,
                        order.Customer?.LastName ?? "N/A",
                        order.Employee?.LastName ?? "N/A",
                        order.OrderDate.ToString("dd.MM.yyyy"),
                        GetStatusText(order.Status),
                        order.TotalAmount.ToString("N2"),
                        order.PaymentMethod,
                        order.Comments
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження замовлень: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComboBoxes()
        {
            // Ініціалізація статусів
            StatusComboBox.Items.Clear();
            StatusComboBox.Items.AddRange(new object[]
            {
                "Очікується",
                "В обробці",
                "Виконано",
                "Скасовано"
            });
            StatusComboBox.SelectedIndex = 0;

            // Ініціалізація способів оплати
            PaymentMethodComboBox.Items.Clear();
            PaymentMethodComboBox.Items.AddRange(new object[]
            {
                "Готівка",
                "Картка",
                "Переказ",
                "Кредит"
            });
            PaymentMethodComboBox.SelectedIndex = 0;

            OrderDatePicker.Value = DateTime.Now;
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomerComboBox.SelectedValue == null ||
                    EmployeeComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Виберіть замовника та працівника!",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var order = new Order
                {
                    CustomerId = (int)CustomerComboBox.SelectedValue,
                    EmployeeId = (int)EmployeeComboBox.SelectedValue,
                    OrderDate = OrderDatePicker.Value,
                    Status = GetStatusFromText(StatusComboBox.Text),
                    PaymentMethod = PaymentMethodComboBox.Text,
                    Comments = CommentsTextBox.Text,
                    TotalAmount = 0 // Буде розраховано при додаванні товарів
                };

                await _orderService.CreateOrderAsync(order);
                MessageBox.Show("Замовлення успішно створено!",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadOrders();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка створення замовлення: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedOrderId == null)
                {
                    MessageBox.Show("Виберіть замовлення для редагування!",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var order = await _orderService.GetByIdAsync(_selectedOrderId.Value);
                if (order == null)
                {
                    MessageBox.Show("Замовлення не знайдено!",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                order.CustomerId = (int)CustomerComboBox.SelectedValue;
                order.EmployeeId = (int)EmployeeComboBox.SelectedValue;
                order.OrderDate = OrderDatePicker.Value;
                order.Status = GetStatusFromText(StatusComboBox.Text);
                order.PaymentMethod = PaymentMethodComboBox.Text;
                order.Comments = CommentsTextBox.Text;

                await _orderService.UpdateStatusAsync(order.Id, order.Status);
                MessageBox.Show("Замовлення успішно оновлено!",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadOrders();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення замовлення: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            _selectedOrderId = null;
            CustomerComboBox.SelectedIndex = -1;
            EmployeeComboBox.SelectedIndex = -1;
            StatusComboBox.SelectedIndex = 0;
            PaymentMethodComboBox.SelectedIndex = 0;
            OrderDatePicker.Value = DateTime.Now;
            CommentsTextBox.Clear();
            TotalAmountTextBox.Text = "0.00";
            OrderIdLabel.Text = "";
        }

        private void OrdersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = OrdersDataGridView.Rows[e.RowIndex];
                _selectedOrderId = Convert.ToInt32(row.Cells[0].Value);

                LoadOrderToFields(row);
            }
        }

        private void LoadOrderToFields(DataGridViewRow row)
        {
            OrderIdLabel.Text = $"ID: {row.Cells[0].Value}";

            // Знайти замовника за ім'ям
            var customerName = row.Cells[1].Value?.ToString();
            for (int i = 0; i < CustomerComboBox.Items.Count; i++)
            {
                var customer = (Customer)CustomerComboBox.Items[i];
                if (customer.LastName == customerName)
                {
                    CustomerComboBox.SelectedIndex = i;
                    break;
                }
            }

            // Знайти працівника за ім'ям
            var employeeName = row.Cells[2].Value?.ToString();
            for (int i = 0; i < EmployeeComboBox.Items.Count; i++)
            {
                var employee = (Employee)EmployeeComboBox.Items[i];
                if (employee.LastName == employeeName)
                {
                    EmployeeComboBox.SelectedIndex = i;
                    break;
                }
            }

            OrderDatePicker.Value = DateTime.Parse(row.Cells[3].Value.ToString());
            StatusComboBox.Text = row.Cells[4].Value?.ToString() ?? "";
            TotalAmountTextBox.Text = row.Cells[5].Value?.ToString() ?? "0.00";
            PaymentMethodComboBox.Text = row.Cells[6].Value?.ToString() ?? "";
            CommentsTextBox.Text = row.Cells[7].Value?.ToString() ?? "";
        }

        private void ViewDetailsButton_Click(object sender, EventArgs e)
        {
            if (_selectedOrderId == null)
            {
                MessageBox.Show("Виберіть замовлення для перегляду деталей!",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Тут можна відкрити окрему форму з деталями замовлення (OrderItems)
            MessageBox.Show($"Деталі замовлення #{_selectedOrderId} будуть показані у окремій формі",
                "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OrdersDataGridView.SelectedRows.Count > 0)
            {
                var row = OrdersDataGridView.SelectedRows[0];
                _selectedOrderId = Convert.ToInt32(row.Cells[0].Value);
                LoadOrderToFields(row);
            }
        }

        private void ViewDetailsStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDetailsButton_Click(sender, e);
        }

        private async void ChangeStatusStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OrdersDataGridView.SelectedRows.Count > 0)
            {
                var row = OrdersDataGridView.SelectedRows[0];
                var orderId = Convert.ToInt32(row.Cells[0].Value);

                var statusForm = new Form
                {
                    Text = "Змінити статус",
                    Size = new System.Drawing.Size(300, 150),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                var statusCombo = new ComboBox
                {
                    Location = new System.Drawing.Point(20, 20),
                    Width = 240
                };
                statusCombo.Items.AddRange(new object[] { "Очікується", "В обробці", "Виконано", "Скасовано" });
                statusCombo.SelectedIndex = 0;

                var okButton = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new System.Drawing.Point(20, 60),
                    Width = 110
                };

                var cancelButton = new Button
                {
                    Text = "Скасувати",
                    DialogResult = DialogResult.Cancel,
                    Location = new System.Drawing.Point(150, 60),
                    Width = 110
                };

                statusForm.Controls.AddRange(new Control[] { statusCombo, okButton, cancelButton });
                statusForm.AcceptButton = okButton;
                statusForm.CancelButton = cancelButton;

                if (statusForm.ShowDialog() == DialogResult.OK)
                {
                    var newStatus = GetStatusFromText(statusCombo.Text);
                    await _orderService.UpdateStatusAsync(orderId, newStatus);
                    await LoadOrders();
                    MessageBox.Show("Статус змінено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void DeleteStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OrdersDataGridView.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Ви впевнені, що хочете видалити це замовлення?",
                    "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Тут потрібно додати метод видалення в сервіс
                    MessageBox.Show("Видалення замовлень буде реалізовано",
                        "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void XLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Ви впевнені, що хочете вийти?",
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _nav.NavigateTo<LoginForm>(this);
            }
        }

        // Допоміжні методи
        private string GetStatusText(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Pending => "Очікується",
                OrderStatus.Completed => "Виконано",
                OrderStatus.Cancelled => "Скасовано",
                _ => "Невідомо"
            };
        }

        private OrderStatus GetStatusFromText(string text)
        {
            return text switch
            {
                "Очікується" => OrderStatus.Pending,
                "Виконано" => OrderStatus.Completed,
                "Скасовано" => OrderStatus.Cancelled,
                _ => OrderStatus.Pending
            };
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo<ProductsForm>(this);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo<CustomersForm>(this);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo<EmployeesForm>(this);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}