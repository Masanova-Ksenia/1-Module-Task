using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_5._2
{
    public interface IReportBuilder
    {
        void SetHeader(string header);
        void SetContent(string content);
        void SetFooter(string footer);
        void SetStyle(string style);
        Report GetReport();
    }
    public class TextReportBuilder : IReportBuilder
    {
        private Report _report = new Report();
        public void SetHeader(string header)
        {
            _report.Header = "=== " + header + " ===";
        }
        public void SetContent(string content)
        {
            _report.Content = content;
        }
        public void SetFooter(string footer)
        {
            _report.Footer = "--- " + footer + " ---";
        }
        public void SetStyle(string style)
        {
            _report.Style = $"(Текстовый стиль: {style})";
        }
        public Report GetReport()
        {
            return _report;
        }
    }
    public class HtmlReportBuilder : IReportBuilder
    {
        private Report _report = new Report();
        public void SetHeader(string header)
        {
            _report.Header = $"<h1>{header}</h1>";
        }
        public void SetContent(string content)
        {
            _report.Content = $"<p>{content}</p>";
        }
        public void SetFooter(string footer)
        {
            _report.Footer = $"<footer>{footer}</footer>";
        }
        public void SetStyle(string style)
        {
            _report.Style = $"<style>body {{ font-family: {style}; }}</style>";
        }
        public Report GetReport()
        {
            return _report;
        }
    }
    public class XmlReportBuilder : IReportBuilder
    {
        private Report _report = new Report();
        public void SetHeader(string header)
        {
            _report.Header = $"<header>{header}</header>";
        }
        public void SetContent(string content)
        {
            _report.Content = $"<content>{content}</content>";
        }
        public void SetFooter(string footer)
        {
            _report.Footer = $"<footer>{footer}</footer>";
        }
        public void SetStyle(string style)
        {
            _report.Style = $"<style>{style}</style>";
        }
        public Report GetReport() => _report;
    }
}
