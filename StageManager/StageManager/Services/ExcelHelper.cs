using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.Services
{
    public class ExcelHelper
    { 
        public static void MultipleRows(Microsoft.Office.Interop.Excel.Worksheet worksheet, string[] columns, LinkedList<object[]> rows)
        {
            for (int i = 1; i <= columns.Length; i++)
            {
                worksheet.Cells[1, i] = columns[i - 1];
            }

            int j = 2;
            foreach (object[] row in rows)
            {
                for (int i = 1; i <= row.Length; i++)
                {
                    worksheet.Cells[j, i] = row[i - 1];
                }

                j++;
            }
        }
    }
}