using System.Text;

namespace Gas.Utils
{
    public static class ExportToExcelUtils
    {
        private static string ConvertToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        private static MemoryStream ExportToExcel<T>(List<T> dataList)
        {
            // Get property names from the class T
            var headers = typeof(T).GetProperties().Select(prop => prop.Name).ToArray();

            // Convert objects to string arrays
            List<string[]> stringArrays = new()
            {
                // Add headers as the first row
                headers
            };

            foreach (var item in dataList)
            {
                stringArrays.Add(ObjectToStringArray(item));
            }

            // Call ExportToExcel(List<string[]>) with the converted string arrays
            return ExportToExcel(stringArrays);
        }

        private static MemoryStream ExportToExcel(List<string[]> dataList)
        {
            // Create a memory stream to hold the CSV data
            MemoryStream stream = new();

            // Write CSV data to memory stream
            using (StreamWriter writer = new(stream, Encoding.UTF8, 1024, true))
            {
                // Write data rows
                foreach (var dataRow in dataList)
                {
                    WriteRow(writer, dataRow);
                }

                writer.Flush();
                stream.Position = 0;
            }

            return stream;
        }

        private static void WriteRow(StreamWriter writer, string[] rowData)
        {
            for (int i = 0; i < rowData.Length; i++)
            {
                // Quote fields containing special characters
                string field = rowData[i].Contains(',') || rowData[i].Contains('"')
                    ? $"\"{rowData[i].Replace("\"", "\"\"")}\""
                    : rowData[i];

                // Write field followed by comma (except for last field)
                writer.Write(field);
                if (i < rowData.Length - 1)
                {
                    writer.Write(",");
                }
            }

            // End the row
            writer.WriteLine();
        }

        private static string[] ObjectToStringArray<T>(T obj)
        {
            // Get property values from the object
            var properties = typeof(T).GetProperties().Select(prop => prop.GetValue(obj)?.ToString() ?? "").ToArray();
            return properties;
        }

        private static string CreateBase64<T>(List<T> dataList)
        {
            try
            {
                using MemoryStream excelStream = new();
                string base64Excel = ConvertToBase64(ExportToExcel(dataList).ToArray());
                return base64Excel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static byte[] ExportToExcelGetBytes<T>(List<T> dataList)
        {
            return Convert.FromBase64String(CreateBase64(dataList));
        }
    }

}
