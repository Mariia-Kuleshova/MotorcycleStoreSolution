namespace MotorcycleStore.UI.WinForms
{
    partial class Form1
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
            ReportButton = new Button();
            ExelButton = new Button();
            SuspendLayout();
           
            ReportButton.Location = new Point(574, 280);
            ReportButton.Margin = new Padding(3, 2, 3, 2);
            ReportButton.Name = "ReportButton";
            ReportButton.Size = new Size(82, 22);
            ReportButton.TabIndex = 0;
            ReportButton.Text = "Report";
            ReportButton.UseVisualStyleBackColor = true;
            ReportButton.Click += button1_Click;
            
            ExelButton.Location = new Point(574, 240);
            ExelButton.Name = "ExelButton";
            ExelButton.Size = new Size(82, 24);
            ExelButton.TabIndex = 0;
            ExelButton.Text = "Exel Report";
            ExelButton.Click += ExelButton_Click;
          
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(ExelButton);
            Controls.Add(ReportButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button ReportButton;
        private Button ExelButton;
    }
}