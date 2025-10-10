using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_5._2
{
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GPU { get; set; }
        public string OS { get; set; }
        public string Cooling { get; set; }
        public string PowerSupply { get; set; }

        public override string ToString()
        {
            return $"Computer: CPU - {CPU}, RAM - {RAM}, Storage - {Storage}, GPU - {GPU}, OS - {OS}, Cooling - {Cooling}, Power Supply - {PowerSupply}";
        }
    }
}
