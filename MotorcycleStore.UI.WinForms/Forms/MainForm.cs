using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.UI.WinForms.Forms.UseControls;
using MotorcycleStore.UI.WinForms.Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly ProductImageApiClient _productImageApiClient;
        private readonly ICallbackRequestService _callbackRequestService;
        private readonly Employee _employee;

        private Label? _callbacksMenuLabel;

        public MainForm(
            IProductService productService,
            IOrderService orderService,
            ICustomerService customerService,
            IEmployeeService employeeService,
            ProductImageApiClient productImageApiClient,
            ICallbackRequestService callbackRequestService,
            Employee employee)
        {
            _productService = productService;
            _orderService = orderService;
            _customerService = customerService;
            _employeeService = employeeService;
            _productImageApiClient = productImageApiClient;
            _callbackRequestService = callbackRequestService;
            _employee = employee;
            InitializeComponent();
            SetupCallbacksMenuItem();
        }

        private void SetupCallbacksMenuItem()
        {
            var resources = new ComponentResourceManager(typeof(MainForm));

            var icon = new PictureBox
            {
                Cursor = Cursors.Hand,
                Location = new Point(30, 790),
                Size = new Size(80, 70),
                SizeMode = PictureBoxSizeMode.Zoom,
                TabStop = false
            };

            var menuImage = resources.GetObject("pictureBox1.Image") as Image;
            if (menuImage is not null)
                icon.Image = menuImage;

            icon.Click += CallbacksMenuLabel_Click;

            _callbacksMenuLabel = new Label
            {
                AutoSize = true,
                Cursor = Cursors.Hand,
                ForeColor = Color.White,
                Location = new Point(140, 790),
                Text = "Дзвінки",
                Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204)
            };
            _callbacksMenuLabel.Click += CallbacksMenuLabel_Click;

            menuPanel.Controls.Add(icon);
            menuPanel.Controls.Add(_callbacksMenuLabel);
            icon.BringToFront();
            _callbacksMenuLabel.BringToFront();
        }

        private void ProductsMenuLabel_Click(object sender, EventArgs e)
        {
            HighlightMenu((Control)sender);

            var productsControl = new ProductsUserControl(_productService, _productImageApiClient);

            productsControl.OnCreateOrder += productId =>
            {
                LoadOrderControl(productId);
            };

            LoadControl(productsControl);
        }

        private void LoadControl(UserControl control)
        {
            contentPanel1.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentPanel1.Controls.Add(control);
        }

        private void LoadOrderControl(int id)
        {
            HighlightMenu(OrdersMenuLabel);
            var orderControl = new OrdersUserControl(id, _employee, _orderService, _customerService, _employeeService, _productService);
            contentPanel1.Controls.Clear();
            contentPanel1.Controls.Add(orderControl);
        }

        private void OrdersMenuLabel_Click(object sender, EventArgs e)
        {
            HighlightMenu((Control)sender);
            LoadControl(new OrdersUserControl(_employee, _orderService, _customerService, _employeeService, _productService));
        }

        private void CallbacksMenuLabel_Click(object sender, EventArgs e)
        {
            HighlightMenu(_callbacksMenuLabel!);
            LoadControl(new CallbacksUserControl(_callbackRequestService));
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
            Hide();

            var loginForm = new LoginForm(_employeeService);
            loginForm.Show();

            loginForm.FormClosed += (s, args) => Close();
        }

        private void XLabel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void HighlightMenu(Control selected)
        {
            foreach (Control ctrl in menuPanel.Controls)
            {
                if (ctrl is Label)
                    ctrl.ForeColor = Color.White;
            }

            selected.ForeColor = Color.DarkGreen;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            HighlightMenu((Control)sender);
            LoadControl(new ReportsUserControl(_orderService));
        }
    }
}
