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
        private bool _isPasswordVisible = false;

        public LoginForm(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;


            PasswordTextBox.PasswordChar = '●';
            PasswordTextBox.UseSystemPasswordChar = false;

            SetupPasswordToggle();
        }

        private void SetupPasswordToggle()
        {

            var eyeIcon = new PictureBox
            {
                Size = new Size(25, 25),
                Location = new Point(PasswordTextBox.Right - 30, PasswordTextBox.Top + 4),
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand,
                BackColor = Color.White
            };


            eyeIcon.Image = CreateEyeClosedIcon();


            eyeIcon.Click += EyeIcon_Click;

            this.Controls.Add(eyeIcon);
            eyeIcon.BringToFront();

            eyeIcon.Tag = "eyeIcon";
        }

        private void EyeIcon_Click(object sender, EventArgs e)
        {
            var eyeIcon = sender as PictureBox;
            if (eyeIcon == null) return;

            _isPasswordVisible = !_isPasswordVisible;

            if (_isPasswordVisible)
            {

                PasswordTextBox.PasswordChar = '\0';
                eyeIcon.Image = CreateEyeOpenIcon();
            }
            else
            {

                PasswordTextBox.PasswordChar = '●';
                eyeIcon.Image = CreateEyeClosedIcon();
            }
        }


        private Image CreateEyeOpenIcon()
        {
            var bitmap = new Bitmap(24, 24);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

 
                using (var pen = new Pen(Color.Gray, 2))
                {

                    g.DrawEllipse(pen, 6, 8, 12, 8);

                    g.FillEllipse(new SolidBrush(Color.Gray), 10, 10, 4, 4);
                }
            }
            return bitmap;
        }


        private Image CreateEyeClosedIcon()
        {
            var bitmap = new Bitmap(24, 24);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


                using (var pen = new Pen(Color.Gray, 2))
                {

                    g.DrawArc(pen, 6, 8, 12, 8, 0, 180);

                    g.DrawLine(pen, 4, 18, 20, 6);
                }
            }
            return bitmap;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
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

            LoginButton.Enabled = false;
            LoginButton.Text = "Перевірка...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                string username = LoginTextBox.Text.Trim();
                string password = PasswordTextBox.Text;

                bool isValid = await _employeeService.ValidateCredentialsAsync(username, password);

                if (isValid)
                {
                    _currentEmployee = await _employeeService.GetByUsernameAsync(username);

                    if (_currentEmployee != null)
                    {
                        if (!_currentEmployee.IsActive)
                        {
                            MessageBox.Show("Ваш акаунт деактивовано. Зверніться до адміністратора.",
                                "Доступ заборонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        MessageBox.Show($"Вітаємо, {_currentEmployee.FirstName} {_currentEmployee.LastName}!\nРоль: {_currentEmployee.Role}",
                            "Успішний вхід", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var mainForm = new MainForm(
                            Program.ServiceProvider.GetRequiredService<IProductService>(),
                            Program.ServiceProvider.GetRequiredService<IOrderService>(),
                            Program.ServiceProvider.GetRequiredService<ICustomerService>(),
                            Program.ServiceProvider.GetRequiredService<IEmployeeService>(),
                            _currentEmployee
                        );
                        mainForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Невірний логін або пароль!",
                        "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                LoginButton.Enabled = true;
                LoginButton.Text = "Вхід";
                this.Cursor = Cursors.Default;
            }
        }

        private async void ForgetPasswordLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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

                            if (!string.IsNullOrEmpty(employee.Email))
                            {
                                MessageBox.Show($"Зверніться до адміністратора для відновлення пароля.\n\n" +
                                    $"Email: {employee.Email}\n" +
                                    $"Телефон: {employee.Phone ?? "не вказано"}",
                                    "Відновлення пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                LoginButton_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}