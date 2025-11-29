namespace MotorcycleStore.UI.WinForms.Forms.UseControls
{
    partial class CustomersUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            SearchButton = new Button();
            SearchTextBox = new TextBox();
            label9 = new Label();
            CustomersDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            IdColumn = new DataGridViewTextBoxColumn();
            FirstNameColumn = new DataGridViewTextBoxColumn();
            LastNameColumn = new DataGridViewTextBoxColumn();
            PhoneColumn = new DataGridViewTextBoxColumn();
            EmailColumn = new DataGridViewTextBoxColumn();
            AddressColumn = new DataGridViewTextBoxColumn();
            RegisteredAtColumn = new DataGridViewTextBoxColumn();
            CustomersContextMenuStrip = new ContextMenuStrip(components);
            EditStripMenuItem1 = new ToolStripMenuItem();
            DeleteStripMenuItem1 = new ToolStripMenuItem();
            ClearButton = new Button();
            AddButton = new Button();
            SaveButton = new Button();
            RegisteredAtPicker = new DateTimePicker();
            EmailTextBox = new TextBox();
            label7 = new Label();
            label6 = new Label();
            AddressTextBox = new TextBox();
            label5 = new Label();
            PhoneTextBox = new TextBox();
            label4 = new Label();
            LastNameTextBox = new TextBox();
            label3 = new Label();
            FirstNameTextBox = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)CustomersDataGridView).BeginInit();
            CustomersContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.DodgerBlue;
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.ForeColor = Color.White;
            SearchButton.Location = new Point(1042, 202);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(100, 35);
            SearchButton.TabIndex = 52;
            SearchButton.Text = "🔍";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click_1;
            // 
            // SearchTextBox
            // 
            SearchTextBox.BorderStyle = BorderStyle.FixedSingle;
            SearchTextBox.Location = new Point(786, 202);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.PlaceholderText = "Ім'я, телефон, email...";
            SearchTextBox.Size = new Size(250, 32);
            SearchTextBox.TabIndex = 51;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(701, 205);
            label9.Name = "label9";
            label9.Size = new Size(81, 25);
            label9.TabIndex = 50;
            label9.Text = "Пошук";
            // 
            // CustomersDataGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            CustomersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            CustomersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            CustomersDataGridView.ColumnHeadersHeight = 27;
            CustomersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            CustomersDataGridView.Columns.AddRange(new DataGridViewColumn[] { IdColumn, FirstNameColumn, LastNameColumn, PhoneColumn, EmailColumn, AddressColumn, RegisteredAtColumn });
            CustomersDataGridView.ContextMenuStrip = CustomersContextMenuStrip;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            CustomersDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            CustomersDataGridView.GridColor = Color.FromArgb(231, 229, 255);
            CustomersDataGridView.Location = new Point(30, 277);
            CustomersDataGridView.Name = "CustomersDataGridView";
            CustomersDataGridView.RowHeadersVisible = false;
            CustomersDataGridView.RowHeadersWidth = 51;
            CustomersDataGridView.Size = new Size(1209, 583);
            CustomersDataGridView.TabIndex = 48;
            CustomersDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            CustomersDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            CustomersDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            CustomersDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            CustomersDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            CustomersDataGridView.ThemeStyle.BackColor = Color.White;
            CustomersDataGridView.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            CustomersDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            CustomersDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            CustomersDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CustomersDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            CustomersDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            CustomersDataGridView.ThemeStyle.HeaderStyle.Height = 27;
            CustomersDataGridView.ThemeStyle.ReadOnly = false;
            CustomersDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            CustomersDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            CustomersDataGridView.ThemeStyle.RowsStyle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CustomersDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            CustomersDataGridView.ThemeStyle.RowsStyle.Height = 29;
            CustomersDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            CustomersDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // IdColumn
            // 
            IdColumn.HeaderText = "ID";
            IdColumn.MinimumWidth = 6;
            IdColumn.Name = "IdColumn";
            IdColumn.ReadOnly = true;
            IdColumn.Visible = false;
            // 
            // FirstNameColumn
            // 
            FirstNameColumn.HeaderText = "Ім'я";
            FirstNameColumn.MinimumWidth = 6;
            FirstNameColumn.Name = "FirstNameColumn";
            // 
            // LastNameColumn
            // 
            LastNameColumn.HeaderText = "Прізвище";
            LastNameColumn.MinimumWidth = 6;
            LastNameColumn.Name = "LastNameColumn";
            // 
            // PhoneColumn
            // 
            PhoneColumn.HeaderText = "Телефон";
            PhoneColumn.MinimumWidth = 6;
            PhoneColumn.Name = "PhoneColumn";
            // 
            // EmailColumn
            // 
            EmailColumn.HeaderText = "Email";
            EmailColumn.MinimumWidth = 6;
            EmailColumn.Name = "EmailColumn";
            // 
            // AddressColumn
            // 
            AddressColumn.HeaderText = "Адреса";
            AddressColumn.MinimumWidth = 6;
            AddressColumn.Name = "AddressColumn";
            // 
            // RegisteredAtColumn
            // 
            RegisteredAtColumn.HeaderText = "Дата реєстрації";
            RegisteredAtColumn.MinimumWidth = 6;
            RegisteredAtColumn.Name = "RegisteredAtColumn";
            // 
            // CustomersContextMenuStrip
            // 
            CustomersContextMenuStrip.ImageScalingSize = new Size(20, 20);
            CustomersContextMenuStrip.Items.AddRange(new ToolStripItem[] { EditStripMenuItem1, DeleteStripMenuItem1 });
            CustomersContextMenuStrip.Name = "ProductContextMenuStrip";
            CustomersContextMenuStrip.Size = new Size(155, 52);
            // 
            // EditStripMenuItem1
            // 
            EditStripMenuItem1.Name = "EditStripMenuItem1";
            EditStripMenuItem1.Size = new Size(154, 24);
            EditStripMenuItem1.Text = "Редагувати";
            EditStripMenuItem1.Click += EditStripMenuItem1_Click;
            // 
            // DeleteStripMenuItem1
            // 
            DeleteStripMenuItem1.Name = "DeleteStripMenuItem1";
            DeleteStripMenuItem1.Size = new Size(154, 24);
            DeleteStripMenuItem1.Text = "Видалити";
            DeleteStripMenuItem1.Click += DeleteStripMenuItem1_Click;
            // 
            // ClearButton
            // 
            ClearButton.BackColor = Color.Crimson;
            ClearButton.FlatAppearance.BorderSize = 0;
            ClearButton.FlatStyle = FlatStyle.Flat;
            ClearButton.ForeColor = Color.White;
            ClearButton.Location = new Point(477, 202);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(206, 35);
            ClearButton.TabIndex = 47;
            ClearButton.Text = "Очистити";
            ClearButton.UseVisualStyleBackColor = false;
            ClearButton.Click += ClearButton_Click_1;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.Teal;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.ForeColor = Color.White;
            AddButton.Location = new Point(250, 202);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(206, 35);
            AddButton.TabIndex = 46;
            AddButton.Text = "Додати";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click_1;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.LightSeaGreen;
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(30, 202);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(206, 35);
            SaveButton.TabIndex = 45;
            SaveButton.Text = "Зберегти зміни";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click_1;
            // 
            // RegisteredAtPicker
            // 
            RegisteredAtPicker.Format = DateTimePickerFormat.Short;
            RegisteredAtPicker.Location = new Point(478, 138);
            RegisteredAtPicker.Name = "RegisteredAtPicker";
            RegisteredAtPicker.Size = new Size(203, 32);
            RegisteredAtPicker.TabIndex = 42;
            // 
            // EmailTextBox
            // 
            EmailTextBox.BorderStyle = BorderStyle.FixedSingle;
            EmailTextBox.Location = new Point(701, 62);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(424, 32);
            EmailTextBox.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(477, 109);
            label7.Name = "label7";
            label7.Size = new Size(173, 25);
            label7.TabIndex = 41;
            label7.Text = "Дата реєстрації";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 109);
            label6.Name = "label6";
            label6.Size = new Size(85, 25);
            label6.TabIndex = 43;
            label6.Text = "Адреса";
            // 
            // AddressTextBox
            // 
            AddressTextBox.BorderStyle = BorderStyle.FixedSingle;
            AddressTextBox.Location = new Point(30, 138);
            AddressTextBox.Multiline = true;
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(424, 32);
            AddressTextBox.TabIndex = 44;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(700, 33);
            label5.Name = "label5";
            label5.Size = new Size(68, 25);
            label5.TabIndex = 38;
            label5.Text = "Email";
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.BorderStyle = BorderStyle.FixedSingle;
            PhoneTextBox.Location = new Point(477, 62);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(204, 32);
            PhoneTextBox.TabIndex = 37;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(477, 33);
            label4.Name = "label4";
            label4.Size = new Size(102, 25);
            label4.TabIndex = 36;
            label4.Text = "Телефон";
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            LastNameTextBox.Location = new Point(253, 62);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new Size(203, 32);
            LastNameTextBox.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(252, 33);
            label3.Name = "label3";
            label3.Size = new Size(110, 25);
            label3.TabIndex = 34;
            label3.Text = "Прізвище";
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            FirstNameTextBox.Location = new Point(30, 62);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.Size = new Size(203, 32);
            FirstNameTextBox.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 33);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 32;
            label2.Text = "Ім'я";
            // 
            // CustomersUserControl
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(label9);
            Controls.Add(CustomersDataGridView);
            Controls.Add(ClearButton);
            Controls.Add(AddButton);
            Controls.Add(SaveButton);
            Controls.Add(RegisteredAtPicker);
            Controls.Add(EmailTextBox);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(AddressTextBox);
            Controls.Add(label5);
            Controls.Add(PhoneTextBox);
            Controls.Add(label4);
            Controls.Add(LastNameTextBox);
            Controls.Add(label3);
            Controls.Add(FirstNameTextBox);
            Controls.Add(label2);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 4, 5, 4);
            Name = "CustomersUserControl";
            Size = new Size(1249, 907);
            ((System.ComponentModel.ISupportInitialize)CustomersDataGridView).EndInit();
            CustomersContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SearchButton;
        private TextBox SearchTextBox;
        private Label label9;
        private Guna.UI2.WinForms.Guna2DataGridView CustomersDataGridView;
        private Button ClearButton;
        private Button AddButton;
        private Button SaveButton;
        private DateTimePicker RegisteredAtPicker;
        private TextBox EmailTextBox;
        private Label label7;
        private Label label6;
        private TextBox AddressTextBox;
        private Label label5;
        private TextBox PhoneTextBox;
        private Label label4;
        private TextBox LastNameTextBox;
        private Label label3;
        private TextBox FirstNameTextBox;
        private Label label2;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewTextBoxColumn FirstNameColumn;
        private DataGridViewTextBoxColumn LastNameColumn;
        private DataGridViewTextBoxColumn PhoneColumn;
        private DataGridViewTextBoxColumn EmailColumn;
        private DataGridViewTextBoxColumn AddressColumn;
        private DataGridViewTextBoxColumn RegisteredAtColumn;
        private ContextMenuStrip CustomersContextMenuStrip;
        private ToolStripMenuItem EditStripMenuItem1;
        private ToolStripMenuItem DeleteStripMenuItem1;
    }
}
