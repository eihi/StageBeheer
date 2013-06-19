using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace StageManager.Services
{
    class ImportExcel
    {
        private DataTable _table;

        public ImportExcel()
        {
            _table = new DataTable();
            setup();
        }

        public DataTable Table
        {
            get { return _table; }
            private set { _table = value; }
        }

        /*
         * The method getTable opens a file, gets the first worksheet in the workbook, and fills the datatable Table with its contents.
         */
        public void setup()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFile.Filter = "Excel Workbook|*.xls";

            if (openFile.ShowDialog() == true)
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

                wb = app.Workbooks.Open(openFile.FileName);
                Microsoft.Office.Interop.Excel.Worksheet ws = wb.Sheets.get_Item(1);

                if (wb != null) // If there is a worksheet
                {
                    if (ws.UsedRange != null) // if the worksheet is not empty
                    {
                        Table = toDataTable(ws);
                    }
                }

                app.Visible = true;
            }
        }

        /*
         * The method toCSV turns an Excel worksheet into a csv file and returns it as a string. 
         */
        private string toCSV(Microsoft.Office.Interop.Excel.Worksheet ws)
        {
            StringBuilder sb = new StringBuilder();

            int columns = ws.UsedRange.Columns.Count;
            int rows = ws.UsedRange.Rows.Count;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    sb.Append(ws.Cells[i, j].Text);

                    if (j != columns)
                    {
                        sb.Append(",");
                    }
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        /*
         * The method toDataTable turns an Excel worksheet into a datatable.
         */
        private DataTable toDataTable(Microsoft.Office.Interop.Excel.Worksheet ws)
        {
            DataTable dt = new DataTable();

            int columns = ws.UsedRange.Columns.Count;
            int rows = ws.UsedRange.Rows.Count;

            for (int i = 1; i <= columns; i++)
            {
                dt.Columns.Add(ws.Cells[i, 1].Text);
            }

            for (int i = 2; i <= rows; i++)
            {
                string[] values = new string[columns];

                for (int j = 1; j <= columns; j++)
                {
                    values[j - 1] = ws.Cells[i, j].Text;
                }

                dt.Rows.Add(values);
            }

            return dt;
        }
    }
}