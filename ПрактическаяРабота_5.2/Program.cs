using System.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ПрактическаяРабота_5._2;
using static ПрактическаяРабота_5._2.PdfReportBuilder;

namespace ПрактическаяРабота_5._2
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var style1 = new ReportStyle { BackgroundColor = "#FFFFFF", FontColor = "#000000", FontSize = 12 };
            var style2 = new ReportStyle { BackgroundColor = "#F4F6F8", FontColor = "#333333", FontSize = 14 };
            var sections = new Dictionary<string, string>
            {
                ["Introduction"] = "A brief introduction to the report.\nYou can insert multiple lines here.",
                ["Data"] = "Table/graph/data description...",
                ["Conclusions"] = "Brief conclusions and recommendations."
            };
            var director = new ReportDirector();

            var textBuilder = new TextReportBuilder();
            director.ConstructReport(textBuilder, style1, "Text Report", "Content", "(c) 2025 Example", sections);
            var textReport = textBuilder.GetReport();
            var textPath = Path.Combine(Directory.GetCurrentDirectory(), "report.txt");
            textBuilder.SaveToFile(textPath);
            Console.WriteLine($"Text Report saved: {textPath}");

            var htmlBuilder = new HtmlReportBuilder();
            director.ConstructReport(htmlBuilder, style2, "HTML Report", "Content", "Footer HTML", sections);
            var htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "report.html");
            htmlBuilder.SaveToFile(htmlPath);
            Console.WriteLine($"HTML Report saved: {htmlPath}");

            var pdfBuilder = new PdfReportBuilder();
            director.ConstructReport(pdfBuilder, style1, "PDF Report", "Content", "Signature", sections);
            var pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "report.pdf");
            try
            {
                pdfBuilder.SaveToFile(pdfPath);
                Console.WriteLine($"PDF Report saved: {pdfPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error PDF\n" + ex.Message);
            }

            var jsonBuilder = new JsonReportBuilder();
            director.ConstructReport(jsonBuilder, style2, "JSON Report", "Content", "Footer JSON", sections);
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "report.json");
            jsonBuilder.SaveToFile(jsonPath);
            Console.WriteLine($"JSON Report saved: {jsonPath}");


            Console.WriteLine("Done. Check the files in the working folder.");
        }
    }
}