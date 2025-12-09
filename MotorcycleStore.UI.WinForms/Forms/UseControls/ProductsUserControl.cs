using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Application.Services;
using MotorcycleStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorcycleStore.UI.WinForms.Forms.UseControls
{
    public partial class ProductsUserControl : UserControl
    {
        private readonly IProductService _productService;
        private Product _currentProduct;
        public event Action<int> OnCreateOrder;

        public ProductsUserControl(IProductService productService)
        {
            _productService = productService;
            InitializeComponent();
        }

        private async void AddButton_Click(object sender, EventArgs e)
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
                IsAvailable = true,
            };

            if (GetVin(VINTextBox.Text) == string.Empty)
            {
                return;
            }

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

            var newProductDTO = new ProductDTO
            {
                Product = newProduct,
                Qty = qty
            };

            await _productService.AddAsync(newProductDTO);

            MessageBox.Show("Новий товар доданий");
            await LoadProductsAsync();
            ClearTextBoxes();
        }

        private string GetVin(string vin)
        {
            if (vin.Length == 17)
            {
                return vin;
            }

            MessageBox.Show("Невірний формат VIN");
            return string.Empty;
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
                !string.IsNullOrEmpty(PriceTextBox.Text) && 
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

            CategoryComboBox.DataSource = GetMotorcycleCategories();
            CategoryComboBox.SelectedIndex = -1;

            ProductsDataGridView.MouseDown += ProductsDataGridView_MouseDown;
        }

        public static List<string> GetMotorcycleCategories()
        {
            return new List<string>
            {
                "Sport",
                "Cruiser",
                "Touring",
                "Adventure",
                "Naked",
                "Off-road",
                "Scooter",
                "Cafe Racer",
                "Chopper",
                "Enduro",
                "Dual Sport",
                "Street",
                "Classic"
            };
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

        private async void EditStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ProductsDataGridView.SelectedRows.Count == 0)
                return;

            // Получаем выбранный объект Product
            var row = ProductsDataGridView.SelectedRows[0];
            var selectedProductId = Convert.ToInt32(row.Cells[0].Value);
            var product = await _productService.GetByIdAsync(selectedProductId);

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
            QtyTextBox.Text = product.Inventory == null ? "0" : product.Inventory.Quantity.ToString();
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
            if (_currentProduct == null) return;
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

            if (GetVin(VINTextBox.Text) == string.Empty)
            {
                return;
            }

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
            _productService.UpdateAsync(_currentProduct, qty);

            MessageBox.Show("Товар оновлено!");
            LoadProductsAsync();
            ClearTextBoxes();
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
                {
                    await LoadProductsAsync();
                    return;
                }

                var searchTerm = SearchTextBox.Text.Trim().ToLower();
                var allProducts = await _productService.GetAllAsync();

                var filteredProducts = allProducts.Where(c =>
                    c.Name.ToLower().Contains(searchTerm) ||
                    c.Brand.ToLower().Contains(searchTerm) ||
                    c.Category.Contains(searchTerm) ||
                    c.VIN.Contains(searchTerm) ||
                    c.ModelYear.ToString().Contains(searchTerm) ||
                    c.SupplierName.Contains(searchTerm)
                ).ToList();

                try
                {
                    ProductsDataGridView.Rows.Clear();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    ProductsDataGridView.DataSource = null;
                }

                ProductsDataGridView.DataSource = filteredProducts;

                //foreach (var product in filteredProducts)
                //{
                    

                    
                //    ProductsDataGridView.Rows.Add(
                //        product.Id,
                //        product.Name,
                //        product.Brand,
                //        product.Category,
                //        product.VIN,
                //        product.ModelYear,
                //        product.Inventory != null ? product.Inventory.Quantity : 0,
                //        product.Price,
                //        product.SupplierName,
                //        product.Description
                //    ); ;
                //}

                foreach (DataGridViewRow row in ProductsDataGridView.Rows)
                {
                    var pr = row.DataBoundItem as Product;
                    if (pr != null)
                        row.Cells["QtyColumn"].Value = pr.Inventory?.Quantity ?? 0;
                }

                if (filteredProducts.Count == 0)
                {
                    MessageBox.Show("Нічого не знайдено!",
                        "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка пошуку: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CreateOrderButton_Click(object sender, EventArgs e)
        {
            if(int.TryParse(ProductsDataGridView.CurrentRow.Cells[6].Value.ToString(), out int qty))
            {
                if (qty < 1)
                {
                    MessageBox.Show("Неможливо створити замовлення. Немає в наявності.");
                }
                else if (MessageBox.Show("Створити замовлення?", "Підтвердження",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var product = (Product)ProductsDataGridView.SelectedRows[0].DataBoundItem;
                    OnCreateOrder?.Invoke(product.Id);

                    await LoadProductsAsync();
                }
            }           
        }
    }
}
