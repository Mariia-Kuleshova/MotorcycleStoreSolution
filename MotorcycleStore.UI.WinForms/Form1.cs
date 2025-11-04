using MotorcycleStore.Application.Services;
using MotorcycleStore.Domain.Models;
//using SerializeLibrary;
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

        private void ExelButton_Click(object sender, EventArgs e)
        {
            var products = GetProducts(); //_productService.GetAll();
            var excelReport = new ExcelReportService();
            excelReport.ExportProductsToExcel(products);
            MessageBox.Show("Звіт успішно збережено у папці 'Документи\\MotorcycleReports'");
        }

        private List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "CBR600RR",
                    Brand = "Honda",
                    Category = "Sportbike",
                    VIN = "JH2PC4001XM000001",
                    ModelYear = 2022,
                    Price = 12999m,
                    Description = "Легкий спортивний мотоцикл з двигуном 599 см³, ідеальний для треку та міста.",
                    ImageUrl = "https://example.com/images/honda_cbr600rr.jpg",
                    IsAvailable = true,
                    SupplierId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "YZF-R1",
                    Brand = "Yamaha",
                    Category = "Superbike",
                    VIN = "JYARN23E1KA000002",
                    ModelYear = 2023,
                    Price = 17999m,
                    Description = "Флагман Yamaha з 998 см³ двигуном, відомий своєю стабільністю на високих швидкостях.",
                    ImageUrl = "https://example.com/images/yamaha_r1.jpg",
                    IsAvailable = true,
                    SupplierId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Ninja ZX-6R",
                    Brand = "Kawasaki",
                    Category = "Sportbike",
                    VIN = "JKAZX6E1XDA000003",
                    ModelYear = 2021,
                    Price = 11499m,
                    Description = "Легендарний спортбайк із відмінною динамікою та характерним дизайном Kawasaki.",
                    ImageUrl = "https://example.com/images/kawasaki_zx6r.jpg",
                    IsAvailable = true,
                    SupplierId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "MT-09",
                    Brand = "Yamaha",
                    Category = "Naked",
                    VIN = "JYARN29E4LA000004",
                    ModelYear = 2022,
                    Price = 9999m,
                    Description = "Потужний, але зручний streetfighter з двигуном 847 см³.",
                    ImageUrl = "https://example.com/images/yamaha_mt09.jpg",
                    IsAvailable = true,
                    SupplierId = 3
                },
                new Product
                {
                    Id = 5,
                    Name = "Bonneville T120",
                    Brand = "Triumph",
                    Category = "Classic",
                    VIN = "SMTDB00G0JT000005",
                    ModelYear = 2020,
                    Price = 12499m,
                    Description = "Класичний байк із ретро-дизайном і сучасною електронікою.",
                    ImageUrl = "https://example.com/images/triumph_bonneville.jpg",
                    IsAvailable = true,
                    SupplierId = 3
                },
                new Product
                {
                    Id = 6,
                    Name = "Panigale V4",
                    Brand = "Ducati",
                    Category = "Superbike",
                    VIN = "ZDMDA03A0KB000006",
                    ModelYear = 2023,
                    Price = 23999m,
                    Description = "Преміальний спортбайк із двигуном V4 та технологіями MotoGP.",
                    ImageUrl = "https://example.com/images/ducati_v4.jpg",
                    IsAvailable = false,
                    SupplierId = 4
                },
                new Product
                {
                    Id = 7,
                    Name = "Africa Twin CRF1100L",
                    Brand = "Honda",
                    Category = "Adventure",
                    VIN = "JH2SD06A2LM000007",
                    ModelYear = 2021,
                    Price = 15499m,
                    Description = "Надійний туристичний ендуро для далеких подорожей будь-яким покриттям.",
                    ImageUrl = "https://example.com/images/honda_africa_twin.jpg",
                    IsAvailable = true,
                    SupplierId = 1
                },
                new Product
                {
                    Id = 8,
                    Name = "Street Triple RS",
                    Brand = "Triumph",
                    Category = "Naked",
                    VIN = "SMTDAD77G0JT000008",
                    ModelYear = 2022,
                    Price = 11699m,
                    Description = "Маневрений і швидкий naked-байк із відмінною керованістю.",
                    ImageUrl = "https://example.com/images/triumph_street_triple.jpg",
                    IsAvailable = true,
                    SupplierId = 4
                },
                new Product
                {
                    Id = 9,
                    Name = "Vulcan S",
                    Brand = "Kawasaki",
                    Category = "Cruiser",
                    VIN = "JKAVN2B19NA000009",
                    ModelYear = 2021,
                    Price = 8299m,
                    Description = "Круїзер з унікальною ергономікою, що підходить як новачкам, так і досвідченим райдерам.",
                    ImageUrl = "https://example.com/images/kawasaki_vulcan_s.jpg",
                    IsAvailable = true,
                    SupplierId = 2
                },
                new Product
                {
                    Id = 10,
                    Name = "R 1250 GS Adventure",
                    Brand = "BMW",
                    Category = "Adventure",
                    VIN = "WB10A1200M6D00010",
                    ModelYear = 2023,
                    Price = 22499m,
                    Description = "Ікона серед туристичних мотоциклів, ідеальна для подорожей будь-якої складності.",
                    ImageUrl = "https://example.com/images/bmw_r1250gs.jpg",
                    IsAvailable = true,
                    SupplierId = 5
                }
            };

            return products;
        }
    }
}
