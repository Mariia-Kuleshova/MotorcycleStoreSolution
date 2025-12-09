using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Application.Services;
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
    public partial class EmployeesUserControl : UserControl
    {
        private readonly IEmployeeService _employeeService;
        private int? _selectedEmployeeId = null;
        private bool _isEditMode = false;

        public EmployeesUserControl(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;

            this.Load += EmployeesForm_Load;
        }

        private async void EmployeesForm_Load(object sender, EventArgs e)
        {
            await LoadEmployees();
            InitializeRoleComboBox();
            HiredAtPicker.Value = DateTime.Now;
        }

        private void InitializeRoleComboBox()
        {
            RoleComboBox.Items.Clear();
            RoleComboBox.Items.AddRange(new object[] { "Admin", "Manager" });
            RoleComboBox.SelectedIndex = 1; // За замовчуванням Manager
        }

        private async System.Threading.Tasks.Task LoadEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllAsync();
                EmployeesDataGridView.Rows.Clear();

                foreach (var employee in employees)
                {
                    if (employee.IsActive)
                    {
                        EmployeesDataGridView.Rows.Add(
                            employee.Id,
                            employee.FirstName,
                            employee.LastName,
                            employee.Phone ?? "",
                            employee.Email ?? "",
                            employee.Username,
                            employee.Role,
                            employee.HiredAt.ToString("dd.MM.yyyy"),
                            employee.IsActive
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження працівників: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFields())
                    return;

                var employee = new Employee
                {
                    FirstName = FirstNameTextBox.Text.Trim(),
                    LastName = LastNameTextBox.Text.Trim(),
                    //Position = PositionTextBox.Text.Trim(),
                    Phone = PhoneTextBox.Text.Trim(),
                    Email = EmailTextBox.Text.Trim(),
                    Username = UsernameTextBox.Text.Trim(),
                    PasswordHash = PasswordTextBox.Text, // Буде захешовано в сервісі
                    Role = RoleComboBox.Text,
                    HiredAt = HiredAtPicker.Value,
                    //IsActive = IsActiveCheckBox.Checked
                };

                await _employeeService.AddAsync(employee);
                MessageBox.Show("Працівника успішно додано!",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadEmployees();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання працівника: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SaveButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_selectedEmployeeId == null)
                {
                    MessageBox.Show("Виберіть працівника для редагування!",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateFields(isEdit: true))
                    return;

                var employee = await _employeeService.GetByIdAsync(_selectedEmployeeId.Value);
                if (employee == null)
                {
                    MessageBox.Show("Працівника не знайдено!",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                employee.FirstName = FirstNameTextBox.Text.Trim();
                employee.LastName = LastNameTextBox.Text.Trim();
                //employee.Position = PositionTextBox.Text.Trim();
                employee.Phone = PhoneTextBox.Text.Trim();
                employee.Email = EmailTextBox.Text.Trim();
                employee.Username = UsernameTextBox.Text.Trim();
                employee.Role = RoleComboBox.Text;
                employee.HiredAt = HiredAtPicker.Value;
                //employee.IsActive = IsActiveCheckBox.Checked;

                // Якщо пароль змінено
                if (!string.IsNullOrWhiteSpace(PasswordTextBox.Text))
                {
                    employee.PasswordHash = PasswordTextBox.Text;
                }

                await _employeeService.UpdateAsync(employee);
                MessageBox.Show("Дані працівника успішно оновлено!",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadEmployees();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення працівника: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateFields(bool isEdit = false)
        {
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                //string.IsNullOrWhiteSpace(PositionTextBox.Text) ||
                string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                MessageBox.Show("Заповніть всі обов'язкові поля (Ім'я, Прізвище, Посада, Логін)!",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string cleanPhone = Regex.Replace(PhoneTextBox.Text, @"[\s\-\(\)]", "");
            string pattern = @"^(\+?38)?0[3-9]\d{8}$";

            if(!Regex.IsMatch(cleanPhone, pattern))
            {
                MessageBox.Show("Невіний формат номера телефону!",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Перевірка пароля тільки при додаванні нового працівника
            if (!isEdit && string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Введіть пароль для нового працівника!",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (RoleComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Виберіть роль працівника!",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            _selectedEmployeeId = null;
            _isEditMode = false;
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            //PositionTextBox.Clear();
            PhoneTextBox.Clear();
            EmailTextBox.Clear();
            UsernameTextBox.Clear();
            PasswordTextBox.Clear();
            RoleComboBox.SelectedIndex = 1;
            HiredAtPicker.Value = DateTime.Now;
            //IsActiveCheckBox.Checked = true;
            SearchTextBox.Clear();
            PasswordTextBox.Enabled = true;
            UsernameTextBox.ReadOnly = false;

            AddButton.Enabled = true;
        }

        private void EmployeesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = EmployeesDataGridView.Rows[e.RowIndex];
                _selectedEmployeeId = Convert.ToInt32(row.Cells[0].Value);
                _isEditMode = true;
                LoadEmployeeToFields(row);
            }
        }

        private void LoadEmployeeToFields(DataGridViewRow row)
        {
            FirstNameTextBox.Text = row.Cells[1].Value?.ToString() ?? "";
            LastNameTextBox.Text = row.Cells[2].Value?.ToString() ?? "";
            //PositionTextBox.Text = row.Cells[3].Value?.ToString() ?? "";
            PhoneTextBox.Text = row.Cells[3].Value?.ToString() ?? "";
            EmailTextBox.Text = row.Cells[4].Value?.ToString() ?? "";
            UsernameTextBox.Text = row.Cells[5].Value?.ToString() ?? "";
            UsernameTextBox.ReadOnly = true; // Не дозволяємо змінювати логін
            RoleComboBox.Text = row.Cells[6].Value?.ToString() ?? "Manager";

            if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out DateTime hiredDate))
            {
                HiredAtPicker.Value = hiredDate;
            }

            //IsActiveCheckBox.Checked = row.Cells[9].Value != null && (bool)row.Cells[9].Value;

            // При редагуванні пароль не показуємо
            PasswordTextBox.Clear();
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
                {
                    await LoadEmployees();
                    return;
                }

                var searchTerm = SearchTextBox.Text.Trim().ToLower();
                var allEmployees = await _employeeService.GetAllAsync();

                var filteredEmployees = allEmployees.Where(e =>
                    e.FirstName.ToLower().Contains(searchTerm) ||
                    e.LastName.ToLower().Contains(searchTerm) ||
                    //e.Position.ToLower().Contains(searchTerm) ||
                    e.Username.ToLower().Contains(searchTerm)
                ).ToList();

                EmployeesDataGridView.Rows.Clear();

                foreach (var employee in filteredEmployees)
                {
                    EmployeesDataGridView.Rows.Add(
                        employee.Id,
                        employee.FirstName,
                        employee.LastName,
                        employee.Phone ?? "",
                        employee.Email ?? "",
                        employee.Username,
                        employee.Role,
                        employee.HiredAt.ToString("dd.MM.yyyy"),
                        employee.IsActive
                    );
                }

                if (filteredEmployees.Count == 0)
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
            if (EmployeesDataGridView.SelectedRows.Count > 0)
            {
                var row = EmployeesDataGridView.SelectedRows[0];
                _selectedEmployeeId = Convert.ToInt32(row.Cells[0].Value);
                _isEditMode = true;
                LoadEmployeeToFields(row);
            }
        }

        private async void DeleteStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EmployeesDataGridView.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show(
                    "Ви впевнені, що хочете видалити цього працівника?\nВсі його дані будуть видалені!",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var employeeId = Convert.ToInt32(EmployeesDataGridView.SelectedRows[0].Cells[0].Value);
                        await _employeeService.DeleteAsync(employeeId);

                        MessageBox.Show("Працівника успішно видалено!",
                            "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await LoadEmployees();
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

        private async void ToggleActiveStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EmployeesDataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    var employeeId = Convert.ToInt32(EmployeesDataGridView.SelectedRows[0].Cells[0].Value);
                    var employee = await _employeeService.GetByIdAsync(employeeId);

                    if (employee != null)
                    {
                        employee.IsActive = !employee.IsActive;
                        await _employeeService.UpdateAsync(employee);

                        MessageBox.Show($"Працівника {(employee.IsActive ? "активовано" : "деактивовано")}!",
                            "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await LoadEmployees();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка зміни статусу: {ex.Message}",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ResetPasswordStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EmployeesDataGridView.SelectedRows.Count > 0)
            {
                var employeeId = Convert.ToInt32(EmployeesDataGridView.SelectedRows[0].Cells[0].Value);
                var employeeName = $"{EmployeesDataGridView.SelectedRows[0].Cells[1].Value} {EmployeesDataGridView.SelectedRows[0].Cells[2].Value}";

                var passwordForm = new Form
                {
                    Text = "Скинути пароль",
                    Size = new System.Drawing.Size(350, 180),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                var label = new Label
                {
                    Text = $"Новий пароль для {employeeName}:",
                    Location = new System.Drawing.Point(20, 20),
                    AutoSize = true
                };

                var passwordBox = new TextBox
                {
                    Location = new System.Drawing.Point(20, 50),
                    Width = 290,
                    PasswordChar = '●'
                };

                var okButton = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new System.Drawing.Point(20, 90),
                    Width = 135
                };

                var cancelButton = new Button
                {
                    Text = "Скасувати",
                    DialogResult = DialogResult.Cancel,
                    Location = new System.Drawing.Point(175, 90),
                    Width = 135
                };

                passwordForm.Controls.AddRange(new Control[] { label, passwordBox, okButton, cancelButton });
                passwordForm.AcceptButton = okButton;
                passwordForm.CancelButton = cancelButton;

                if (passwordForm.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(passwordBox.Text))
                {
                    try
                    {
                        var employee = await _employeeService.GetByIdAsync(employeeId);
                        if (employee != null)
                        {
                            employee.PasswordHash = passwordBox.Text;
                            await _employeeService.UpdateAsync(employee);

                            MessageBox.Show("Пароль успішно змінено!",
                                "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка зміни пароля: {ex.Message}",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EditStripMenuItem1_Click(object sender, EventArgs e)
        {
            var row = EmployeesDataGridView.CurrentRow;
            _selectedEmployeeId = Convert.ToInt32(row.Cells[0].Value);
            LoadEmployeeToFields(row);
            AddButton.Enabled = false;
        }

        private async void DeleteStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (EmployeesDataGridView.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show(
                    "Ви впевнені, що хочете видалити цього працівника?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var employeeId = Convert.ToInt32(EmployeesDataGridView.SelectedRows[0].Cells[0].Value);
                        await _employeeService.DeleteAsync(employeeId);

                        MessageBox.Show("Працівника успішно видалено!",
                            "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await LoadEmployees();
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
    }
}
