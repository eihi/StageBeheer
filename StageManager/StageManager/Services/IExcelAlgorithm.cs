namespace StageManager.Services
{
    interface IExcelAlgorithm
    {
        void createWorksheet(Microsoft.Office.Interop.Excel.Worksheet worksheet);
    }
}