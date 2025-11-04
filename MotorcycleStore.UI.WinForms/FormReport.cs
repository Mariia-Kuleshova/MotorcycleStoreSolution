using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;
using FastReport.Utils;
using FastReport.Data;
using FastReport;

namespace MotorcycleStore.UI.WinForms
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }
        FastReport.Preview.PreviewControl pc = new FastReport.Preview.PreviewControl();

        private void FormReport_Load(object sender, EventArgs e)
        {
            pc.Size = new Size(this.Size.Width, this.Size.Height);
            this.Controls.Add(pc);

            Report report = new Report();
            report.Load("ReportEmp.frx");

            DataSet ds = new DataSet();
            ds.ReadXml("dataXml.xml");
            report.RegisterData(ds.Tables["Employee"], "Employee");
            report.GetDataSource("Employee").Enabled = true;

            report.Preview = pc;
            report.Show();      
        }
    }
}
