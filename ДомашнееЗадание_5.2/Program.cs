using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ДомашнееЗадание_5._2;

namespace ДомашнееЗадание_5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportDirector director = new ReportDirector();

            //Текстовый отчет
            IReportBuilder textBuilder = new TextReportBuilder();
            director.ConstructReport(textBuilder, "Отчет по продажам", "Содержимое: продажи выросли на 20%", "Конец отчета", "Bold");
            Report textReport = textBuilder.GetReport();
            Console.WriteLine("Текстовый отчет:\n" + textReport);

            //HTML отчет
            IReportBuilder htmlBuilder = new HtmlReportBuilder();
            director.ConstructReport(htmlBuilder, "Отчет по персоналу", "Содержимое: новые сотрудники приняты", "HR отдел", "Arial");
            Report htmlReport = htmlBuilder.GetReport();
            Console.WriteLine("HTML отчет:\n" + htmlReport.Header + "\n" + htmlReport.Content + "\n" + htmlReport.Footer + "\n" + htmlReport.Style);
            Console.WriteLine();

            //XML отчет
            IReportBuilder xmlBuilder = new XmlReportBuilder();
            director.ConstructReport(xmlBuilder, "Финансовый отчет", "Расходы снизились на 10%", "Бухгалтерия", "blue-theme");
            Report xmlReport = xmlBuilder.GetReport();
            Console.WriteLine("XML отчет:\n" + xmlReport.Header + "\n" + xmlReport.Content + "\n" + xmlReport.Footer + "\n" + xmlReport.Style);
        }
    }
}
