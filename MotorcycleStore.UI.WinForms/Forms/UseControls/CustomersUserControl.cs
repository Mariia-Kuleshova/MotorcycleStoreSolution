using Microsoft.Office.Interop.Word;
using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms.Forms.UseControls
{
    public partial class CustomersUserControl : UserControl
    {
        private readonly ICustomerService _customerService;
        private int? _selectedCustomerId = null;

        public CustomersUserControl(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;

            this.Load += CustomersForm_Load;
        }

        private async void CustomersForm_Load(object sender, EventArgs e)
        {
            await LoadCustomers();
            RegisteredAtPicker.Value = DateTime.Now;
        }

        private async System.Threading.Tasks.Task LoadCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllAsync();
                CustomersDataGridView.Rows.Clear();

                foreach (var customer in customers)
                {
                    CustomersDataGridView.Rows.Add(
                        customer.Id,
                        customer.FirstName,
                        customer.LastName,
                        customer.Phone,
                        customer.Email ?? "",
                        customer.Address ?? "",
                        customer.RegisteredAt.ToString("dd.MM.yyyy"),
                        customer.IsVIP
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження замовників: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void AddButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PhoneTextBox.Text))
                {
                    MessageBox.Show("Заповніть всі обов'язкові поля (Ім'я, Прізвище, Телефон)!",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cleanPhone = Regex.Replace(PhoneTextBox.Text, @"[\s\-\(\)]", "");
                string pattern = @"^(\+?38)?0[3-9]\d{8}$";

                if (!Regex.IsMatch(cleanPhone, pattern))
                {
                    MessageBox.Show("Невіний формат номера телефону!",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var customer = new Customer
                {
                    FirstName = FirstNameTextBox.Text.Trim(),
                    LastName = LastNameTextBox.Text.Trim(),
                    Phone = PhoneTextBox.Text.Trim(),
                    Email = EmailTextBox.Text.Trim(),
                    RegisteredAt = RegisteredAtPicker.Value
                };

                await _customerService.AddAsync(customer);
                MessageBox.Show("Замовника успішно додано!",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadCustomers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання замовника: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SaveButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCustomerId == null)
                {
                    MessageBox.Show("Виберіть замовника для редагування!",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PhoneTextBox.Text))
                {
                    MessageBox.Show("Заповніть всі обов'язкові поля!",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var customer = await _customerService.GetByIdAsync(_selectedCustomerId.Value);
                if (customer == null)
                {
                    MessageBox.Show("Замовника не знайдено!",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string cleanPhone = Regex.Replace(PhoneTextBox.Text, @"[\s\-\(\)]", "");
                string pattern = @"^(\+?38)?0[3-9]\d{8}$";

                if (!Regex.IsMatch(cleanPhone, pattern))
                {
                    MessageBox.Show("Невіний формат номера телефону!",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                customer.FirstName = FirstNameTextBox.Text.Trim();
                customer.LastName = LastNameTextBox.Text.Trim();
                customer.Phone = PhoneTextBox.Text.Trim();
                customer.Email = EmailTextBox.Text.Trim();
                customer.RegisteredAt = RegisteredAtPicker.Value;
                customer.IsVIP = false;

                await _customerService.UpdateAsync(customer);
                MessageBox.Show("Дані замовника успішно оновлено!",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadCustomers();
                ClearFields();
                AddButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення замовника: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            ClearFields();
            AddButton.Enabled = true;
        }

        private void ClearFields()
        {
            _selectedCustomerId = null;
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            PhoneTextBox.Clear();
            EmailTextBox.Clear();
            RegisteredAtPicker.Value = DateTime.Now;
            SearchTextBox.Clear();
        }

        private void CustomersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = CustomersDataGridView.Rows[e.RowIndex];
                _selectedCustomerId = Convert.ToInt32(row.Cells[0].Value);
                LoadCustomerToFields(row);
            }
        }

        private void LoadCustomerToFields(DataGridViewRow row)
        {
            FirstNameTextBox.Text = row.Cells[1].Value?.ToString() ?? "";
            LastNameTextBox.Text = row.Cells[2].Value?.ToString() ?? "";
            PhoneTextBox.Text = row.Cells[3].Value?.ToString() ?? "";
            EmailTextBox.Text = row.Cells[4].Value?.ToString() ?? "";

            if (DateTime.TryParse(row.Cells[6].Value?.ToString(), out DateTime registeredDate))
            {
                RegisteredAtPicker.Value = registeredDate;
            }
        }

        private async void SearchButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
                {
                    await LoadCustomers();
                    return;
                }

                var searchTerm = SearchTextBox.Text.Trim().ToLower();
                var allCustomers = await _customerService.GetAllAsync();

                var filteredCustomers = allCustomers.Where(c =>
                    c.FirstName.ToLower().Contains(searchTerm) ||
                    c.LastName.ToLower().Contains(searchTerm) ||
                    c.Phone.Contains(searchTerm) ||
                    (c.Email != null && c.Email.ToLower().Contains(searchTerm))
                ).ToList();

                CustomersDataGridView.Rows.Clear();

                foreach (var customer in filteredCustomers)
                {
                    CustomersDataGridView.Rows.Add(
                        customer.Id,
                        customer.FirstName,
                        customer.LastName,
                        customer.Phone,
                        customer.Email ?? "",
                        customer.Address ?? "",
                        customer.RegisteredAt.ToString("dd.MM.yyyy"),
                        customer.IsVIP
                    );
                }

                if (filteredCustomers.Count == 0)
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

        private void EditStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CustomersDataGridView.SelectedRows.Count > 0)
            {
                var row = CustomersDataGridView.SelectedRows[0];
                _selectedCustomerId = Convert.ToInt32(row.Cells[0].Value);
                LoadCustomerToFields(row);
            }
        }

        private async void DeleteStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CustomersDataGridView.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show(
                    "Ви впевнені, що хочете видалити цього замовника?\nВсі його замовлення також будуть видалені!",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var customerId = Convert.ToInt32(CustomersDataGridView.SelectedRows[0].Cells[0].Value);
                        await _customerService.DeleteAsync(customerId);

                        MessageBox.Show("Замовника успішно видалено!",
                            "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await LoadCustomers();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка видалення: {ex.Message}",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void ToggleVIPStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CustomersDataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    var customerId = Convert.ToInt32(CustomersDataGridView.SelectedRows[0].Cells[0].Value);
                    var customer = await _customerService.GetByIdAsync(customerId);

                    if (customer != null)
                    {
                        customer.IsVIP = !customer.IsVIP;
                        await _customerService.UpdateAsync(customer);

                        MessageBox.Show($"VIP-статус {(customer.IsVIP ? "надано" : "знято")}!",
                            "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await LoadCustomers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка зміни VIP-статусу: {ex.Message}",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ViewOrdersStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CustomersDataGridView.SelectedRows.Count > 0)
            {
                var customerId = Convert.ToInt32(CustomersDataGridView.SelectedRows[0].Cells[0].Value);
                var customerName = $"{CustomersDataGridView.SelectedRows[0].Cells[1].Value} {CustomersDataGridView.SelectedRows[0].Cells[2].Value}";

                MessageBox.Show($"Перегляд замовлень замовника: {customerName}\n(ID: {customerId})\n\nБуде реалізовано окремою формою",
                    "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void EditStripMenuItem1_Click(object sender, EventArgs e)
        {
            var row = CustomersDataGridView.CurrentRow;
            _selectedCustomerId = Convert.ToInt32(row.Cells[0].Value);
            LoadCustomerToFields(row);
            AddButton.Enabled = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
