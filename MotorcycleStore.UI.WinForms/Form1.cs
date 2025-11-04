using MotorcycleStore.Domain.Models;
using SerializeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms
{
    public partial class Form1 : Form
    {
        public List<Employee> emplList = new List<Employee>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //emplList = GetSampleEmployees();
            //Serializer.SerializeToXml(emplList, "dataXml.xml");
            ////Serializer.SerializeToJson(emplList, "data.json");
            //FormReport formReport = new FormReport();
            //formReport.ShowDialog();
        }        
    }
}
