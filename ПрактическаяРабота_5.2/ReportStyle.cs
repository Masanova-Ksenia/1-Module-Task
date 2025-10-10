using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_5._2
{
    public class ReportStyle
    {
        public string BackgroundColor { get; set; } = "#FFFFFF";
        public string FontColor { get; set; } = "#000000";
        public float FontSize { get; set; } = 12f;
        public override string ToString() => $"BG={BackgroundColor}, Font={FontColor}, Size={FontSize}";
    }
}
