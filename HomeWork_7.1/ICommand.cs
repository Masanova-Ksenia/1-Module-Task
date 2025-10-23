using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7._1
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class Light
    {
        public void On() => Console.WriteLine("Свет включён");
        public void Off() => Console.WriteLine("Свет выключен");
    }

    public class Door
    {
        public void Open() => Console.WriteLine("Дверь открыта");
        public void Close() => Console.WriteLine("Дверь закрыта");
    }

    public class Thermostat
    {
        private int temperature = 22;
        public void Increase() { temperature++; Console.WriteLine($"Температура увеличена до {temperature}°C"); }
        public void Decrease() { temperature--; Console.WriteLine($"Температура уменьшена до {temperature}°C"); }
    }

    public class TV
    {
        public void On() => Console.WriteLine("Телевизор включён");
        public void Off() => Console.WriteLine("Телевизор выключен");
    }

    public class LightOnCommand : ICommand
    {
        private Light light;
        public LightOnCommand(Light light) { this.light = light; }
        public void Execute() => light.On();
        public void Undo() => light.Off();
    }

    public class LightOffCommand : ICommand
    {
        private Light light;
        public LightOffCommand(Light light) { this.light = light; }
        public void Execute() => light.Off();
        public void Undo() => light.On();
    }

    public class DoorOpenCommand : ICommand
    {
        private Door door;
        public DoorOpenCommand(Door door) { this.door = door; }
        public void Execute() => door.Open();
        public void Undo() => door.Close();
    }

    public class DoorCloseCommand : ICommand
    {
        private Door door;
        public DoorCloseCommand(Door door) { this.door = door; }
        public void Execute() => door.Close();
        public void Undo() => door.Open();
    }

    public class TempUpCommand : ICommand
    {
        private Thermostat thermostat;
        public TempUpCommand(Thermostat thermostat) { this.thermostat = thermostat; }
        public void Execute() => thermostat.Increase();
        public void Undo() => thermostat.Decrease();
    }

    public class TempDownCommand : ICommand
    {
        private Thermostat thermostat;
        public TempDownCommand(Thermostat thermostat) { this.thermostat = thermostat; }
        public void Execute() => thermostat.Decrease();
        public void Undo() => thermostat.Increase();
    }

    public class TVOnCommand : ICommand
    {
        private TV tv;
        public TVOnCommand(TV tv) { this.tv = tv; }
        public void Execute() => tv.On();
        public void Undo() => tv.Off();
    }

    public class TVOffCommand : ICommand
    {
        private TV tv;
        public TVOffCommand(TV tv) { this.tv = tv; }
        public void Execute() => tv.Off();
        public void Undo() => tv.On();
    }
}
