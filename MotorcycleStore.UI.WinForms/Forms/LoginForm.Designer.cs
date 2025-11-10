namespace MotorcycleStore.UI.WinForms.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(components);
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            pictureBox1 = new PictureBox();
            LoginButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(173, 393);
            panel1.TabIndex = 0;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 15;
            guna2Elipse1.TargetControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(322, 9);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 1;
            label1.Text = "Магазин";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(236, 177);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(267, 32);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 149);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 3;
            label2.Text = "Логін";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(236, 232);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 5;
            label3.Text = "Пароль";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(236, 260);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(267, 32);
            textBox2.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(297, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 79);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.Teal;
            LoginButton.FlatAppearance.BorderSize = 0;
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.ForeColor = Color.White;
            LoginButton.Location = new Point(326, 318);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(94, 35);
            LoginButton.TabIndex = 7;
            LoginButton.Text = "Вхід";
            LoginButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(614, 393);
            Controls.Add(LoginButton);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Button LoginButton;
        private PictureBox pictureBox1;
    }
}