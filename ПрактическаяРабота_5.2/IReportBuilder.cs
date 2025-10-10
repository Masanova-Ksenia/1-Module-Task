using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ПрактическаяРабота_5._2
{
    public interface IReportBuilder
    {
        void SetHeader(string header);
        void SetContent(string content);
        void SetFooter(string footer);
        void AddSection(string sectionName, string sectionContent);
        void SetStyle(ReportStyle style);
        Report GetReport();
    }
    public class TextReportBuilder : IReportBuilder
    {
        private readonly Report _report = new();
        public void SetHeader(string header) => _report.Title = header;
        public void SetContent(string content) => _report.Content = content;
        public void SetFooter(string footer) => _report.Footer = footer;
        public void AddSection(string sectionName, string sectionContent) => _report.AddSection(sectionName, sectionContent);
        public void SetStyle(ReportStyle style) => _report.Style = style;
        public Report GetReport() => _report;
        public void SaveToFile(string path)
        {
            File.WriteAllText(path, _report.ToPlainText(), Encoding.UTF8);
        }
    }
    public class HtmlReportBuilder : IReportBuilder
    {
        private readonly Report _report = new();
        public void SetHeader(string header) => _report.Title = header;
        public void SetContent(string content) => _report.Content = content;
        public void SetFooter(string footer) => _report.Footer = footer;
        public void AddSection(string sectionName, string sectionContent) => _report.AddSection(sectionName, sectionContent);
        public void SetStyle(ReportStyle style) => _report.Style = style;
        public Report GetReport() => _report;
        public string BuildHtml()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"ru\">\n<head>\n<meta charset=\"utf-8\">\n<title>" + Escape(_report.Title) + "</title>");
            sb.AppendLine("<style>");
            sb.AppendLine($"body {{ background: {_report.Style?.BackgroundColor ?? "#fff"}; color: {_report.Style?.FontColor ?? "#000"}; font-size: {_report.Style?.FontSize ?? 12}px; font-family: Arial, Helvetica, sans-serif; padding:20px; }}");
            sb.AppendLine("h1 { margin-bottom: 8px; } .section { margin-top: 16px; padding:8px; border-radius:6px; } .footer { margin-top:24px; font-size:0.9em; color:#444 }");
            sb.AppendLine("</style>\n</head>\n<body>");
            sb.AppendLine($"<h1>{Escape(_report.Title)}</h1>");
            if (!string.IsNullOrEmpty(_report.Content)) sb.AppendLine($"<div class=\"content\">{Escape(_report.Content).Replace("\n", "<br/>")}</div>");
            foreach (var s in _report.Sections)
            {
                sb.AppendLine($"<div class=\"section\">\n<h2>{Escape(s.Key)}</h2>\n<p>{Escape(s.Value).Replace("\n", "<br/>")}</p>\n</div>");
            }
            sb.AppendLine($"<div class=\"footer\">{Escape(_report.Footer)}</div>");
            sb.AppendLine("</body>\n</html>");
            return sb.ToString();
        }
        public void SaveToFile(string path)
        {
            File.WriteAllText(path, BuildHtml(), Encoding.UTF8);
        }
        private static string Escape(string? s) => string.IsNullOrEmpty(s) ? string.Empty : System.Net.WebUtility.HtmlEncode(s);
    }
    public class PdfReportBuilder : IReportBuilder
    {
        private readonly Report _report = new();
        public void SetHeader(string header) => _report.Title = header;
        public void SetContent(string content) => _report.Content = content;
        public void SetFooter(string footer) => _report.Footer = footer;
        public void AddSection(string sectionName, string sectionContent) => _report.AddSection(sectionName, sectionContent);
        public void SetStyle(ReportStyle style) => _report.Style = style;
        public Report GetReport() => _report;
        public void SaveToFile(string path)
        {
            using var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            var doc = new Document(PageSize.A4, 36, 36, 36, 36);
            try
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();
                var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                var font = new iTextSharp.text.Font(baseFont, _report.Style?.FontSize ?? 12, iTextSharp.text.Font.NORMAL);

                if (!string.IsNullOrEmpty(_report.Title))
                {
                    var title = new Paragraph(_report.Title, new iTextSharp.text.Font(baseFont, (_report.Style?.FontSize ?? 12) + 4, iTextSharp.text.Font.BOLD));
                    doc.Add(title);
                    doc.Add(Chunk.NEWLINE);
                }
                if (!string.IsNullOrEmpty(_report.Content))
                {
                    doc.Add(new Paragraph(_report.Content, font));
                }
                foreach (var s in _report.Sections)
                {
                    doc.Add(Chunk.NEWLINE);
                    var h = new Paragraph(s.Key, new iTextSharp.text.Font(baseFont, (_report.Style?.FontSize ?? 12) + 2, iTextSharp.text.Font.BOLD));
                    doc.Add(h);
                    doc.Add(new Paragraph(s.Value ?? string.Empty, font));
                }
                doc.Add(Chunk.NEWLINE);
                if (!string.IsNullOrEmpty(_report.Footer)) doc.Add(new Paragraph(_report.Footer, font));
            }
            finally
            {
                doc.Close();
            }
        }
        public class JsonReportBuilder : IReportBuilder
        {
            private readonly Report _report = new();
            public void SetHeader(string header) => _report.Title = header;
            public void SetContent(string content) => _report.Content = content;
            public void SetFooter(string footer) => _report.Footer = footer;
            public void AddSection(string sectionName, string sectionContent) => _report.AddSection(sectionName, sectionContent);
            public void SetStyle(ReportStyle style) => _report.Style = style;
            public Report GetReport() => _report;
            public void SaveToFile(string path)
            {
                File.WriteAllText(path, _report.ToJson(), Encoding.UTF8);
            }
        }
    }
}
