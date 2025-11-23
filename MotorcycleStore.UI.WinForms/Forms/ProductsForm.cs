using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Application.Services;
using MotorcycleStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MotorcycleStore.UI.WinForms.Forms
{
    public partial class ProductsForm : Form
    {

        private readonly IProductService _productService;
        private Product _currentProduct;
        private readonly NavigationService _nav;

        public ProductsForm(IProductService productService, NavigationService nav)
        {
            _productService = productService;
            InitializeComponent();
            _nav = nav;
        }

        private void LogoutLable_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!IsValidForm())
            {
                MessageBox.Show("Заповніть всі дані!");
                return;
            }

            var newProduct = new Product()
            {
                Name = ModelTextBox.Text,
                Brand = BrandTextBox.Text,
                Category = CategoryComboBox.Text,
                VIN = VINTextBox.Text,
                SupplierName = SupplierTextBox.Text,
                Description = CommentTextBox.Text,
            };

            var year = GetYear();
            if (year == 0)
            {
                MessageBox.Show("Невірний формат року");
                return;
            }

            var qty = GetQty();
            if (qty == 0)
            {
                MessageBox.Show("Невірний формат кількості");
                return;
            }

            var price = GetPrice();
            if (price == 0)
            {
                MessageBox.Show("Невірний формат ціни");
                return;
            }

            newProduct.ModelYear = year;
            newProduct.Price = price;
            _productService.AddAsync(newProduct);

            MessageBox.Show("Новий товар доданий");
            LoadProductsAsync();
            ClearTextBoxes();
        }

        private int GetYear()
        {
            if (int.TryParse(YearTextBox.Text, out int year))
            {
                return year;
            }

            return 0;
        }

        private int GetQty()
        {
            if (int.TryParse(QtyTextBox.Text, out int qty))
            {
                return qty;
            }

            return 0;
        }

        private decimal GetPrice()
        {
            if (decimal.TryParse(PriceTextBox.Text, out decimal price))
            {
                return price;
            }

            return 0;
        }

        private void ClearTextBoxes()
        {
            ModelTextBox.Clear();
            BrandTextBox.Clear();
            VINTextBox.Clear();
            YearTextBox.Clear();
            QtyTextBox.Clear();
            PriceTextBox.Clear();
            SupplierTextBox.Clear();
            ModelTextBox.Clear();
            CommentTextBox.Clear();
            CategoryComboBox.Text = string.Empty;
        }

        private bool IsValidForm()
        {
            bool valid =
                !string.IsNullOrEmpty(ModelTextBox.Text) &&
                !string.IsNullOrEmpty(BrandTextBox.Text) &&
                !string.IsNullOrEmpty(VINTextBox.Text) &&
                !string.IsNullOrEmpty(YearTextBox.Text) &&
                !string.IsNullOrEmpty(QtyTextBox.Text) &&
                !string.IsNullOrEmpty(PriceTextBox.Text) && decimal.TryParse(PriceTextBox.Text, out decimal pricetest) &&
                !string.IsNullOrEmpty(SupplierTextBox.Text);

            return valid;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private async void ProductsForm_Load(object sender, EventArgs e)
        {
            ProductsDataGridView.AutoGenerateColumns = false;

            IdColumn.DataPropertyName = "Id";
            ModelColumn.DataPropertyName = "Name";
            BrandColumn.DataPropertyName = "Brand";
            CategoryColumn.DataPropertyName = "Category";
            VINColumn.DataPropertyName = "VIN";
            YearColumn.DataPropertyName = "ModelYear";
            QtyColumn.DataPropertyName = "Quantity";
            PriceColumn.DataPropertyName = "Price";
            SupplierColumn.DataPropertyName = "SupplierName";
            CommentColumn.DataPropertyName = "Description";

            var products = await _productService.GetAllAsync();
            ProductsDataGridView.DataSource = products;

            foreach (DataGridViewRow row in ProductsDataGridView.Rows)
            {
                var product = row.DataBoundItem as Product;
                if (product != null)
                    row.Cells["QtyColumn"].Value = product.Inventory?.Quantity ?? 0;
            }

            ProductsDataGridView.MouseDown += ProductsDataGridView_MouseDown;
        }

        private void ProductsDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = ProductsDataGridView.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    // выбираем строку по правому клику
                    ProductsDataGridView.ClearSelection();
                    ProductsDataGridView.Rows[hit.RowIndex].Selected = true;

                    // сохраняем ID выбранного продукта (опционально)
                    ProductsDataGridView.CurrentCell = ProductsDataGridView.Rows[hit.RowIndex].Cells[1];

                    // показываем меню
                    ProductContextMenuStrip.Show(ProductsDataGridView, e.Location);
                }
            }
        }

        private async Task LoadProductsAsync()
        {
            var products = await _productService.GetAllAsync();

            ProductsDataGridView.DataSource = null;
            ProductsDataGridView.DataSource = products;

            foreach (DataGridViewRow row in ProductsDataGridView.Rows)
            {
                var product = row.DataBoundItem as Product;
                if (product != null)
                    row.Cells["QtyColumn"].Value = product.Inventory?.Quantity ?? 0;
            }
        }

        private void EditStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ProductsDataGridView.SelectedRows.Count == 0)
                return;

            // Получаем выбранный объект Product
            var product = (Product)ProductsDataGridView.SelectedRows[0].DataBoundItem;

            FillProductForm(product); // заполняем текстбоксы
            _currentProduct = product;
        }

        private void FillProductForm(Product product)
        {
            ModelTextBox.Text = product.Name;
            BrandTextBox.Text = product.Brand;
            CategoryComboBox.Text = product.Category;
            VINTextBox.Text = product.VIN;
            YearTextBox.Text = product.ModelYear.ToString();
            QtyTextBox.Text = "0";//product.Inventory.Product.ToString();
            PriceTextBox.Text = product.Price.ToString("0.##");
            CommentTextBox.Text = product.Description;
            SupplierTextBox.Text = product.SupplierName;
        }

        private async void DeleteStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ProductsDataGridView.SelectedRows.Count > 0)
            {
                var product = (Product)ProductsDataGridView.SelectedRows[0].DataBoundItem;
                int id = product.Id;

                if (MessageBox.Show("Видалити продукт?", "Підтвердження",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await _productService.DeleteAsync(id);
                    await LoadProductsAsync();
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!IsValidForm())
            {
                MessageBox.Show("Заповніть всі дані!");
                return;
            }

            _currentProduct.Name = ModelTextBox.Text;
            _currentProduct.Brand = BrandTextBox.Text;
            _currentProduct.Category = CategoryComboBox.Text;
            _currentProduct.VIN = VINTextBox.Text;
            _currentProduct.SupplierName = SupplierTextBox.Text;
            _currentProduct.Description = CommentTextBox.Text;

            var year = GetYear();
            if (year == 0)
            {
                MessageBox.Show("Невірний формат року");
                return;
            }

            var qty = GetQty();
            if (qty == 0)
            {
                MessageBox.Show("Невірний формат кількості");
                return;
            }

            var price = GetPrice();
            if (price == 0)
            {
                MessageBox.Show("Невірний формат ціни");
                return;
            }

            _currentProduct.ModelYear = year;
            _currentProduct.Price = price;
            _productService.UpdateAsync(_currentProduct);

            MessageBox.Show("Товар оновлено!");
            LoadProductsAsync();
            ClearTextBoxes();
        }

        private void XLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo<OrdersForm>(this);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo<CustomersForm>(this);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo<EmployeesForm>(this);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            //_nav.NavigateTo<EmployeesForm>(this);
        }

        private void label18_Click(object sender, EventArgs e)
        {
            //_nav.NavigateTo<EmployeesForm>(this);
        }

        private void label17_Click(object sender, EventArgs e)
        {
            _nav.NavigateTo<LoginForm>(this);
        }
    }
}
