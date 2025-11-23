using Microsoft.Extensions.DependencyInjection;
using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private Employee? _currentEmployee;

        public LoginForm(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;

            // Налаштування поля пароля
            PasswordTextBox.PasswordChar = '●';
            PasswordTextBox.UseSystemPasswordChar = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Центрування форми
            this.CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Порожній обробник
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Порожній обробник
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            // Перевірка на порожні поля
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                MessageBox.Show("Введіть логін!", "Попередження",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoginTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Введіть пароль!", "Попередження",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordTextBox.Focus();
                return;
            }

            // Показуємо індикатор завантаження
            LoginButton.Enabled = false;
            LoginButton.Text = "Перевірка...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                string username = LoginTextBox.Text.Trim();
                string password = PasswordTextBox.Text;

                // Перевірка логіна і пароля
                bool isValid = await _employeeService.ValidateCredentialsAsync(username, password);

                if (isValid)
                {
                    // Отримуємо дані працівника
                    _currentEmployee = await _employeeService.GetByUsernameAsync(username);

                    if (_currentEmployee != null)
                    {
                        // Перевірка активності
                        if (!_currentEmployee.IsActive)
                        {
                            MessageBox.Show("Ваш акаунт деактивовано. Зверніться до адміністратора.",
                                "Доступ заборонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Успішний вхід
                        MessageBox.Show($"Вітаємо, {_currentEmployee.FirstName} {_currentEmployee.LastName}!\nРоль: {_currentEmployee.Role}",
                            "Успішний вхід", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Зберігаємо поточного користувача в Program (опціонально)
                        //Program.CurrentEmployee = _currentEmployee;

                        // Відкриваємо головну форму (ProductsForm)
                        var productsForm = Program.ServiceProvider.GetRequiredService<ProductsForm>();
                        productsForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    // Невірний логін або пароль
                    MessageBox.Show("Невірний логін або пароль!",
                        "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Очищаємо поле пароля
                    PasswordTextBox.Clear();
                    PasswordTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка підключення до бази даних:\n{ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Повертаємо кнопку в нормальний стан
                LoginButton.Enabled = true;
                LoginButton.Text = "Вхід";
                this.Cursor = Cursors.Default;
            }
        }

        private async void ForgetPasswordLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Створюємо власну форму для введення логіну
            using (var inputForm = new Form())
            {
                inputForm.Text = "Відновлення пароля";
                inputForm.Size = new Size(400, 180);
                inputForm.StartPosition = FormStartPosition.CenterParent;
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputForm.MaximizeBox = false;
                inputForm.MinimizeBox = false;

                var label = new Label
                {
                    Text = "Введіть ваш логін:",
                    Location = new Point(20, 20),
                    Size = new Size(350, 25)
                };

                var textBox = new TextBox
                {
                    Location = new Point(20, 50),
                    Size = new Size(340, 30)
                };

                var okButton = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(20, 90),
                    Size = new Size(150, 35),
                    BackColor = Color.Teal,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                var cancelButton = new Button
                {
                    Text = "Скасувати",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(210, 90),
                    Size = new Size(150, 35),
                    BackColor = Color.Gray,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                inputForm.Controls.AddRange(new Control[] { label, textBox, okButton, cancelButton });
                inputForm.AcceptButton = okButton;
                inputForm.CancelButton = cancelButton;

                if (inputForm.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    string username = textBox.Text.Trim();

                    try
                    {
                        var employee = await _employeeService.GetByUsernameAsync(username);

                        if (employee != null)
                        {
                            if (!employee.IsActive)
                            {
                                MessageBox.Show("Ваш акаунт деактивовано. Зверніться до адміністратора.",
                                    "Доступ заборонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Показуємо email для відновлення
                            if (!string.IsNullOrEmpty(employee.Email))
                            {
                                MessageBox.Show($"Зверніться до адміністратора");
                            }
                            else
                            {
                                MessageBox.Show($"Email не вказано в профілі.\nЗверніться до адміністратора:\n" +
                                    $"Телефон: {employee.Phone ?? "не вказано"}\n" +
                                    $"Ваше ім'я: {employee.FirstName} {employee.LastName}",
                                    "Відновлення пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Користувача з таким логіном не знайдено!",
                                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка: {ex.Message}",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Обробка Enter для входу
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                LoginButton_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}