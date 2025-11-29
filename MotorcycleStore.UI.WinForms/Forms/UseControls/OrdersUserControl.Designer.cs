namespace MotorcycleStore.UI.WinForms.Forms.UseControls
{
    partial class OrdersUserControl
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
            OrderIdLabel = new Label();
            OrdersDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            IdColumn = new DataGridViewTextBoxColumn();
            OrderItemColumn = new DataGridViewTextBoxColumn();
            OrderDateColumn = new DataGridViewTextBoxColumn();
            TotalAmountColumn = new DataGridViewTextBoxColumn();
            StatusColumn = new DataGridViewTextBoxColumn();
            CustomerColumn = new DataGridViewTextBoxColumn();
            EmployeeColumn = new DataGridViewTextBoxColumn();
            PaymentMethodColumn = new DataGridViewTextBoxColumn();
            CommentsColumn = new DataGridViewTextBoxColumn();
            OrderContextMenuStrip = new ContextMenuStrip(components);
            EditStripMenuItem1 = new ToolStripMenuItem();
            DeleteStripMenuItem1 = new ToolStripMenuItem();
            ClearButton = new Button();
            AddButton = new Button();
            SaveButton = new Button();
            PaymentMethodComboBox = new ComboBox();
            label9 = new Label();
            StatusComboBox = new ComboBox();
            label8 = new Label();
            TotalAmountTextBox = new TextBox();
            label7 = new Label();
            label6 = new Label();
            CommentsTextBox = new TextBox();
            label5 = new Label();
            OrderDatePicker = new DateTimePicker();
            label4 = new Label();
            EmployeeComboBox = new ComboBox();
            label3 = new Label();
            CustomerComboBox = new ComboBox();
            label2 = new Label();
            ProductComboBox = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)OrdersDataGridView).BeginInit();
            OrderContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // OrderIdLabel
            // 
            OrderIdLabel.AutoSize = true;
            OrderIdLabel.Font = new Font("Verdana", 12F, FontStyle.Bold);
            OrderIdLabel.Location = new Point(20, 146);
            OrderIdLabel.Name = "OrderIdLabel";
            OrderIdLabel.Size = new Size(0, 25);
            OrderIdLabel.TabIndex = 50;
            // 
            // OrdersDataGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            OrdersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            OrdersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            OrdersDataGridView.ColumnHeadersHeight = 27;
            OrdersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            OrdersDataGridView.Columns.AddRange(new DataGridViewColumn[] { IdColumn, OrderItemColumn, OrderDateColumn, TotalAmountColumn, StatusColumn, CustomerColumn, EmployeeColumn, PaymentMethodColumn, CommentsColumn });
            OrdersDataGridView.ContextMenuStrip = OrderContextMenuStrip;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            OrdersDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            OrdersDataGridView.GridColor = Color.FromArgb(231, 229, 255);
            OrdersDataGridView.Location = new Point(20, 282);
            OrdersDataGridView.Name = "OrdersDataGridView";
            OrdersDataGridView.RowHeadersVisible = false;
            OrdersDataGridView.RowHeadersWidth = 51;
            OrdersDataGridView.Size = new Size(1209, 583);
            OrdersDataGridView.TabIndex = 48;
            OrdersDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            OrdersDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            OrdersDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            OrdersDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            OrdersDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            OrdersDataGridView.ThemeStyle.BackColor = Color.White;
            OrdersDataGridView.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            OrdersDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            OrdersDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            OrdersDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            OrdersDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            OrdersDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            OrdersDataGridView.ThemeStyle.HeaderStyle.Height = 27;
            OrdersDataGridView.ThemeStyle.ReadOnly = false;
            OrdersDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            OrdersDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            OrdersDataGridView.ThemeStyle.RowsStyle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            OrdersDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            OrdersDataGridView.ThemeStyle.RowsStyle.Height = 29;
            OrdersDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            OrdersDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // IdColumn
            // 
            IdColumn.HeaderText = "ID";
            IdColumn.MinimumWidth = 6;
            IdColumn.Name = "IdColumn";
            IdColumn.ReadOnly = true;
            // 
            // OrderItemColumn
            // 
            OrderItemColumn.HeaderText = "Продукт";
            OrderItemColumn.MinimumWidth = 6;
            OrderItemColumn.Name = "OrderItemColumn";
            // 
            // OrderDateColumn
            // 
            OrderDateColumn.HeaderText = "Дата";
            OrderDateColumn.MinimumWidth = 6;
            OrderDateColumn.Name = "OrderDateColumn";
            // 
            // TotalAmountColumn
            // 
            TotalAmountColumn.HeaderText = "Сума";
            TotalAmountColumn.MinimumWidth = 6;
            TotalAmountColumn.Name = "TotalAmountColumn";
            // 
            // StatusColumn
            // 
            StatusColumn.HeaderText = "Статус";
            StatusColumn.MinimumWidth = 6;
            StatusColumn.Name = "StatusColumn";
            // 
            // CustomerColumn
            // 
            CustomerColumn.HeaderText = "Замовник";
            CustomerColumn.MinimumWidth = 6;
            CustomerColumn.Name = "CustomerColumn";
            // 
            // EmployeeColumn
            // 
            EmployeeColumn.HeaderText = "Працівник";
            EmployeeColumn.MinimumWidth = 6;
            EmployeeColumn.Name = "EmployeeColumn";
            // 
            // PaymentMethodColumn
            // 
            PaymentMethodColumn.HeaderText = "Спосіб оплати";
            PaymentMethodColumn.MinimumWidth = 6;
            PaymentMethodColumn.Name = "PaymentMethodColumn";
            // 
            // CommentsColumn
            // 
            CommentsColumn.HeaderText = "Коментар";
            CommentsColumn.MinimumWidth = 6;
            CommentsColumn.Name = "CommentsColumn";
            // 
            // OrderContextMenuStrip
            // 
            OrderContextMenuStrip.ImageScalingSize = new Size(20, 20);
            OrderContextMenuStrip.Items.AddRange(new ToolStripItem[] { EditStripMenuItem1, DeleteStripMenuItem1 });
            OrderContextMenuStrip.Name = "ProductContextMenuStrip";
            OrderContextMenuStrip.Size = new Size(211, 80);
            // 
            // EditStripMenuItem1
            // 
            EditStripMenuItem1.Name = "EditStripMenuItem1";
            EditStripMenuItem1.Size = new Size(210, 24);
            EditStripMenuItem1.Text = "Редагувати";
            EditStripMenuItem1.Click += EditStripMenuItem1_Click;
            // 
            // DeleteStripMenuItem1
            // 
            DeleteStripMenuItem1.Name = "DeleteStripMenuItem1";
            DeleteStripMenuItem1.Size = new Size(210, 24);
            DeleteStripMenuItem1.Text = "Видалити";
            DeleteStripMenuItem1.Click += DeleteStripMenuItem1_Click;
            // 
            // ClearButton
            // 
            ClearButton.BackColor = Color.Crimson;
            ClearButton.FlatAppearance.BorderSize = 0;
            ClearButton.FlatStyle = FlatStyle.Flat;
            ClearButton.ForeColor = Color.White;
            ClearButton.Location = new Point(711, 218);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(206, 35);
            ClearButton.TabIndex = 47;
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
            AddButton.Location = new Point(484, 218);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(206, 35);
            AddButton.TabIndex = 46;
            AddButton.Text = "Створити";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.LightSeaGreen;
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(264, 218);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(206, 35);
            SaveButton.TabIndex = 45;
            SaveButton.Text = "Зберегти зміни";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // PaymentMethodComboBox
            // 
            PaymentMethodComboBox.FormattingEnabled = true;
            PaymentMethodComboBox.Location = new Point(468, 146);
            PaymentMethodComboBox.Name = "PaymentMethodComboBox";
            PaymentMethodComboBox.Size = new Size(203, 33);
            PaymentMethodComboBox.TabIndex = 42;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(19, 117);
            label9.Name = "label9";
            label9.Size = new Size(58, 25);
            label9.TabIndex = 38;
            label9.Text = "ID #";
            // 
            // StatusComboBox
            // 
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Location = new Point(1026, 64);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(203, 33);
            StatusComboBox.TabIndex = 37;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(242, 117);
            label8.Name = "label8";
            label8.Size = new Size(123, 25);
            label8.TabIndex = 39;
            label8.Text = "Сума (грн)";
            // 
            // TotalAmountTextBox
            // 
            TotalAmountTextBox.BorderStyle = BorderStyle.FixedSingle;
            TotalAmountTextBox.Location = new Point(243, 146);
            TotalAmountTextBox.Name = "TotalAmountTextBox";
            TotalAmountTextBox.Size = new Size(203, 32);
            TotalAmountTextBox.TabIndex = 40;
            TotalAmountTextBox.Text = "0.00";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(467, 117);
            label7.Name = "label7";
            label7.Size = new Size(159, 25);
            label7.TabIndex = 41;
            label7.Text = "Спосіб оплати";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(690, 117);
            label6.Name = "label6";
            label6.Size = new Size(111, 25);
            label6.TabIndex = 43;
            label6.Text = "Коментар";
            // 
            // CommentsTextBox
            // 
            CommentsTextBox.BorderStyle = BorderStyle.FixedSingle;
            CommentsTextBox.Location = new Point(691, 146);
            CommentsTextBox.Multiline = true;
            CommentsTextBox.Name = "CommentsTextBox";
            CommentsTextBox.Size = new Size(424, 32);
            CommentsTextBox.TabIndex = 44;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1025, 35);
            label5.Name = "label5";
            label5.Size = new Size(81, 25);
            label5.TabIndex = 36;
            label5.Text = "Статус";
            // 
            // OrderDatePicker
            // 
            OrderDatePicker.Format = DateTimePickerFormat.Short;
            OrderDatePicker.Location = new Point(802, 64);
            OrderDatePicker.Name = "OrderDatePicker";
            OrderDatePicker.Size = new Size(204, 32);
            OrderDatePicker.TabIndex = 35;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(802, 35);
            label4.Name = "label4";
            label4.Size = new Size(175, 25);
            label4.TabIndex = 34;
            label4.Text = "Дата створення";
            // 
            // EmployeeComboBox
            // 
            EmployeeComboBox.FormattingEnabled = true;
            EmployeeComboBox.Location = new Point(578, 64);
            EmployeeComboBox.Name = "EmployeeComboBox";
            EmployeeComboBox.Size = new Size(203, 33);
            EmployeeComboBox.TabIndex = 33;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(577, 35);
            label3.Name = "label3";
            label3.Size = new Size(120, 25);
            label3.TabIndex = 32;
            label3.Text = "Працівник";
            // 
            // CustomerComboBox
            // 
            CustomerComboBox.FormattingEnabled = true;
            CustomerComboBox.Location = new Point(355, 64);
            CustomerComboBox.Name = "CustomerComboBox";
            CustomerComboBox.Size = new Size(203, 33);
            CustomerComboBox.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(354, 35);
            label2.Name = "label2";
            label2.Size = new Size(112, 25);
            label2.TabIndex = 30;
            label2.Text = "Замовник";
            // 
            // ProductComboBox
            // 
            ProductComboBox.FormattingEnabled = true;
            ProductComboBox.Location = new Point(20, 63);
            ProductComboBox.Name = "ProductComboBox";
            ProductComboBox.Size = new Size(311, 33);
            ProductComboBox.TabIndex = 52;
            ProductComboBox.SelectedIndexChanged += ProductComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 34);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 51;
            label1.Text = "Продукт";
            // 
            // OrdersUserControl
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ProductComboBox);
            Controls.Add(label1);
            Controls.Add(OrderIdLabel);
            Controls.Add(OrdersDataGridView);
            Controls.Add(ClearButton);
            Controls.Add(AddButton);
            Controls.Add(SaveButton);
            Controls.Add(PaymentMethodComboBox);
            Controls.Add(label9);
            Controls.Add(StatusComboBox);
            Controls.Add(label8);
            Controls.Add(TotalAmountTextBox);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(CommentsTextBox);
            Controls.Add(label5);
            Controls.Add(OrderDatePicker);
            Controls.Add(label4);
            Controls.Add(EmployeeComboBox);
            Controls.Add(label3);
            Controls.Add(CustomerComboBox);
            Controls.Add(label2);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 4, 5, 4);
            Name = "OrdersUserControl";
            Size = new Size(1249, 907);
            ((System.ComponentModel.ISupportInitialize)OrdersDataGridView).EndInit();
            OrderContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OrderIdLabel;
        private Guna.UI2.WinForms.Guna2DataGridView OrdersDataGridView;
        private Button ClearButton;
        private Button AddButton;
        private Button SaveButton;
        private ComboBox PaymentMethodComboBox;
        private Label label9;
        private ComboBox StatusComboBox;
        private Label label8;
        private TextBox TotalAmountTextBox;
        private Label label7;
        private Label label6;
        private TextBox CommentsTextBox;
        private Label label5;
        private DateTimePicker OrderDatePicker;
        private Label label4;
        private ComboBox EmployeeComboBox;
        private Label label3;
        private ComboBox CustomerComboBox;
        private Label label2;
        private ContextMenuStrip OrderContextMenuStrip;
        private ToolStripMenuItem EditStripMenuItem1;
        private ToolStripMenuItem DeleteStripMenuItem1;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewTextBoxColumn OrderItemColumn;
        private DataGridViewTextBoxColumn OrderDateColumn;
        private DataGridViewTextBoxColumn TotalAmountColumn;
        private DataGridViewTextBoxColumn StatusColumn;
        private DataGridViewTextBoxColumn CustomerColumn;
        private DataGridViewTextBoxColumn EmployeeColumn;
        private DataGridViewTextBoxColumn PaymentMethodColumn;
        private DataGridViewTextBoxColumn CommentsColumn;
        private ComboBox ProductComboBox;
        private Label label1;
    }
}
