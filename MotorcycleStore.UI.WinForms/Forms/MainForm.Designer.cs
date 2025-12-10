namespace MotorcycleStore.UI.WinForms.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            menuPanel = new Panel();
            pictureBox11 = new PictureBox();
            pictureBox9 = new PictureBox();
            label12 = new Label();
            pictureBox12 = new PictureBox();
            ProductsMenuLabel = new Label();
            pictureBox13 = new PictureBox();
            OrdersMenuLabel = new Label();
            pictureBox14 = new PictureBox();
            CustomersMenuLabel = new Label();
            pictureBox15 = new PictureBox();
            EmployeesMenuLabel = new Label();
            panel7 = new Panel();
            pictureBox17 = new PictureBox();
            ExitLable = new Label();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            panel3 = new Panel();
            XLabel = new Label();
            pictureBox8 = new PictureBox();
            label1 = new Label();
            ContentPanel = new Panel();
            contentPanel1 = new Panel();
            panel1.SuspendLayout();
            menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox17).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ContentPanel.SuspendLayout();
            SuspendLayout();
          
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(menuPanel);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 907);
            panel1.TabIndex = 0;
          
            menuPanel.BackColor = Color.Teal;
            menuPanel.Controls.Add(pictureBox11);
            menuPanel.Controls.Add(pictureBox9);
            menuPanel.Controls.Add(label12);
            menuPanel.Controls.Add(pictureBox12);
            menuPanel.Controls.Add(ProductsMenuLabel);
            menuPanel.Controls.Add(pictureBox13);
            menuPanel.Controls.Add(OrdersMenuLabel);
            menuPanel.Controls.Add(pictureBox14);
            menuPanel.Controls.Add(CustomersMenuLabel);
            menuPanel.Controls.Add(pictureBox15);
            menuPanel.Controls.Add(EmployeesMenuLabel);
            menuPanel.Controls.Add(panel7);
            menuPanel.Dock = DockStyle.Fill;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(228, 907);
            menuPanel.TabIndex = 0;
          
            pictureBox11.Image = (Image)resources.GetObject("pictureBox11.Image");
            pictureBox11.Location = new Point(50, 12);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(109, 58);
            pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox11.TabIndex = 7;
            pictureBox11.TabStop = false;
           
            pictureBox9.Cursor = Cursors.Hand;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(10, 346);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(49, 37);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 17;
            pictureBox9.TabStop = false;
           
            label12.AutoSize = true;
            label12.Cursor = Cursors.Hand;
            label12.ForeColor = Color.White;
            label12.Location = new Point(72, 353);
            label12.Name = "label12";
            label12.Size = new Size(103, 25);
            label12.TabIndex = 16;
            label12.Text = "Звітність";
            label12.Click += label12_Click;
           
            pictureBox12.Cursor = Cursors.Hand;
            pictureBox12.Image = (Image)resources.GetObject("pictureBox12.Image");
            pictureBox12.Location = new Point(10, 88);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(49, 37);
            pictureBox12.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox12.TabIndex = 15;
            pictureBox12.TabStop = false;
            
            ProductsMenuLabel.AutoSize = true;
            ProductsMenuLabel.Cursor = Cursors.Hand;
            ProductsMenuLabel.ForeColor = Color.White;
            ProductsMenuLabel.Location = new Point(67, 95);
            ProductsMenuLabel.Name = "ProductsMenuLabel";
            ProductsMenuLabel.Size = new Size(121, 25);
            ProductsMenuLabel.TabIndex = 14;
            ProductsMenuLabel.Text = "Всі товари";
            ProductsMenuLabel.Click += ProductsMenuLabel_Click;
           
            pictureBox13.Cursor = Cursors.Hand;
            pictureBox13.Image = (Image)resources.GetObject("pictureBox13.Image");
            pictureBox13.Location = new Point(10, 153);
            pictureBox13.Name = "pictureBox13";
            pictureBox13.Size = new Size(49, 37);
            pictureBox13.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox13.TabIndex = 13;
            pictureBox13.TabStop = false;
           
            OrdersMenuLabel.AutoSize = true;
            OrdersMenuLabel.Cursor = Cursors.Hand;
            OrdersMenuLabel.ForeColor = Color.White;
            OrdersMenuLabel.Location = new Point(67, 160);
            OrdersMenuLabel.Name = "OrdersMenuLabel";
            OrdersMenuLabel.Size = new Size(136, 25);
            OrdersMenuLabel.TabIndex = 12;
            OrdersMenuLabel.Text = "Замовлення";
            OrdersMenuLabel.Click += OrdersMenuLabel_Click;
          
            pictureBox14.Cursor = Cursors.Hand;
            pictureBox14.Image = (Image)resources.GetObject("pictureBox14.Image");
            pictureBox14.Location = new Point(10, 220);
            pictureBox14.Name = "pictureBox14";
            pictureBox14.Size = new Size(49, 37);
            pictureBox14.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox14.TabIndex = 13;
            pictureBox14.TabStop = false;
            
            CustomersMenuLabel.AutoSize = true;
            CustomersMenuLabel.Cursor = Cursors.Hand;
            CustomersMenuLabel.ForeColor = Color.White;
            CustomersMenuLabel.Location = new Point(67, 227);
            CustomersMenuLabel.Name = "CustomersMenuLabel";
            CustomersMenuLabel.Size = new Size(125, 25);
            CustomersMenuLabel.TabIndex = 12;
            CustomersMenuLabel.Text = "Замовники";
            CustomersMenuLabel.Click += CustomersMenuLabel_Click;
             
            pictureBox15.Cursor = Cursors.Hand;
            pictureBox15.Image = (Image)resources.GetObject("pictureBox15.Image");
            pictureBox15.Location = new Point(10, 281);
            pictureBox15.Name = "pictureBox15";
            pictureBox15.Size = new Size(49, 37);
            pictureBox15.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox15.TabIndex = 11;
            pictureBox15.TabStop = false;
           
            EmployeesMenuLabel.AutoSize = true;
            EmployeesMenuLabel.Cursor = Cursors.Hand;
            EmployeesMenuLabel.ForeColor = Color.White;
            EmployeesMenuLabel.Location = new Point(67, 288);
            EmployeesMenuLabel.Name = "EmployeesMenuLabel";
            EmployeesMenuLabel.Size = new Size(133, 25);
            EmployeesMenuLabel.TabIndex = 10;
            EmployeesMenuLabel.Text = "Працівники";
            EmployeesMenuLabel.Click += EmployeesMenuLabel_Click;
           
            panel7.BackColor = Color.DarkSlateGray;
            panel7.Controls.Add(pictureBox17);
            panel7.Controls.Add(ExitLable);
            panel7.Cursor = Cursors.Hand;
            panel7.Location = new Point(0, 851);
            panel7.Name = "panel7";
            panel7.Size = new Size(228, 56);
            panel7.TabIndex = 2;
           
            pictureBox17.Image = (Image)resources.GetObject("pictureBox17.Image");
            pictureBox17.Location = new Point(27, 8);
            pictureBox17.Name = "pictureBox17";
            pictureBox17.Size = new Size(49, 37);
            pictureBox17.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox17.TabIndex = 7;
            pictureBox17.TabStop = false;
            
            ExitLable.AutoSize = true;
            ExitLable.ForeColor = Color.White;
            ExitLable.Location = new Point(84, 15);
            ExitLable.Name = "ExitLable";
            ExitLable.Size = new Size(75, 25);
            ExitLable.TabIndex = 6;
            ExitLable.Text = "Вийти";
            ExitLable.Click += ExitLable_Click;
            guna2Elipse1.BorderRadius = 15;
            guna2Elipse1.TargetControl = this;
            
            panel3.BackColor = Color.LightSeaGreen;
            panel3.Controls.Add(XLabel);
            panel3.Controls.Add(pictureBox8);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(228, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1298, 46);
            panel3.TabIndex = 1;
                        XLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            XLabel.AutoSize = true;
            XLabel.Cursor = Cursors.Hand;
            XLabel.ForeColor = Color.White;
            XLabel.Location = new Point(1259, 9);
            XLabel.Name = "XLabel";
            XLabel.Size = new Size(26, 25);
            XLabel.TabIndex = 8;
            XLabel.Text = "X";
            XLabel.Click += XLabel_Click;
            
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(24, 4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(49, 37);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 7;
            pictureBox8.TabStop = false;
          
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(84, 10);
            label1.Name = "label1";
            label1.Size = new Size(349, 25);
            label1.TabIndex = 6;
            label1.Text = "MotoUA Management System 1.0";
            
            ContentPanel.BackColor = Color.White;
            ContentPanel.Controls.Add(contentPanel1);
            ContentPanel.Dock = DockStyle.Fill;
            ContentPanel.Location = new Point(228, 46);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Size = new Size(1298, 861);
            ContentPanel.TabIndex = 2;
            
            contentPanel1.Location = new Point(6, 6);
            contentPanel1.Name = "contentPanel1";
            contentPanel1.Size = new Size(1289, 852);
            contentPanel1.TabIndex = 0;
           
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1526, 907);
            Controls.Add(ContentPanel);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            panel1.ResumeLayout(false);
            menuPanel.ResumeLayout(false);
            menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox14).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox17).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ContentPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel menuPanel;
        private PictureBox pictureBox11;
        private PictureBox pictureBox9;
        private Label label12;
        private PictureBox pictureBox12;
        private Label ProductsMenuLabel;
        private PictureBox pictureBox13;
        private Label OrdersMenuLabel;
        private PictureBox pictureBox14;
        private Label CustomersMenuLabel;
        private PictureBox pictureBox15;
        private Label EmployeesMenuLabel;
        private Panel panel7;
        private PictureBox pictureBox17;
        private Label ExitLable;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Panel panel3;
        private Label XLabel;
        private PictureBox pictureBox8;
        private Label label1;
        private Panel ContentPanel;
        private Panel contentPanel1;
    }
}