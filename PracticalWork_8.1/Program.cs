using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            IReport salesReport = new SalesReport();
            Console.WriteLine(salesReport.Generate());

            IReport filteredReport = new DateFilterDecorator(
                new SalesReport(),
                new DateTime(2024, 10, 1),
                new DateTime(2024, 10, 31)
            );
            Console.WriteLine(filteredReport.Generate());

            IReport sortedReport = new SortingDecorator(
                new SalesReport(),
                SortingDecorator.SortCriteria.ByAmount
            );
            Console.WriteLine(sortedReport.Generate());

            IReport complexReport = new PdfExportDecorator(
                new SortingDecorator(
                    new DateFilterDecorator(
                        new SalesReport(),
                        new DateTime(2024, 10, 1),
                        new DateTime(2024, 11, 30)
                    ),
                    SortingDecorator.SortCriteria.ByDate
                )
            );
            Console.WriteLine(complexReport.Generate());

            IReport amountFilteredReport = new AmountFilterDecorator(
                new SalesReport(),
                10000,
                50000
            );
            Console.WriteLine(amountFilteredReport.Generate());

            IReport userReport = new StatusFilterDecorator(
                new UserReport(),
                "Активный"
            );
            Console.WriteLine(userReport.Generate());

            IReport csvReport = new CsvExportDecorator(
                new SortingDecorator(
                    new SalesReport(),
                    SortingDecorator.SortCriteria.ByDate
                )
            );
            Console.WriteLine(csvReport.Generate());
        }
    }
}
