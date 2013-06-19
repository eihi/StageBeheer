using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    class ExportExcel
    {
        private IExcelAlgorithm algorithm;

        public ExportExcel(IExcelAlgorithm algorithm)
        {
            this.algorithm = algorithm;
        }

        public void Export()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)app.ActiveSheet;

                algorithm.createWorksheet(ws);
                app.Visible = true;
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
    }
}