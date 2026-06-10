using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Common;
using MotorcycleStore.UI.WinForms.Services;
using MotorcycleStore.Domain.Enums;
using MotorcycleStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms.Forms.UseControls
{
    public partial class OrdersUserControl : UserControl
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly IProductService _productService;
        private IEnumerable<Product> _products;
        private int? _selectedOrderId = null;
        private int? _idFromProductForm;
        private Employee _currentEmp;
        private Order _currentOrder;
        private readonly ReceiptGenerator _receiptGenerator;

        public OrdersUserControl(
            Employee currentEmp,
            IOrderService orderService,
            ICustomerService customerService,
            IEmployeeService employeeService,
            IProductService productService)
        {
            InitializeComponent();
            _orderService = orderService;
            _customerService = customerService;
            _employeeService = employeeService;

            this.Load += OrdersUserControl_Load;
            _productService = productService;
            _currentEmp = currentEmp;

            _receiptGenerator = new ReceiptGenerator();
        }

        public OrdersUserControl(
            int id,
            Employee currentEmp,
            IOrderService orderService,
            ICustomerService customerService,
            IEmployeeService employeeService,
            IProductService productService)
        {
            InitializeComponent();
            _orderService = orderService;
            _customerService = customerService;
            _employeeService = employeeService;

            this.Load += OrdersUserControlWithId_Load;
            _productService = productService;
            _currentEmp = currentEmp;
            _idFromProductForm = id;

            _receiptGenerator = new ReceiptGenerator();
        }

        private async void OrdersUserControl_Load(object sender, EventArgs e)
        {
            ProductComboBox.SelectedItem = null;
            TotalAmountTextBox.Text = "0.00";
            await LoadData();
            InitializeComboBoxes();
        }

        private async void OrdersUserControlWithId_Load(object sender, EventArgs e)
        {
            ProductComboBox.SelectedItem = null;
            TotalAmountTextBox.Text = "0.00";
            await LoadData();
            InitializeComboBoxes();
            await LoadDataWithId();
        }

        private async System.Threading.Tasks.Task LoadDataWithId()
        {
            if (_idFromProductForm != null)
            {
                var product = await _productService.GetByIdAsync((int)_idFromProductForm);
                if (product != null)
                {
                    ProductComboBox.Text = product.Name;
                    EmployeeComboBox.Text = _currentEmp.FirstName + " " + _currentEmp.LastName;
                    StatusComboBox.SelectedIndex = 0;
                    TotalAmountTextBox.Text = product.Price.ToString();
                    SaveButton.Enabled = false;
                }
            }
        }

        private async System.Threading.Tasks.Task LoadData()
        {
            try
            {
                _products = await _productService.GetAllAsync();

                ProductComboBox.DataSource = _products
                    .Where(p => p.Inventory?.Quantity > 0)
                    .OrderBy(p => p.Name)
                    .Select(c => new
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToList();
                ProductComboBox.DisplayMember = "Name";
                ProductComboBox.ValueMember = "Id";
                ProductComboBox.SelectedIndex = -1;

                var customers = await _customerService.GetAllAsync();

                CustomerComboBox.DataSource = customers
                    .Select(c => new
                    {
                        Id = c.Id,
                        FullName = c.FirstName + " " + c.LastName
                    })
                    .ToList();
                CustomerComboBox.DisplayMember = "FullName";
                CustomerComboBox.ValueMember = "Id";
                CustomerComboBox.SelectedIndex = -1;

                var employees = await _employeeService.GetAllAsync();
                EmployeeComboBox.DataSource = employees
                    .Where(e => e.IsActive == true)
                    .Select(c => new
                    {
                        Id = c.Id,
                        FullName = c.FirstName + " " + c.LastName
                    })
                    .ToList();
                EmployeeComboBox.DisplayMember = "FullName";
                EmployeeComboBox.ValueMember = "Id";
                EmployeeComboBox.SelectedIndex = -1;

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
                var orders = (await _orderService.GetAllAsync())
                    .OrderByDescending(o =>
                        o.PaymentMethod == WebOrderConstants.PaymentMethod && o.Status == OrderStatus.Pending)
                    .ThenByDescending(o => o.OrderDate);

                OrdersDataGridView.Rows.Clear();

                foreach (var order in orders)
                {
                    var firstItem = order.OrderItems.FirstOrDefault();
                    var isWebOrder = order.PaymentMethod == WebOrderConstants.PaymentMethod;
                    var statusText = isWebOrder && order.Status == OrderStatus.Pending
                        ? "Нове (сайт)"
                        : GetStatusText(order.Status);

                    var rowIndex = OrdersDataGridView.Rows.Add(
                        order.Id,
                        firstItem?.Product?.Name ?? "N/A",
                        order.OrderDate.ToString("dd.MM.yyyy"),
                        order.TotalAmount.ToString("N2"),
                        statusText,
                        $"{order.Customer?.FirstName} {order.Customer?.LastName}".Trim(),
                        order.Employee?.LastName ?? "N/A",
                        order.PaymentMethod,
                        order.Comments
                    );

                    var row = OrdersDataGridView.Rows[rowIndex];
                    if (isWebOrder && order.Status == OrderStatus.Pending)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 237, 213);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(154, 52, 18);
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 215, 170);
                        row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(124, 45, 18);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(71, 69, 94);
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
                        row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
                    }
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
            StatusComboBox.Items.Clear();
            StatusComboBox.Items.AddRange(new object[]
            {
                "Очікується",
                "В обробці",
                "Виконано",
                "Скасовано"
            });
            StatusComboBox.SelectedIndex = -1;

            PaymentMethodComboBox.Items.Clear();
            PaymentMethodComboBox.Items.AddRange(new object[]
            {
                "Готівка",
                "Картка",
                WebOrderConstants.PaymentMethod
            });
            PaymentMethodComboBox.SelectedIndex = -1;

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
                    OrderItems = new List<OrderItem>(),
                    TotalAmount = 0
                };

                var products = await _productService.GetAllAsync();
                var selectedProduct = products.FirstOrDefault(p => p.Name == ProductComboBox.Text);

                if (selectedProduct == null)
                {
                    MessageBox.Show("Продукт не знайдено!", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var orderItem = new OrderItem
                {
                    ProductId = selectedProduct.Id,
                    Quantity = 1,
                    UnitPrice = selectedProduct.Price
                };

                order.OrderItems.Add(orderItem);

                await _orderService.CreateOrderAsync(order);

                MessageBox.Show("Замовлення успішно створено!",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadOrders();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
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

                if (string.IsNullOrWhiteSpace(StatusComboBox.Text))
                {
                    MessageBox.Show("Виберіть статус замовлення!",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(PaymentMethodComboBox.Text))
                {
                    MessageBox.Show("Виберіть спосіб оплати!",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                order.Status = GetStatusFromCombo();
                order.PaymentMethod = PaymentMethodComboBox.Text.Trim();
                order.Comments = CommentsTextBox.Text.Trim();

                var updated = await _orderService.UpdateAsync(order);
                if (!updated)
                {
                    MessageBox.Show("Не вдалося зберегти замовлення!",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Замовлення успішно оновлено!",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadOrders();
                ClearFields();
                SetComboboxAsEnabled();
                AddButton.Enabled = true;
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
            SetComboboxAsEnabled();
            AddButton.Enabled = true;
            SaveButton.Enabled = true;
        }

        private void ClearFields()
        {
            _selectedOrderId = null;
            ProductComboBox.SelectedIndex = -1;
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
                EnterOrderEditMode();
            }
        }

        private void LoadOrderToFields(DataGridViewRow row)
        {
            OrderIdLabel.Text = $"ID: {row.Cells[0].Value}";

            var customerName = row.Cells[5].Value?.ToString();
            for (int i = 0; i < CustomerComboBox.Items.Count; i++)
            {
                var customer = CustomerComboBox.Items[i].ToString();
                if (customer.Contains(customerName))
                {
                    CustomerComboBox.SelectedIndex = i;
                    break;
                }
            }

            var employeeName = row.Cells[6].Value?.ToString();
            for (int i = 0; i < EmployeeComboBox.Items.Count; i++)
            {
                var employee = EmployeeComboBox.Items[i].ToString();
                if (employee.Contains(employeeName))
                {
                    EmployeeComboBox.SelectedIndex = i;
                    break;
                }
            }

            ProductComboBox.Text = row.Cells[1].Value?.ToString();
            if (DateTime.TryParseExact(
                    row.Cells[2].Value?.ToString(),
                    "dd.MM.yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out var orderDate))
            {
                OrderDatePicker.Value = orderDate;
            }

            var statusDisplay = row.Cells[4].Value?.ToString() ?? "";
            SetStatusComboValue(statusDisplay == "Нове (сайт)" ? "Очікується" : statusDisplay);
            TotalAmountTextBox.Text = row.Cells[3].Value?.ToString() ?? "0.00";
            SetPaymentMethodComboValue(row.Cells[7].Value?.ToString() ?? "");
            CommentsTextBox.Text = row.Cells[8].Value?.ToString() ?? "";
            _selectedOrderId = (int)row.Cells[0].Value;

            SetOrderIdentityFieldsReadOnly(true);
        }

        private void EnterOrderEditMode()
        {
            StatusComboBox.Enabled = true;
            PaymentMethodComboBox.Enabled = true;
            CommentsTextBox.Enabled = true;
            AddButton.Enabled = false;
            SaveButton.Enabled = true;
        }

        private void SetOrderIdentityFieldsReadOnly(bool readOnly)
        {
            ProductComboBox.Enabled = !readOnly;
            OrderDatePicker.Enabled = !readOnly;
            TotalAmountTextBox.Enabled = !readOnly;
            EmployeeComboBox.Enabled = !readOnly;
            CustomerComboBox.Enabled = !readOnly;
        }

        private void SetComboboxAsEnabled()
        {
            SetOrderIdentityFieldsReadOnly(false);
            StatusComboBox.Enabled = true;
            PaymentMethodComboBox.Enabled = true;
            CommentsTextBox.Enabled = true;
        }

        private void SetStatusComboValue(string status)
        {
            var index = StatusComboBox.Items.IndexOf(status);
            if (index >= 0)
                StatusComboBox.SelectedIndex = index;
            else
                StatusComboBox.Text = status;
        }

        private void SetPaymentMethodComboValue(string paymentMethod)
        {
            if (string.IsNullOrWhiteSpace(paymentMethod))
            {
                PaymentMethodComboBox.SelectedIndex = -1;
                PaymentMethodComboBox.Text = string.Empty;
                return;
            }

            if (!PaymentMethodComboBox.Items.Contains(paymentMethod))
                PaymentMethodComboBox.Items.Add(paymentMethod);

            PaymentMethodComboBox.Text = paymentMethod;
        }

        private void ViewDetailsButton_Click(object sender, EventArgs e)
        {
            if (_selectedOrderId == null)
            {
                MessageBox.Show("Виберіть замовлення для перегляду деталей!",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Деталі замовлення #{_selectedOrderId} будуть показані у окремій формі",
                "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void DeleteStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (OrdersDataGridView.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Ви впевнені, що хочете видалити це замовлення?",
                    "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Замовлення видалено.",
                        "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var row = OrdersDataGridView.SelectedRows[0];
                    _selectedOrderId = Convert.ToInt32(row.Cells[0].Value);
                    await _orderService.DeleteAsync(_selectedOrderId.Value);
                    await LoadOrders();
                }
            }
        }

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

        private OrderStatus GetStatusFromCombo()
        {
            var text = StatusComboBox.SelectedItem?.ToString() ?? StatusComboBox.Text;
            return GetStatusFromText(text);
        }

        private OrderStatus GetStatusFromText(string text)
        {
            return text switch
            {
                "Очікується" => OrderStatus.Pending,
                "В обробці" => OrderStatus.Pending,
                "Виконано" => OrderStatus.Completed,
                "Скасовано" => OrderStatus.Cancelled,
                _ => OrderStatus.Pending
            };
        }

        private void EditStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (OrdersDataGridView.CurrentRow is null)
                return;

            LoadOrderToFields(OrdersDataGridView.CurrentRow);
            EnterOrderEditMode();
        }

        private async void ProductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductComboBox.SelectedItem == null || ProductComboBox.SelectedIndex == -1 || ProductComboBox.SelectedIndex == 0)
                return;

            var item = ProductComboBox.SelectedItem;
            if (item == null) return;
            int id = (int)item.GetType().GetProperty("Id").GetValue(item, null);

            var prodInfo = await _productService.GetByIdAsync(id);

            if (prodInfo != null)
            {
                TotalAmountTextBox.Text = prodInfo.Price.ToString();
            }
        }


        private void ProductComboBox_TextChanged(object sender, EventArgs e)
        {
            string input = ProductComboBox.Text.ToLower();

            var filtered = _products
                .Where(p => p.Name != null && p.Name.ToLower().Contains(input))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();

            if (filtered.Count > 0)
            {
                ProductComboBox.DataSource = filtered;
                ProductComboBox.DroppedDown = true;
                ProductComboBox.SelectionStart = ProductComboBox.Text.Length;
                ProductComboBox.SelectionLength = 0;
            }
        }

        private async void ReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var row = OrdersDataGridView.SelectedRows[0];
                _selectedOrderId = Convert.ToInt32(row.Cells[0].Value);
                var order = await _orderService.GetByIdAsync(_selectedOrderId.Value);

                _receiptGenerator.GenerateReceipt(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка друку чека: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}