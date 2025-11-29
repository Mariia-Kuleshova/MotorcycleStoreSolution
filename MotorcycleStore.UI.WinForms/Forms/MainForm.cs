using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.UI.WinForms.Forms.UseControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private readonly IProductService _productService;
        private Product _currentProduct;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;

        public MainForm(IProductService productService, IOrderService orderService, ICustomerService customerService, IEmployeeService employeeService)
        {
            _productService = productService;
            _orderService = orderService;
            _customerService = customerService;
            _employeeService = employeeService;
            InitializeComponent();
        }

        private void ProductsMenuLabel_Click(object sender, EventArgs e)
        {
            HighlightMenu((Control)sender);
            LoadControl(new ProductsUserControl(_productService));
        }

        private void LoadControl(UserControl control)
        {
            contentPanel1.Controls.Clear();      
            control.Dock = DockStyle.Fill;      
            contentPanel1.Controls.Add(control); 
        }

        private void OrdersMenuLabel_Click(object sender, EventArgs e)
        {
            HighlightMenu((Control)sender);
            LoadControl(new OrdersUserControl(_orderService, _customerService, _employeeService, _productService));
        }

        private void CustomersMenuLabel_Click(object sender, EventArgs e)
        {
            HighlightMenu((Control)sender);
            LoadControl(new CustomersUserControl(_customerService));
        }

        private void EmployeesMenuLabel_Click(object sender, EventArgs e)
        {
            HighlightMenu((Control)sender);
            LoadControl(new EmployeesUserControl(_employeeService));
        }

        private void ExitLable_Click(object sender, EventArgs e)
        {
            this.Hide();

            var loginForm = new LoginForm(_employeeService);
            loginForm.Show();

            loginForm.FormClosed += (s, args) => this.Close();
        }

        private void XLabel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void HighlightMenu(Control selected)
        {
            foreach (Control ctrl in menuPanel.Controls)
            {
                ctrl.ForeColor = Color.White;                
            }

            selected.ForeColor = Color.DarkGreen;             
        }
    }
}
