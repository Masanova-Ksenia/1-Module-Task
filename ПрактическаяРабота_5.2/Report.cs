using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ПрактическаяРабота_5._2
{
    public class Report
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }
        public ReportStyle Style { get; set; }
        public Dictionary<string, string> Sections { get; } = new();
        public void AddSection(string name, string content) => Sections[name] = content;
        public string ToPlainText()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Title ?? string.Empty);
            sb.AppendLine(new string('-', 50));
            if (!string.IsNullOrEmpty(Content)) sb.AppendLine(Content);
            foreach (var s in Sections)
            {
                sb.AppendLine();
                sb.AppendLine($"## {s.Key}");
                sb.AppendLine(s.Value ?? string.Empty);
            }
            sb.AppendLine(new string('-', 50));
            sb.AppendLine(Footer ?? string.Empty);
            sb.AppendLine();
            sb.AppendLine($"[Style] {Style}");
            return sb.ToString();
        }
        public string ToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
