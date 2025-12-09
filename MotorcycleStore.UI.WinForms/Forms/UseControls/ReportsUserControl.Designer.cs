namespace MotorcycleStore.UI.WinForms.Forms.UseControls
{
    partial class ReportsUserControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            receiptTab = new TabPage();
            SearchReceiptButton = new Button();
            SearchReceiptTextBox = new TextBox();
            label4 = new Label();
            PrintReceiptButton = new Button();
            ReceiptsDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            label2 = new Label();
            salesReportTab = new TabPage();
            QuickReportWeekButton = new Button();
            QuickReportTodayButton = new Button();
            GenerateReportButton = new Button();
            EndDatePicker = new DateTimePicker();
            label7 = new Label();
            StartDatePicker = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            tabControl1.SuspendLayout();
            receiptTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReceiptsDataGridView).BeginInit();
            salesReportTab.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(receiptTab);
            tabControl1.Controls.Add(salesReportTab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1249, 907);
            tabControl1.TabIndex = 0;
            // 
            // receiptTab
            // 
            receiptTab.BackColor = Color.White;
            receiptTab.Controls.Add(SearchReceiptButton);
            receiptTab.Controls.Add(SearchReceiptTextBox);
            receiptTab.Controls.Add(label4);
            receiptTab.Controls.Add(PrintReceiptButton);
            receiptTab.Controls.Add(ReceiptsDataGridView);
            receiptTab.Controls.Add(label2);
            receiptTab.Location = new Point(4, 34);
            receiptTab.Name = "receiptTab";
            receiptTab.Padding = new Padding(3);
            receiptTab.Size = new Size(1241, 869);
            receiptTab.TabIndex = 0;
            receiptTab.Text = "Чеки";
            // 
            // SearchReceiptButton
            // 
            SearchReceiptButton.BackColor = Color.DodgerBlue;
            SearchReceiptButton.FlatAppearance.BorderSize = 0;
            SearchReceiptButton.FlatStyle = FlatStyle.Flat;
            SearchReceiptButton.ForeColor = Color.White;
            SearchReceiptButton.Location = new Point(1090, 48);
            SearchReceiptButton.Name = "SearchReceiptButton";
            SearchReceiptButton.Size = new Size(120, 35);
            SearchReceiptButton.TabIndex = 5;
            SearchReceiptButton.Text = "🔍 Пошук";
            SearchReceiptButton.UseVisualStyleBackColor = false;
            SearchReceiptButton.Click += SearchReceiptButton_Click;
            // 
            // SearchReceiptTextBox
            // 
            SearchReceiptTextBox.BorderStyle = BorderStyle.FixedSingle;
            SearchReceiptTextBox.Location = new Point(834, 51);
            SearchReceiptTextBox.Name = "SearchReceiptTextBox";
            SearchReceiptTextBox.PlaceholderText = "№ чеку або ім'я клієнта...";
            SearchReceiptTextBox.Size = new Size(250, 32);
            SearchReceiptTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(751, 54);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 3;
            label4.Text = "Пошук:";
            // 
            // PrintReceiptButton
            // 
            PrintReceiptButton.BackColor = Color.Teal;
            PrintReceiptButton.FlatAppearance.BorderSize = 0;
            PrintReceiptButton.FlatStyle = FlatStyle.Flat;
            PrintReceiptButton.ForeColor = Color.White;
            PrintReceiptButton.Location = new Point(26, 48);
            PrintReceiptButton.Name = "PrintReceiptButton";
            PrintReceiptButton.Size = new Size(250, 35);
            PrintReceiptButton.TabIndex = 2;
            PrintReceiptButton.Text = "🖨️ Роздрукувати чек";
            PrintReceiptButton.UseVisualStyleBackColor = false;
            PrintReceiptButton.Click += PrintReceiptButton_Click;
            // 
            // ReceiptsDataGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            ReceiptsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ReceiptsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ReceiptsDataGridView.ColumnHeadersHeight = 27;
            ReceiptsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            ReceiptsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            ReceiptsDataGridView.GridColor = Color.FromArgb(231, 229, 255);
            ReceiptsDataGridView.Location = new Point(26, 102);
            ReceiptsDataGridView.Name = "ReceiptsDataGridView";
            ReceiptsDataGridView.ReadOnly = true;
            ReceiptsDataGridView.RowHeadersVisible = false;
            ReceiptsDataGridView.RowHeadersWidth = 51;
            ReceiptsDataGridView.Size = new Size(1184, 743);
            ReceiptsDataGridView.TabIndex = 1;
            ReceiptsDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            ReceiptsDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            ReceiptsDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            ReceiptsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            ReceiptsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            ReceiptsDataGridView.ThemeStyle.BackColor = Color.White;
            ReceiptsDataGridView.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            ReceiptsDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            ReceiptsDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            ReceiptsDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ReceiptsDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            ReceiptsDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ReceiptsDataGridView.ThemeStyle.HeaderStyle.Height = 27;
            ReceiptsDataGridView.ThemeStyle.ReadOnly = true;
            ReceiptsDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            ReceiptsDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ReceiptsDataGridView.ThemeStyle.RowsStyle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ReceiptsDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            ReceiptsDataGridView.ThemeStyle.RowsStyle.Height = 29;
            ReceiptsDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            ReceiptsDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 14F, FontStyle.Bold);
            label2.Location = new Point(20, 12);
            label2.Name = "label2";
            label2.Size = new Size(266, 29);
            label2.TabIndex = 0;
            label2.Text = "Список замовлень";
            // 
            // salesReportTab
            // 
            salesReportTab.BackColor = Color.White;
            salesReportTab.Controls.Add(QuickReportWeekButton);
            salesReportTab.Controls.Add(QuickReportTodayButton);
            salesReportTab.Controls.Add(GenerateReportButton);
            salesReportTab.Controls.Add(EndDatePicker);
            salesReportTab.Controls.Add(label7);
            salesReportTab.Controls.Add(StartDatePicker);
            salesReportTab.Controls.Add(label6);
            salesReportTab.Controls.Add(label5);
            salesReportTab.Location = new Point(4, 34);
            salesReportTab.Name = "salesReportTab";
            salesReportTab.Padding = new Padding(3);
            salesReportTab.Size = new Size(1241, 869);
            salesReportTab.TabIndex = 1;
            salesReportTab.Text = "Звіти про продажі";
            // 
            // QuickReportWeekButton
            // 
            QuickReportWeekButton.BackColor = Color.MediumSlateBlue;
            QuickReportWeekButton.FlatAppearance.BorderSize = 0;
            QuickReportWeekButton.FlatStyle = FlatStyle.Flat;
            QuickReportWeekButton.ForeColor = Color.White;
            QuickReportWeekButton.Location = new Point(430, 152);
            QuickReportWeekButton.Name = "QuickReportWeekButton";
            QuickReportWeekButton.Size = new Size(180, 40);
            QuickReportWeekButton.TabIndex = 7;
            QuickReportWeekButton.Text = "📅 За тиждень";
            QuickReportWeekButton.UseVisualStyleBackColor = false;
            QuickReportWeekButton.Click += QuickReportWeekButton_Click;
            // 
            // QuickReportTodayButton
            // 
            QuickReportTodayButton.BackColor = Color.MediumSlateBlue;
            QuickReportTodayButton.FlatAppearance.BorderSize = 0;
            QuickReportTodayButton.FlatStyle = FlatStyle.Flat;
            QuickReportTodayButton.ForeColor = Color.White;
            QuickReportTodayButton.Location = new Point(234, 152);
            QuickReportTodayButton.Name = "QuickReportTodayButton";
            QuickReportTodayButton.Size = new Size(180, 40);
            QuickReportTodayButton.TabIndex = 6;
            QuickReportTodayButton.Text = "📅 За сьогодні";
            QuickReportTodayButton.UseVisualStyleBackColor = false;
            QuickReportTodayButton.Click += QuickReportTodayButton_Click;
            // 
            // GenerateReportButton
            // 
            GenerateReportButton.BackColor = Color.Teal;
            GenerateReportButton.FlatAppearance.BorderSize = 0;
            GenerateReportButton.FlatStyle = FlatStyle.Flat;
            GenerateReportButton.ForeColor = Color.White;
            GenerateReportButton.Location = new Point(34, 152);
            GenerateReportButton.Name = "GenerateReportButton";
            GenerateReportButton.Size = new Size(180, 40);
            GenerateReportButton.TabIndex = 5;
            GenerateReportButton.Text = "📊 Сформувати";
            GenerateReportButton.UseVisualStyleBackColor = false;
            GenerateReportButton.Click += GenerateReportButton_Click;
            // 
            // EndDatePicker
            // 
            EndDatePicker.Format = DateTimePickerFormat.Short;
            EndDatePicker.Location = new Point(430, 95);
            EndDatePicker.Name = "EndDatePicker";
            EndDatePicker.Size = new Size(204, 32);
            EndDatePicker.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(430, 67);
            label7.Name = "label7";
            label7.Size = new Size(156, 25);
            label7.TabIndex = 3;
            label7.Text = "Кінцева дата:";
            // 
            // StartDatePicker
            // 
            StartDatePicker.Format = DateTimePickerFormat.Short;
            StartDatePicker.Location = new Point(34, 95);
            StartDatePicker.Name = "StartDatePicker";
            StartDatePicker.Size = new Size(204, 32);
            StartDatePicker.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 67);
            label6.Name = "label6";
            label6.Size = new Size(183, 25);
            label6.TabIndex = 1;
            label6.Text = "Початкова дата:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 14F, FontStyle.Bold);
            label5.Location = new Point(20, 12);
            label5.Name = "label5";
            label5.Size = new Size(385, 29);
            label5.TabIndex = 0;
            label5.Text = "Звіт про продажі за період";
            // 
            // ReportsUserControl
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 4, 5, 4);
            Name = "ReportsUserControl";
            Size = new Size(1249, 907);
            Load += ReportsUserControl_Load;
            tabControl1.ResumeLayout(false);
            receiptTab.ResumeLayout(false);
            receiptTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ReceiptsDataGridView).EndInit();
            salesReportTab.ResumeLayout(false);
            salesReportTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage receiptTab;
        private TabPage salesReportTab;
        private Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView ReceiptsDataGridView;
        private Button PrintReceiptButton;
        private Label label5;
        private DateTimePicker StartDatePicker;
        private Label label6;
        private DateTimePicker EndDatePicker;
        private Label label7;
        private Button GenerateReportButton;
        private Button QuickReportTodayButton;
        private Button QuickReportWeekButton;
        private Label label4;
        private TextBox SearchReceiptTextBox;
        private Button SearchReceiptButton;
    }
}