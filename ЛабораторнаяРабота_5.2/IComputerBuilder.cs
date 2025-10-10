using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_5._2
{
    public interface IComputerBuilder
    {
        void SetCPU();
        void SetRAM();
        void SetStorage();
        void SetGPU();
        void SetOS();
        void SetCooling();
        void SetPowerSupply();
        Computer GetComputer();
    }
    public abstract class BaseComputerBuilder : IComputerBuilder
    {
        protected Computer _computer = new Computer();

        public abstract void SetCPU();
        public abstract void SetRAM();
        public abstract void SetStorage();
        public abstract void SetGPU();
        public abstract void SetOS();
        public abstract void SetCooling();
        public abstract void SetPowerSupply();

        public Computer GetComputer()
        {
            ValidateCompatibility();
            return _computer;
        }

        protected virtual void ValidateCompatibility()
        {
            if (_computer.GPU == "NVIDIA RTX 3080" && _computer.PowerSupply != "750W")
            {
                Console.WriteLine("Warning: Powerful GPU requires at least a 750W power supply!");
            }
        }
    }
    public class OfficeComputerBuilder : BaseComputerBuilder
    {
        public override void SetCPU() => _computer.CPU = "Intel i3";
        public override void SetRAM() => _computer.RAM = "8GB";
        public override void SetStorage() => _computer.Storage = "1TB HDD";
        public override void SetGPU() => _computer.GPU = "Integrated";
        public override void SetOS() => _computer.OS = "Windows 10";
        public override void SetCooling() => _computer.Cooling = "Air";
        public override void SetPowerSupply() => _computer.PowerSupply = "400W";
    }
    public class GamingComputerBuilder : BaseComputerBuilder
    {
        public override void SetCPU() => _computer.CPU = "Intel i9";
        public override void SetRAM() => _computer.RAM = "32GB";
        public override void SetStorage() => _computer.Storage = "1TB SSD";
        public override void SetGPU() => _computer.GPU = "NVIDIA RTX 3080";
        public override void SetOS() => _computer.OS = "Windows 11";
        public override void SetCooling() => _computer.Cooling = "Water";
        public override void SetPowerSupply() => _computer.PowerSupply = "750W";
    }
    public class GraphicWorkstationBuilder : BaseComputerBuilder
    {
        public override void SetCPU() => _computer.CPU = "AMD Ryzen 9 7950X";
        public override void SetRAM() => _computer.RAM = "64GB";
        public override void SetStorage() => _computer.Storage = "2TB NVMe SSD";
        public override void SetGPU() => _computer.GPU = "NVIDIA RTX 4090";
        public override void SetOS() => _computer.OS = "Windows 11 Pro";
        public override void SetCooling() => _computer.Cooling = "Custom Water Loop";
        public override void SetPowerSupply() => _computer.PowerSupply = "1000W";
    }
}
