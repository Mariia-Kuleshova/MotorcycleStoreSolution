using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace MotorcycleStore.Reports
{
    public class RepExcel : IDisposable
    {
        public Excel.Application excelapp;
        Excel.Workbooks excelappworkbooks;
        Excel.Workbook excelappworkbook;
        private Excel.Sheets excelsheets; // колекція листів в екселі
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelcells; // діапазон ячеєк
                                        // Конструктор
        public RepExcel()
        {
            excelapp = new Excel.Application();
            excelapp.Visible = false;
        }
        public void Dispose()
        {
            // Release COM objects (very important!)
            if (excelapp != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelapp);
            if (excelappworkbooks != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelappworkbooks);
            if (excelappworkbook != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelappworkbook);
            if (excelsheets != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelsheets);
            if (excelworksheet != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelworksheet);
            if (excelcells != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelcells);
            excelapp = null;
            excelappworkbooks = null;
            excelappworkbook = null;
            excelsheets = null;
            excelworksheet = null;
            excelcells = null;
            GC.Collect();
            Console.WriteLine("RepExcel", "Dispose OK", 3, true);
            GC.GetTotalMemory(true);
        }
        //************************************************************************************
        // Зберігаємо книгу
        public void CreateNewBook(string fullPathAndFilename)
        {
            try
            {
                excelapp.SheetsInNewWorkbook = 5;
                excelapp.Workbooks.Add(Type.Missing);
                excelapp.DisplayAlerts = false;

                excelappworkbooks = excelapp.Workbooks;
                // нумерация від 1
                excelappworkbook = excelappworkbooks[1];
                excelsheets = excelappworkbook.Worksheets;
                //Отримуємо посилання на лист 1
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Name = "Saturn Data";
                excelappworkbook.Saved = true;
                excelappworkbook.SaveAs(fullPathAndFilename, Excel.XlFileFormat.xlExcel7,          //object FileFormat
                Type.Missing,                       //object Password
                Type.Missing,                       //object WriteResPassword  
                Type.Missing,                       //object ReadOnlyRecommended
                Type.Missing,                       //object CreateBackup
                Excel.XlSaveAsAccessMode.xlNoChange,//XlSaveAsAccessMode AccessMode
                Type.Missing,                       //object ConflictResolution
                Type.Missing,                       //object AddToMru
                Type.Missing,                       //object TextCodepage
                Type.Missing,                       //object TextVisualLayout
                Type.Missing);
                excelapp.Workbooks.Close();
                excelapp.Quit();
                Console.WriteLine("CreateNewBook  " + fullPathAndFilename, "OK", 3, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateNewBook  " + fullPathAndFilename, ex.Message, 3, true);
                excelapp.Quit();
                Dispose();
            }
        }
        public void OpenBook(string fullPathAndFilename)
        {
            try
            {
                excelapp.Workbooks.Open(fullPathAndFilename,
                Type.Missing, false, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
                Console.WriteLine("OpenBook " + fullPathAndFilename, "OK", 3, true);
            }
            catch (Exception ex) { Console.WriteLine("OpenBook", ex.Message, 3, true); }

        }
        public void CloseBook()
        {
            try
            {
                excelapp.Workbooks.Close();
                excelapp.Quit();
                Console.WriteLine("CloseBook", "OK", 3, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CloseBook", ex.Message, 3, true);
            }
        }
        public void Save(string fullPathAndFilename)
        {
            try
            {
                excelappworkbooks = excelapp.Workbooks;
                excelappworkbook = excelappworkbooks[1];
                excelappworkbook.Saved = false;
                excelappworkbook.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Save", ex.Message, 3, true);
                //  MessageBox.Show("Возникла проблема при сохранении файла. " + ex.Message);  
            }
        }
        public void SaveAs(string fullPathAndFilename)
        {
            try
            {
                excelappworkbooks = excelapp.Workbooks;
                excelappworkbook = excelappworkbooks[1];
                excelappworkbook.Saved = true;
                excelappworkbook.SaveAs(fullPathAndFilename, Excel.XlFileFormat.xlExcel7,          //object FileFormat
         Type.Missing,                       //object Password
         Type.Missing,                       //object WriteResPassword  
         false,                       //object ReadOnlyRecommended
         Type.Missing,                       //object CreateBackup
         Excel.XlSaveAsAccessMode.xlNoChange,//XlSaveAsAccessMode AccessMode
         Type.Missing,                       //object ConflictResolution
         Type.Missing,                       //object AddToMru
         Type.Missing,                       //object TextCodepage
         Type.Missing,                       //object TextVisualLayout
         Type.Missing);
                Console.WriteLine("SaveAs " + fullPathAndFilename, "OK", 3, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SaveAs " + fullPathAndFilename, ex.Message, 3, true);
            }

        }
        public void SetValue(string pageName, string address, string StrValues, string typeValue, bool isBold = false) // "A10", "значення"
        {
            excelappworkbook = excelappworkbooks[1];
            excelsheets = excelappworkbook.Worksheets;

            try
            {
                excelworksheet = (Excel.Worksheet)excelsheets[pageName];
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetValue page - " + pageName + "  address - " + address + " Value - " + StrValues, ex.Message, 3, true);
                excelsheets.Add();
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(excelsheets.Count);
                excelworksheet.Name = pageName;
            }
            try
            {
                excelcells = excelworksheet.get_Range(address, address);
                if (typeValue == "double") excelcells.Value2 = Convert.ToDouble(StrValues, CultureInfo.GetCultureInfo("en-US").NumberFormat); //Convert.ToDouble(StrValues);
                if (typeValue == "string") excelcells.Value2 = StrValues;
                if (isBold) excelcells.EntireRow.Font.Bold = true;
                Console.WriteLine("SetValue page - " + pageName + "  address - " + address + " Value - " + StrValues, " OK", 3, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetValue page - " + pageName + "  address - " + address + " Value - " + StrValues, ex.Message, 3, true);
            }
        }

        public string GetValue(string pageName, string address)
        {
            excelappworkbooks = excelapp.Workbooks;
            excelappworkbook = excelappworkbooks[1];
            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets[pageName];
            excelcells = excelworksheet.get_Range(address, address);
            return Convert.ToString(excelcells.Value2);
        }
        public void HidenRow(string pageName, int indexRow)
        {
            excelappworkbooks = excelapp.Workbooks;
            excelappworkbook = excelappworkbooks[1];
            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets[pageName];

            excelworksheet.Range["A" + Convert.ToString(indexRow), "A" + Convert.ToString(indexRow)].Rows.Hidden = true;
        }
        public void DisplayLine(string pageName, int indexRow)
        {
            excelappworkbooks = excelapp.Workbooks;
            excelappworkbook = excelappworkbooks[1];
            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets[pageName];
            excelworksheet.Range["A" + Convert.ToString(indexRow), "A" + Convert.ToString(indexRow)].Rows.Hidden = false;
        }
    }
}
