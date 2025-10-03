using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_5._2
{
    public class ReportDirector
    {
        public void ConstructReport(IReportBuilder builder, string header, string content, string footer, string style)
        {
            builder.SetHeader(header);
            builder.SetContent(content);
            builder.SetFooter(footer);
            builder.SetStyle(style);
        }
    }
}
