using Guna.UI2.WinForms;
using MotorcycleStore.Application.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms.Forms.UseControls
{
    public class CallbacksUserControl : UserControl
    {
        private const int GridTop = 100;

        private readonly ICallbackRequestService _callbackRequestService;
        private readonly Label _newCountLabel;
        private readonly Button _refreshButton;
        private readonly Button _markProcessedButton;
        private readonly Guna2DataGridView _grid;
        private int? _selectedId;

        public CallbacksUserControl(ICallbackRequestService callbackRequestService)
        {
            _callbackRequestService = callbackRequestService;

            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Size = new Size(1249, 907);

            _newCountLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Verdana", 12F, FontStyle.Bold),
                Location = new Point(20, 20),
                Text = "Нових запитів: 0"
            };

            _refreshButton = CreateButton("Оновити", Color.DodgerBlue, new Point(20, 55), 160);
            _refreshButton.Click += async (_, _) => await LoadCallbacksAsync();

            _markProcessedButton = CreateButton("Позначити обробленим", Color.Teal, new Point(196, 55), 220);
            _markProcessedButton.Enabled = false;
            _markProcessedButton.Click += async (_, _) => await MarkProcessedAsync();

            _grid = CreateGrid();
            _grid.CellClick += Grid_CellClick;
            LayoutGrid();

            Controls.Add(_grid);
            Controls.Add(_markProcessedButton);
            Controls.Add(_refreshButton);
            Controls.Add(_newCountLabel);

            Resize += (_, _) => LayoutGrid();

            Load += async (_, _) => await LoadCallbacksAsync();
        }

        private Guna2DataGridView CreateGrid()
        {
            var grid = new Guna2DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 27,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            grid.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "№", FillWeight = 8 },
                new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Ім'я", FillWeight = 15 },
                new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Телефон", FillWeight = 15 },
                new DataGridViewTextBoxColumn { Name = "PreferredTime", HeaderText = "Зручний час", FillWeight = 15 },
                new DataGridViewTextBoxColumn { Name = "Message", HeaderText = "Повідомлення", FillWeight = 25 },
                new DataGridViewTextBoxColumn { Name = "CreatedAt", HeaderText = "Дата", FillWeight = 15 },
                new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Статус", FillWeight = 12 }
            );

            grid.ThemeStyle.BackColor = Color.White;
            grid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            grid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            grid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            grid.ThemeStyle.HeaderStyle.Height = 27;
            grid.ThemeStyle.RowsStyle.BackColor = Color.White;
            grid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            grid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            grid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);

            return grid;
        }

        private void LayoutGrid()
        {
            _grid.Location = new Point(20, GridTop);
            _grid.Size = new Size(
                Math.Max(200, ClientSize.Width - 40),
                Math.Max(200, ClientSize.Height - GridTop - 20));
        }

        private static Button CreateButton(string text, Color backColor, Point location, int width)
        {
            return new Button
            {
                BackColor = backColor,
                FlatAppearance = { BorderSize = 0 },
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Location = location,
                Size = new Size(width, 35),
                Text = text,
                UseVisualStyleBackColor = false
            };
        }

        private async System.Threading.Tasks.Task LoadCallbacksAsync()
        {
            try
            {
                var callbacks = await _callbackRequestService.GetAllAsync();
                _grid.Rows.Clear();

                foreach (var callback in callbacks)
                {
                    var rowIndex = _grid.Rows.Add(
                        callback.Id,
                        callback.Name,
                        callback.Phone,
                        callback.PreferredTime ?? "—",
                        callback.Message ?? "—",
                        callback.CreatedAt.ToString("dd.MM.yyyy HH:mm"),
                        callback.IsProcessed ? "Оброблено" : "Новий"
                    );

                    if (!callback.IsProcessed)
                    {
                        var row = _grid.Rows[rowIndex];
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 237, 213);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(154, 52, 18);
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 215, 170);
                        row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(124, 45, 18);
                    }
                }

                _newCountLabel.Text = $"Нових запитів: {callbacks.Count(c => !c.IsProcessed)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження дзвінків: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _selectedId = Convert.ToInt32(_grid.Rows[e.RowIndex].Cells[0].Value);
            _markProcessedButton.Enabled = _grid.Rows[e.RowIndex].Cells[6].Value?.ToString() == "Новий";
        }

        private async System.Threading.Tasks.Task MarkProcessedAsync()
        {
            if (_selectedId is null)
            {
                MessageBox.Show("Виберіть запит у таблиці!",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updated = await _callbackRequestService.MarkProcessedAsync(_selectedId.Value);
            if (!updated)
            {
                MessageBox.Show("Не вдалося оновити статус!",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await LoadCallbacksAsync();
            _selectedId = null;
            _markProcessedButton.Enabled = false;
        }
    }
}
