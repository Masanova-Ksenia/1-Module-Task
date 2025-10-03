using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_5._2
{
    public class Report
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }
        public string Style { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(Header)) sb.AppendLine(Header);
            if (!string.IsNullOrEmpty(Content)) sb.AppendLine(Content);
            if (!string.IsNullOrEmpty(Footer)) sb.AppendLine(Footer);
            if (!string.IsNullOrEmpty(Style)) sb.AppendLine($"[Стиль: {Style}]");
            return sb.ToString();
        }
    }
}
