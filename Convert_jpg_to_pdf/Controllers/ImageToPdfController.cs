using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting; 
using iTextSharp.text;
using iTextSharp.text.pdf;

public class ImageToPdfController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ImageToPdfController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public IActionResult ConvertToPdf()
    {
        Document doc = new Document();
        MemoryStream ms = new MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(doc, ms); 
        doc.Open();
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Num.jpg");
        Image img = Image.GetInstance(imagePath);
        doc.Add(img);
        doc.Close();
        byte[] pdfBytes = ms.ToArray();
        return File(pdfBytes, "application/pdf", "output.pdf");
    }
}
