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
            LoginTextBox = new TextBox();
            LoginLabel = new Label();
            PasswordLabel = new Label();
            PasswordTextBox = new TextBox();
            pictureBox1 = new PictureBox();
            LoginButton = new Button();
            ForgetPasswordLabel = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(173, 396);
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
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(322, 9);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 1;
            label1.Text = "MotoLife";
            label1.Click += label1_Click;
            // 
            // LoginTextBox
            // 
            LoginTextBox.Location = new Point(236, 177);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.Size = new Size(267, 32);
            LoginTextBox.TabIndex = 2;
            // 
            // LoginLabel
            // 
            LoginLabel.AutoSize = true;
            LoginLabel.Location = new Point(236, 149);
            LoginLabel.Name = "LoginLabel";
            LoginLabel.Size = new Size(67, 25);
            LoginLabel.TabIndex = 3;
            LoginLabel.Text = "Логін";
            LoginLabel.Click += label2_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(236, 232);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(86, 25);
            PasswordLabel.TabIndex = 5;
            PasswordLabel.Text = "Пароль";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(236, 260);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(267, 32);
            PasswordTextBox.TabIndex = 4;
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
            LoginButton.Location = new Point(322, 336);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(94, 35);
            LoginButton.TabIndex = 7;
            LoginButton.Text = "Вхід";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // ForgetPasswordLabel
            // 
            ForgetPasswordLabel.AutoSize = true;
            ForgetPasswordLabel.Font = new Font("Verdana", 9F);
            ForgetPasswordLabel.LinkColor = Color.LightSeaGreen;
            ForgetPasswordLabel.Location = new Point(373, 297);
            ForgetPasswordLabel.Name = "ForgetPasswordLabel";
            ForgetPasswordLabel.Size = new Size(130, 18);
            ForgetPasswordLabel.TabIndex = 8;
            ForgetPasswordLabel.TabStop = true;
            ForgetPasswordLabel.Text = "Забули пароль?";
            ForgetPasswordLabel.LinkClicked += ForgetPasswordLabel_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(614, 396);
            Controls.Add(ForgetPasswordLabel);
            Controls.Add(LoginButton);
            Controls.Add(pictureBox1);
            Controls.Add(PasswordLabel);
            Controls.Add(PasswordTextBox);
            Controls.Add(LoginLabel);
            Controls.Add(LoginTextBox);
            Controls.Add(label1);
            Controls.Add(panel1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            Name = "LoginForm";
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
        private TextBox LoginTextBox;
        private Label LoginLabel;
        private Label PasswordLabel;
        private TextBox PasswordTextBox;
        private Button LoginButton;
        private PictureBox pictureBox1;
        private LinkLabel ForgetPasswordLabel;
    }
}