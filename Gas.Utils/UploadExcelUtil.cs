using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Gas.Utils
{
    interface IOperation
    {
        void Execute(object a);
    }
    public static class UploadExcelUtil
    {
        public static void ProcessExcel(IFormFile file, Action<IRow> operation, string SheetName)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Invalid file");
            }

            // Check if the file is an Excel file
            if (!file.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Only Excel files (.xlsx) are supported");
            }

            try
            {
                using var stream = new MemoryStream();
                // Copy the uploaded file content into a memory stream
                file.CopyTo(stream);
                stream.Position = 0;

                // Load the Excel file using NPOI
                IWorkbook workbook = new XSSFWorkbook(stream);

                // Process the Excel file (e.g., read data, perform operations)
                ProcessWorkbook(workbook, operation, SheetName);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw new Exception($"An error occurred while processing the file: {ex.Message}");
            }
        }

        private static void ProcessWorkbook(IWorkbook workbook, Action<IRow> operation,string SheetName = "shop")
        {
            // Iterate over each sheet in the workbook
            for (int sheetIndex = 0; sheetIndex < workbook.NumberOfSheets; sheetIndex++)
            {
                ISheet sheet = workbook.GetSheetAt(sheetIndex);

                // Loop through each row in the worksheet
                for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow row = sheet.GetRow(rowIndex);

                    if (row != null)
                    {
                        if (row != null && sheet.SheetName.Equals(SheetName, StringComparison.OrdinalIgnoreCase))
                        {
                            operation(row);
                        }
                    }
                }
            }
        }

    }

}




