namespace MotorcycleStore.UI.WinForms.Forms.UseControls
{
    partial class EmployeesUserControl
    {
     
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            SearchButton = new Button();
            SearchTextBox = new TextBox();
            label19 = new Label();
            RoleComboBox = new ComboBox();
            PasswordTextBox = new TextBox();
            label10 = new Label();
            UsernameTextBox = new TextBox();
            label9 = new Label();
            EmployeesDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            IdColumn = new DataGridViewTextBoxColumn();
            FirstNameColumn = new DataGridViewTextBoxColumn();
            LastNameColumn = new DataGridViewTextBoxColumn();
            PhoneColumn = new DataGridViewTextBoxColumn();
            EmailColumn = new DataGridViewTextBoxColumn();
            UsernameColumn = new DataGridViewTextBoxColumn();
            RoleColumn = new DataGridViewTextBoxColumn();
            HiredAtColumn = new DataGridViewTextBoxColumn();
            EmployeeContextMenuStrip = new ContextMenuStrip(components);
            EditStripMenuItem1 = new ToolStripMenuItem();
            DeleteStripMenuItem1 = new ToolStripMenuItem();
            ClearButton = new Button();
            AddButton = new Button();
            SaveButton = new Button();
            HiredAtPicker = new DateTimePicker();
            label8 = new Label();
            EmailTextBox = new TextBox();
            label7 = new Label();
            label5 = new Label();
            PhoneTextBox = new TextBox();
            label4 = new Label();
            LastNameTextBox = new TextBox();
            label3 = new Label();
            FirstNameTextBox = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)EmployeesDataGridView).BeginInit();
            EmployeeContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.DodgerBlue;
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.ForeColor = Color.White;
            SearchButton.Location = new Point(1128, 211);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(100, 35);
            SearchButton.TabIndex = 64;
            SearchButton.Text = "🔍";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.BorderStyle = BorderStyle.FixedSingle;
            SearchTextBox.Location = new Point(872, 211);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.PlaceholderText = " Ім'я, логін...";
            SearchTextBox.Size = new Size(250, 32);
            SearchTextBox.TabIndex = 63;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(787, 214);
            label19.Name = "label19";
            label19.Size = new Size(81, 25);
            label19.TabIndex = 62;
            label19.Text = "Пошук";
            // 
            // RoleComboBox
            // 
            RoleComboBox.FormattingEnabled = true;
            RoleComboBox.Location = new Point(690, 146);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(203, 33);
            RoleComboBox.TabIndex = 60;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.BorderStyle = BorderStyle.FixedSingle;
            PasswordTextBox.Location = new Point(243, 146);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '●';
            PasswordTextBox.Size = new Size(203, 32);
            PasswordTextBox.TabIndex = 58;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(242, 117);
            label10.Name = "label10";
            label10.Size = new Size(86, 25);
            label10.TabIndex = 57;
            label10.Text = "Пароль";
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.BorderStyle = BorderStyle.FixedSingle;
            UsernameTextBox.Location = new Point(20, 146);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(203, 32);
            UsernameTextBox.TabIndex = 56;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(19, 117);
            label9.Name = "label9";
            label9.Size = new Size(67, 25);
            label9.TabIndex = 55;
            label9.Text = "Логін";
            // 
            // EmployeesDataGridView
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            EmployeesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            EmployeesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            EmployeesDataGridView.ColumnHeadersHeight = 27;
            EmployeesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            EmployeesDataGridView.Columns.AddRange(new DataGridViewColumn[] { IdColumn, FirstNameColumn, LastNameColumn, PhoneColumn, EmailColumn, UsernameColumn, RoleColumn, HiredAtColumn });
            EmployeesDataGridView.ContextMenuStrip = EmployeeContextMenuStrip;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            EmployeesDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            EmployeesDataGridView.GridColor = Color.FromArgb(231, 229, 255);
            EmployeesDataGridView.Location = new Point(20, 282);
            EmployeesDataGridView.Name = "EmployeesDataGridView";
            EmployeesDataGridView.RowHeadersVisible = false;
            EmployeesDataGridView.RowHeadersWidth = 51;
            EmployeesDataGridView.Size = new Size(1209, 583);
            EmployeesDataGridView.TabIndex = 54;
            EmployeesDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            EmployeesDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            EmployeesDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            EmployeesDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            EmployeesDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            EmployeesDataGridView.ThemeStyle.BackColor = Color.White;
            EmployeesDataGridView.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            EmployeesDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            EmployeesDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            EmployeesDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            EmployeesDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            EmployeesDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            EmployeesDataGridView.ThemeStyle.HeaderStyle.Height = 27;
            EmployeesDataGridView.ThemeStyle.ReadOnly = false;
            EmployeesDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            EmployeesDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            EmployeesDataGridView.ThemeStyle.RowsStyle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            EmployeesDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            EmployeesDataGridView.ThemeStyle.RowsStyle.Height = 29;
            EmployeesDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            EmployeesDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
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
            // UsernameColumn
            // 
            UsernameColumn.HeaderText = "Логін";
            UsernameColumn.MinimumWidth = 6;
            UsernameColumn.Name = "UsernameColumn";
            // 
            // RoleColumn
            // 
            RoleColumn.HeaderText = "Роль";
            RoleColumn.MinimumWidth = 6;
            RoleColumn.Name = "RoleColumn";
            // 
            // HiredAtColumn
            // 
            HiredAtColumn.HeaderText = "Дата прийому";
            HiredAtColumn.MinimumWidth = 6;
            HiredAtColumn.Name = "HiredAtColumn";
            // 
            // EmployeeContextMenuStrip
            // 
            EmployeeContextMenuStrip.ImageScalingSize = new Size(20, 20);
            EmployeeContextMenuStrip.Items.AddRange(new ToolStripItem[] { EditStripMenuItem1, DeleteStripMenuItem1 });
            EmployeeContextMenuStrip.Name = "ProductContextMenuStrip";
            EmployeeContextMenuStrip.Size = new Size(155, 52);
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
            ClearButton.Location = new Point(467, 210);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(206, 35);
            ClearButton.TabIndex = 53;
            ClearButton.Text = "Очистити";
            ClearButton.UseVisualStyleBackColor = false;
            ClearButton.Click += ClearButton_Click;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.Teal;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.ForeColor = Color.White;
            AddButton.Location = new Point(240, 210);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(206, 35);
            AddButton.TabIndex = 52;
            AddButton.Text = "Додати";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.LightSeaGreen;
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(20, 210);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(206, 35);
            SaveButton.TabIndex = 51;
            SaveButton.Text = "Зберегти зміни";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click_1;
            // 
            // HiredAtPicker
            // 
            HiredAtPicker.Format = DateTimePickerFormat.Short;
            HiredAtPicker.Location = new Point(468, 146);
            HiredAtPicker.Name = "HiredAtPicker";
            HiredAtPicker.Size = new Size(203, 32);
            HiredAtPicker.TabIndex = 48;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(689, 117);
            label8.Name = "label8";
            label8.Size = new Size(59, 25);
            label8.TabIndex = 46;
            label8.Text = "Роль";
            // 
            // EmailTextBox
            // 
            EmailTextBox.BorderStyle = BorderStyle.FixedSingle;
            EmailTextBox.Location = new Point(691, 70);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(203, 32);
            EmailTextBox.TabIndex = 45;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(467, 117);
            label7.Name = "label7";
            label7.Size = new Size(157, 25);
            label7.TabIndex = 47;
            label7.Text = "Дата прийому";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(690, 41);
            label5.Name = "label5";
            label5.Size = new Size(68, 25);
            label5.TabIndex = 44;
            label5.Text = "Email";
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.BorderStyle = BorderStyle.FixedSingle;
            PhoneTextBox.Location = new Point(467, 70);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(204, 32);
            PhoneTextBox.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(467, 41);
            label4.Name = "label4";
            label4.Size = new Size(102, 25);
            label4.TabIndex = 42;
            label4.Text = "Телефон";
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            LastNameTextBox.Location = new Point(243, 70);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new Size(203, 32);
            LastNameTextBox.TabIndex = 41;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(242, 41);
            label3.Name = "label3";
            label3.Size = new Size(110, 25);
            label3.TabIndex = 40;
            label3.Text = "Прізвище";
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            FirstNameTextBox.Location = new Point(20, 70);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.Size = new Size(203, 32);
            FirstNameTextBox.TabIndex = 39;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 41);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 38;
            label2.Text = "Ім'я";
            // 
            // EmployeesUserControl
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(label19);
            Controls.Add(RoleComboBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(label10);
            Controls.Add(UsernameTextBox);
            Controls.Add(label9);
            Controls.Add(EmployeesDataGridView);
            Controls.Add(ClearButton);
            Controls.Add(AddButton);
            Controls.Add(SaveButton);
            Controls.Add(HiredAtPicker);
            Controls.Add(label8);
            Controls.Add(EmailTextBox);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(PhoneTextBox);
            Controls.Add(label4);
            Controls.Add(LastNameTextBox);
            Controls.Add(label3);
            Controls.Add(FirstNameTextBox);
            Controls.Add(label2);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 4, 5, 4);
            Name = "EmployeesUserControl";
            Size = new Size(1249, 907);
            ((System.ComponentModel.ISupportInitialize)EmployeesDataGridView).EndInit();
            EmployeeContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SearchButton;
        private TextBox SearchTextBox;
        private Label label19;
        private ComboBox RoleComboBox;
        private TextBox PasswordTextBox;
        private Label label10;
        private TextBox UsernameTextBox;
        private Label label9;
        private Guna.UI2.WinForms.Guna2DataGridView EmployeesDataGridView;
        private Button ClearButton;
        private Button AddButton;
        private Button SaveButton;
        private DateTimePicker HiredAtPicker;
        private Label label8;
        private TextBox EmailTextBox;
        private Label label7;
        private Label label5;
        private TextBox PhoneTextBox;
        private Label label4;
        private TextBox LastNameTextBox;
        private Label label3;
        private TextBox FirstNameTextBox;
        private Label label2;
        private ContextMenuStrip EmployeeContextMenuStrip;
        private ToolStripMenuItem EditStripMenuItem1;
        private ToolStripMenuItem DeleteStripMenuItem1;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewTextBoxColumn FirstNameColumn;
        private DataGridViewTextBoxColumn LastNameColumn;
        private DataGridViewTextBoxColumn PhoneColumn;
        private DataGridViewTextBoxColumn EmailColumn;
        private DataGridViewTextBoxColumn UsernameColumn;
        private DataGridViewTextBoxColumn RoleColumn;
        private DataGridViewTextBoxColumn HiredAtColumn;
    }
}
