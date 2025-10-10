using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_5._2
{
    public class ReportDirector
    {
        public void ConstructReport(IReportBuilder builder, ReportStyle style, string title, string content, string footer, Dictionary<string, string>? sections = null)
        {
            builder.SetStyle(style);
            builder.SetHeader(title);
            builder.SetContent(content);
            builder.SetFooter(footer);
            if (sections != null)
            {
                foreach (var s in sections) builder.AddSection(s.Key, s.Value);
            }
        }
    }
}
