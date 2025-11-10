namespace MotorcycleStore.UI.WinForms.Forms
{
    partial class ProductsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsForm));
            panel1 = new Panel();
            pictureBox6 = new PictureBox();
            ReportsButton = new Label();
            pictureBox5 = new PictureBox();
            OrdersButton = new Label();
            pictureBox4 = new PictureBox();
            CustomersButton = new Label();
            pictureBox3 = new PictureBox();
            EmployeersButton = new Label();
            pictureBox2 = new PictureBox();
            ProductsButton = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            LogoutLable = new Label();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            pictureBox7 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(pictureBox7);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(ReportsButton);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(OrdersButton);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(CustomersButton);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(EmployeersButton);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(ProductsButton);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 529);
            panel1.TabIndex = 1;
            // 
            // pictureBox6
            // 
            pictureBox6.Cursor = Cursors.Cross;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(17, 350);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(49, 37);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 17;
            pictureBox6.TabStop = false;
            // 
            // ReportsButton
            // 
            ReportsButton.AutoSize = true;
            ReportsButton.Cursor = Cursors.Cross;
            ReportsButton.FlatStyle = FlatStyle.System;
            ReportsButton.ForeColor = Color.White;
            ReportsButton.Location = new Point(74, 357);
            ReportsButton.Name = "ReportsButton";
            ReportsButton.Size = new Size(103, 25);
            ReportsButton.TabIndex = 16;
            ReportsButton.Text = "Звітність";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(17, 153);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(49, 37);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 15;
            pictureBox5.TabStop = false;
            // 
            // OrdersButton
            // 
            OrdersButton.AutoSize = true;
            OrdersButton.ForeColor = Color.White;
            OrdersButton.Location = new Point(74, 160);
            OrdersButton.Name = "OrdersButton";
            OrdersButton.Size = new Size(136, 25);
            OrdersButton.TabIndex = 14;
            OrdersButton.Text = "Замовлення";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(17, 220);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(49, 37);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 13;
            pictureBox4.TabStop = false;
            // 
            // CustomersButton
            // 
            CustomersButton.AutoSize = true;
            CustomersButton.ForeColor = Color.White;
            CustomersButton.Location = new Point(74, 227);
            CustomersButton.Name = "CustomersButton";
            CustomersButton.Size = new Size(125, 25);
            CustomersButton.TabIndex = 12;
            CustomersButton.Text = "Замовники";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(17, 288);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(49, 37);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // EmployeersButton
            // 
            EmployeersButton.AutoSize = true;
            EmployeersButton.ForeColor = Color.White;
            EmployeersButton.Location = new Point(74, 295);
            EmployeersButton.Name = "EmployeersButton";
            EmployeersButton.Size = new Size(121, 25);
            EmployeersButton.TabIndex = 10;
            EmployeersButton.Text = "Пацівники";
            EmployeersButton.Click += label2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(17, 90);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(49, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // ProductsButton
            // 
            ProductsButton.AutoSize = true;
            ProductsButton.ForeColor = Color.White;
            ProductsButton.Location = new Point(74, 97);
            ProductsButton.Name = "ProductsButton";
            ProductsButton.Size = new Size(146, 25);
            ProductsButton.TabIndex = 8;
            ProductsButton.Text = "Всі продукти";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkSlateGray;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(LogoutLable);
            panel2.Location = new Point(0, 472);
            panel2.Name = "panel2";
            panel2.Size = new Size(237, 56);
            panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(27, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // LogoutLable
            // 
            LogoutLable.AutoSize = true;
            LogoutLable.ForeColor = Color.White;
            LogoutLable.Location = new Point(84, 15);
            LogoutLable.Name = "LogoutLable";
            LogoutLable.Size = new Size(75, 25);
            LogoutLable.TabIndex = 6;
            LogoutLable.Text = "Вийти";
            LogoutLable.Click += LogoutLable_Click;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 15;
            guna2Elipse1.TargetControl = this;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(50, 12);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(109, 58);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 7;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(924, 529);
            Controls.Add(panel1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            Name = "ProductsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProductsForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Label LogoutLable;
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
        private Label OrdersButton;
        private PictureBox pictureBox4;
        private Label CustomersButton;
        private PictureBox pictureBox3;
        private Label EmployeersButton;
        private PictureBox pictureBox2;
        private Label ProductsButton;
        private PictureBox pictureBox6;
        private Label ReportsButton;
        private PictureBox pictureBox7;
    }
}