namespace MotorcycleStore.UI.WinForms.Forms.UseControls
{
    partial class ProductsUserControl
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
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            label2 = new Label();
            ModelTextBox = new TextBox();
            BrandTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            VINTextBox = new TextBox();
            label5 = new Label();
            CommentTextBox = new TextBox();
            label6 = new Label();
            label7 = new Label();
            PriceTextBox = new TextBox();
            label8 = new Label();
            QtyTextBox = new TextBox();
            label9 = new Label();
            YearTextBox = new TextBox();
            label10 = new Label();
            CategoryComboBox = new ComboBox();
            SaveButton = new Button();
            AddButton = new Button();
            DeleteButton = new Button();
            ProductsDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            IdColumn = new DataGridViewTextBoxColumn();
            ModelColumn = new DataGridViewTextBoxColumn();
            BrandColumn = new DataGridViewTextBoxColumn();
            CategoryColumn = new DataGridViewTextBoxColumn();
            VINColumn = new DataGridViewTextBoxColumn();
            YearColumn = new DataGridViewTextBoxColumn();
            QtyColumn = new DataGridViewTextBoxColumn();
            PriceColumn = new DataGridViewTextBoxColumn();
            SupplierColumn = new DataGridViewTextBoxColumn();
            CommentColumn = new DataGridViewTextBoxColumn();
            CreateOrderButton = new Button();
            SupplierTextBox = new TextBox();
            ProductContextMenuStrip = new ContextMenuStrip(components);
            EditStripMenuItem1 = new ToolStripMenuItem();
            DeleteStripMenuItem1 = new ToolStripMenuItem();
            SearchButton = new Button();
            SearchTextBox = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)ProductsDataGridView).BeginInit();
            ProductContextMenuStrip.SuspendLayout();
            SuspendLayout();
            
            guna2Elipse1.BorderRadius = 15;
            guna2Elipse1.TargetControl = this;
          
            label2.AutoSize = true;
            label2.Location = new Point(23, 56);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 4;
            label2.Text = "Модель";
          
            ModelTextBox.BorderStyle = BorderStyle.FixedSingle;
            ModelTextBox.Location = new Point(24, 85);
            ModelTextBox.Name = "ModelTextBox";
            ModelTextBox.Size = new Size(203, 32);
            ModelTextBox.TabIndex = 5;
            
            BrandTextBox.BorderStyle = BorderStyle.FixedSingle;
            BrandTextBox.Location = new Point(247, 85);
            BrandTextBox.Name = "BrandTextBox";
            BrandTextBox.Size = new Size(203, 32);
            BrandTextBox.TabIndex = 7;
            
            label3.AutoSize = true;
            label3.Location = new Point(246, 56);
            label3.Name = "label3";
            label3.Size = new Size(77, 25);
            label3.TabIndex = 6;
            label3.Text = "Марка";
            
            label4.AutoSize = true;
            label4.Location = new Point(471, 56);
            label4.Name = "label4";
            label4.Size = new Size(111, 25);
            label4.TabIndex = 8;
            label4.Text = "Категорія";
            
            VINTextBox.BorderStyle = BorderStyle.FixedSingle;
            VINTextBox.Location = new Point(695, 85);
            VINTextBox.Name = "VINTextBox";
            VINTextBox.Size = new Size(203, 32);
            VINTextBox.TabIndex = 11;
            
            label5.AutoSize = true;
            label5.Location = new Point(694, 56);
            label5.Name = "label5";
            label5.Size = new Size(49, 25);
            label5.TabIndex = 10;
            label5.Text = "VIN";
            
            CommentTextBox.BorderStyle = BorderStyle.FixedSingle;
            CommentTextBox.Location = new Point(695, 161);
            CommentTextBox.Name = "CommentTextBox";
            CommentTextBox.Size = new Size(424, 32);
            CommentTextBox.TabIndex = 19;
            
            label6.AutoSize = true;
            label6.Location = new Point(694, 132);
            label6.Name = "label6";
            label6.Size = new Size(169, 25);
            label6.TabIndex = 18;
            label6.Text = "Коментар/опис";
            
            label7.AutoSize = true;
            label7.Location = new Point(471, 132);
            label7.Name = "label7";
            label7.Size = new Size(157, 25);
            label7.TabIndex = 16;
            label7.Text = "Постачальник";
             
            PriceTextBox.BorderStyle = BorderStyle.FixedSingle;
            PriceTextBox.Location = new Point(247, 161);
            PriceTextBox.Name = "PriceTextBox";
            PriceTextBox.Size = new Size(203, 32);
            PriceTextBox.TabIndex = 15;
           
            label8.AutoSize = true;
            label8.Location = new Point(246, 132);
            label8.Name = "label8";
            label8.Size = new Size(58, 25);
            label8.TabIndex = 14;
            label8.Text = "Ціна";
            
            QtyTextBox.BorderStyle = BorderStyle.FixedSingle;
            QtyTextBox.Location = new Point(24, 161);
            QtyTextBox.Name = "QtyTextBox";
            QtyTextBox.Size = new Size(203, 32);
            QtyTextBox.TabIndex = 13;
           
            label9.AutoSize = true;
            label9.Location = new Point(23, 132);
            label9.Name = "label9";
            label9.Size = new Size(105, 25);
            label9.TabIndex = 12;
            label9.Text = "Кількість";
            
            YearTextBox.BorderStyle = BorderStyle.FixedSingle;
            YearTextBox.Location = new Point(916, 85);
            YearTextBox.Name = "YearTextBox";
            YearTextBox.Size = new Size(203, 32);
            YearTextBox.TabIndex = 21;
           
            label10.AutoSize = true;
            label10.Location = new Point(915, 56);
            label10.Name = "label10";
            label10.Size = new Size(42, 25);
            label10.TabIndex = 20;
            label10.Text = "Рік";
             
            CategoryComboBox.FormattingEnabled = true;
            CategoryComboBox.Location = new Point(471, 85);
            CategoryComboBox.Name = "CategoryComboBox";
            CategoryComboBox.Size = new Size(204, 33);
            CategoryComboBox.TabIndex = 23;
            
            SaveButton.BackColor = Color.LightSeaGreen;
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(24, 218);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(206, 35);
            SaveButton.TabIndex = 24;
            SaveButton.Text = "Зберегти зміни";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
          
            AddButton.BackColor = Color.Teal;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.ForeColor = Color.White;
            AddButton.Location = new Point(244, 218);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(206, 35);
            AddButton.TabIndex = 25;
            AddButton.Text = "Додати";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            
            DeleteButton.BackColor = Color.Crimson;
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.ForeColor = Color.White;
            DeleteButton.Location = new Point(471, 218);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(206, 35);
            DeleteButton.TabIndex = 26;
            DeleteButton.Text = "Очистити";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
           
            dataGridViewCellStyle4.BackColor = Color.White;
            ProductsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            ProductsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            ProductsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            ProductsDataGridView.ColumnHeadersHeight = 27;
            ProductsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ProductsDataGridView.Columns.AddRange(new DataGridViewColumn[] { IdColumn, ModelColumn, BrandColumn, CategoryColumn, VINColumn, YearColumn, QtyColumn, PriceColumn, SupplierColumn, CommentColumn });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            ProductsDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            ProductsDataGridView.GridColor = Color.FromArgb(231, 229, 255);
            ProductsDataGridView.Location = new Point(24, 326);
            ProductsDataGridView.Name = "ProductsDataGridView";
            ProductsDataGridView.RowHeadersVisible = false;
            ProductsDataGridView.RowHeadersWidth = 51;
            ProductsDataGridView.Size = new Size(1209, 554);
            ProductsDataGridView.TabIndex = 27;
            ProductsDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            ProductsDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            ProductsDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            ProductsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            ProductsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            ProductsDataGridView.ThemeStyle.BackColor = Color.White;
            ProductsDataGridView.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            ProductsDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            ProductsDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            ProductsDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ProductsDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            ProductsDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ProductsDataGridView.ThemeStyle.HeaderStyle.Height = 27;
            ProductsDataGridView.ThemeStyle.ReadOnly = false;
            ProductsDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            ProductsDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ProductsDataGridView.ThemeStyle.RowsStyle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ProductsDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            ProductsDataGridView.ThemeStyle.RowsStyle.Height = 29;
            ProductsDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            ProductsDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
      
            IdColumn.HeaderText = "Id";
            IdColumn.MinimumWidth = 6;
            IdColumn.Name = "IdColumn";
            IdColumn.Visible = false;
            IdColumn.Width = 6;
    
            ModelColumn.HeaderText = "Модель";
            ModelColumn.MinimumWidth = 6;
            ModelColumn.Name = "ModelColumn";
            ModelColumn.Width = 150;
         
            BrandColumn.HeaderText = "Марка";
            BrandColumn.MinimumWidth = 6;
            BrandColumn.Name = "BrandColumn";
            BrandColumn.Width = 150;
         
            CategoryColumn.HeaderText = "Категорія";
            CategoryColumn.MinimumWidth = 6;
            CategoryColumn.Name = "CategoryColumn";
            CategoryColumn.Width = 134;
          
            VINColumn.HeaderText = "VIN";
            VINColumn.MinimumWidth = 6;
            VINColumn.Name = "VINColumn";
            VINColumn.Width = 134;
           
            YearColumn.HeaderText = "Рік";
            YearColumn.MinimumWidth = 6;
            YearColumn.Name = "YearColumn";
            YearColumn.Width = 80;
          
            QtyColumn.HeaderText = "Кількість";
            QtyColumn.MinimumWidth = 6;
            QtyColumn.Name = "QtyColumn";
            QtyColumn.Width = 110;
          
            PriceColumn.HeaderText = "Ціна";
            PriceColumn.MinimumWidth = 6;
            PriceColumn.Name = "PriceColumn";
            PriceColumn.Width = 134;
            
            SupplierColumn.HeaderText = "Постачальник";
            SupplierColumn.MinimumWidth = 6;
            SupplierColumn.Name = "SupplierColumn";
            SupplierColumn.Width = 170;
            
            CommentColumn.HeaderText = "Коментар";
            CommentColumn.MinimumWidth = 6;
            CommentColumn.Name = "CommentColumn";
            CommentColumn.Width = 200;
           
            CreateOrderButton.BackColor = Color.LimeGreen;
            CreateOrderButton.FlatAppearance.BorderSize = 0;
            CreateOrderButton.FlatStyle = FlatStyle.Flat;
            CreateOrderButton.ForeColor = Color.White;
            CreateOrderButton.Location = new Point(974, 218);
            CreateOrderButton.Name = "CreateOrderButton";
            CreateOrderButton.Size = new Size(259, 35);
            CreateOrderButton.TabIndex = 28;
            CreateOrderButton.Text = "Створити замовлення";
            CreateOrderButton.UseVisualStyleBackColor = false;
            CreateOrderButton.Click += CreateOrderButton_Click;
           
            SupplierTextBox.BorderStyle = BorderStyle.FixedSingle;
            SupplierTextBox.Location = new Point(472, 161);
            SupplierTextBox.Name = "SupplierTextBox";
            SupplierTextBox.Size = new Size(203, 32);
            SupplierTextBox.TabIndex = 17;
          
            ProductContextMenuStrip.ImageScalingSize = new Size(20, 20);
            ProductContextMenuStrip.Items.AddRange(new ToolStripItem[] { EditStripMenuItem1, DeleteStripMenuItem1 });
            ProductContextMenuStrip.Name = "ProductContextMenuStrip";
            ProductContextMenuStrip.Size = new Size(155, 52);
            
            EditStripMenuItem1.Name = "EditStripMenuItem1";
            EditStripMenuItem1.Size = new Size(154, 24);
            EditStripMenuItem1.Text = "Редагувати";
            EditStripMenuItem1.Click += EditStripMenuItem1_Click;
          
            DeleteStripMenuItem1.Name = "DeleteStripMenuItem1";
            DeleteStripMenuItem1.Size = new Size(154, 24);
            DeleteStripMenuItem1.Text = "Видалити";
            DeleteStripMenuItem1.Click += DeleteStripMenuItem1_Click;
           
            SearchButton.BackColor = Color.DodgerBlue;
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.ForeColor = Color.White;
            SearchButton.Location = new Point(1133, 278);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(100, 35);
            SearchButton.TabIndex = 55;
            SearchButton.Text = "🔍";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            
            SearchTextBox.BorderStyle = BorderStyle.FixedSingle;
            SearchTextBox.Location = new Point(877, 278);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.PlaceholderText = "Назва, марка, рік...";
            SearchTextBox.Size = new Size(250, 32);
            SearchTextBox.TabIndex = 54;
             
            label1.AutoSize = true;
            label1.Location = new Point(792, 281);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 53;
            label1.Text = "Пошук";
            
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(label1);
            Controls.Add(CreateOrderButton);
            Controls.Add(ProductsDataGridView);
            Controls.Add(DeleteButton);
            Controls.Add(AddButton);
            Controls.Add(SaveButton);
            Controls.Add(CategoryComboBox);
            Controls.Add(YearTextBox);
            Controls.Add(label10);
            Controls.Add(CommentTextBox);
            Controls.Add(label6);
            Controls.Add(SupplierTextBox);
            Controls.Add(label7);
            Controls.Add(PriceTextBox);
            Controls.Add(label8);
            Controls.Add(QtyTextBox);
            Controls.Add(label9);
            Controls.Add(VINTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(BrandTextBox);
            Controls.Add(label3);
            Controls.Add(ModelTextBox);
            Controls.Add(label2);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 4, 5, 4);
            Name = "ProductsUserControl";
            Size = new Size(1249, 907);
            Load += ProductsForm_Load;
            ((System.ComponentModel.ISupportInitialize)ProductsDataGridView).EndInit();
            ProductContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private TextBox ModelTextBox;
        private Label label2;
        private TextBox CommentTextBox;
        private Label label6;
        private Label label7;
        private TextBox PriceTextBox;
        private Label label8;
        private TextBox QtyTextBox;
        private Label label9;
        private TextBox VINTextBox;
        private Label label5;
        private Label label4;
        private TextBox BrandTextBox;
        private Label label3;
        private TextBox YearTextBox;
        private Label label10;
        private ComboBox CategoryComboBox;
        private Guna.UI2.WinForms.Guna2DataGridView ProductsDataGridView;
        private Button DeleteButton;
        private Button AddButton;
        private Button SaveButton;
        private Button CreateOrderButton;
        private TextBox SupplierTextBox;
        private ContextMenuStrip ProductContextMenuStrip;
        private ToolStripMenuItem EditStripMenuItem1;
        private ToolStripMenuItem DeleteStripMenuItem1;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewTextBoxColumn ModelColumn;
        private DataGridViewTextBoxColumn BrandColumn;
        private DataGridViewTextBoxColumn CategoryColumn;
        private DataGridViewTextBoxColumn VINColumn;
        private DataGridViewTextBoxColumn YearColumn;
        private DataGridViewTextBoxColumn QtyColumn;
        private DataGridViewTextBoxColumn PriceColumn;
        private DataGridViewTextBoxColumn SupplierColumn;
        private DataGridViewTextBoxColumn CommentColumn;
        private Button SearchButton;
        private TextBox SearchTextBox;
        private Label label1;
    }
}

