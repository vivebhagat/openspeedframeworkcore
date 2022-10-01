using PdfSharpCore;
using PdfSharpCore.Pdf;
//using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Common.Helper
{
    public class PrintHelper
    {
        public static void Print<T>(string htmlString, T obj, string path) where T : class
        {
  //          PdfDocument pdf = PdfGenerator.GeneratePdf(htmlString, PageSize.A4);
  //          pdf.Save(path);
        }
    }
}