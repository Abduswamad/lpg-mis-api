using iText.Kernel.Pdf;
using iText.Layout.Element;
using Document = iText.Layout.Document;

public static class ExportToPdfClass
{
    public static byte[] ExportToPdf<T>(List<T> dataList)
    {
        using (MemoryStream pdfStream = new MemoryStream())
        {
            // Create a new PDF document
            PdfWriter pdfWriter = new PdfWriter(pdfStream);
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            Document document = new Document(pdfDocument);

            // Create table with headers
            Table table = new Table(dataList.Count > 0 ? dataList[0].GetType().GetProperties().Length : 1);
            foreach (var prop in dataList.Count > 0 ? dataList[0].GetType().GetProperties() : typeof(T).GetProperties())
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(prop.Name)));
            }

            // Add data rows
            foreach (var dataItem in dataList)
            {
                foreach (var prop in dataItem.GetType().GetProperties())
                {
                    table.AddCell(new Cell().Add(new Paragraph(prop.GetValue(dataItem)?.ToString() ?? "")));
                }
            }

            // Add table to the document
            document.Add(table);

            // Close the document
            document.Close();

            // Return the PDF as byte array
            return pdfStream.ToArray();
        }
    }
}
