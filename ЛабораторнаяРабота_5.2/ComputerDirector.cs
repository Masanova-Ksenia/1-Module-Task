using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_5._2
{
    public class ComputerDirector
    {
        private IComputerBuilder _builder;

        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructComputer()
        {
            _builder.SetCPU();
            _builder.SetRAM();
            _builder.SetStorage();
            _builder.SetGPU();
            _builder.SetOS();
            _builder.SetCooling();
            _builder.SetPowerSupply();
        }

        public Computer GetComputer()
        {
            return _builder.GetComputer();
        }
    }
}
