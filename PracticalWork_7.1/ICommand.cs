using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._1
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class NullCommand : ICommand
    {
        public void Execute() { Console.WriteLine("Команда не назначена"); }
        public void Undo() { Console.WriteLine("Нет команды для отмены"); }
    }
    public class LightOnCommand : ICommand
    {
        private readonly Light light;
        public LightOnCommand(Light light) { this.light = light; }
        public void Execute() => light.On();
        public void Undo() => light.Off();
    }
    public class LightOffCommand : ICommand
    {
        private readonly Light light;
        public LightOffCommand(Light light) { this.light = light; }
        public void Execute() => light.Off();
        public void Undo() => light.On();
    }
    public class TVOnCommand : ICommand
    {
        private readonly TV tv;
        public TVOnCommand(TV tv) { this.tv = tv; }
        public void Execute() => tv.On();
        public void Undo() => tv.Off();
    }
    public class TVOffCommand : ICommand
    {
        private readonly TV tv;
        public TVOffCommand(TV tv) { this.tv = tv; }
        public void Execute() => tv.Off();
        public void Undo() => tv.On();
    }
    public class ACOnCommand : ICommand
    {
        private readonly AirConditioner ac;
        public ACOnCommand(AirConditioner ac) { this.ac = ac; }
        public void Execute() => ac.On();
        public void Undo() => ac.Off();
    }
    public class ACOffCommand : ICommand
    {
        private readonly AirConditioner ac;
        public ACOffCommand(AirConditioner ac) { this.ac = ac; }
        public void Execute() => ac.Off();
        public void Undo() => ac.On();
    }
    public class ACSetTemperatureCommand : ICommand
    {
        private readonly AirConditioner ac;
        private readonly int newTemp;
        private int previousTemp;
        public ACSetTemperatureCommand(AirConditioner ac, int temp) { this.ac = ac; newTemp = temp; }
        public void Execute()
        {
            previousTemp = 0;
            ac.SetTemperature(newTemp);
        }
        public void Undo()
        {
            if (previousTemp != 0)
                ac.SetTemperature(previousTemp);
            else
                Console.WriteLine("Нет предыдущей температуры для отмены");
        }
    }
    public class MacroCommand : ICommand
    {
        private readonly List<ICommand> commands;
        public MacroCommand(IEnumerable<ICommand> commands)
        {
            this.commands = new List<ICommand>(commands);
        }
        public void Execute()
        {
            foreach (var cmd in commands)
                cmd.Execute();
        }
        public void Undo()
        {
            for (int i = commands.Count - 1; i >= 0; i--)
                commands[i].Undo();
        }
    }
    public class CurtainsOpenCommand : ICommand
    {
        private SmartHomeReceiver _receiver;

        public CurtainsOpenCommand(SmartHomeReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute() => _receiver.OpenCurtains();
        public void Undo() => _receiver.CloseCurtains();
    }

    public class CurtainsCloseCommand : ICommand
    {
        private SmartHomeReceiver _receiver;

        public CurtainsCloseCommand(SmartHomeReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute() => _receiver.CloseCurtains();
        public void Undo() => _receiver.OpenCurtains();
    }
    public class LeaveHomeCommand : ICommand
    {
        private SmartHomeReceiver _receiver;

        public LeaveHomeCommand(SmartHomeReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            Console.WriteLine("'Выход из дома':");
            _receiver.TurnOffLight();
            _receiver.TurnOffAC();
            _receiver.CloseCurtains();
        }

        public void Undo()
        {
            Console.WriteLine("Отмена 'Выход из дома':");
            _receiver.TurnOnLight();
            _receiver.TurnOnAC();
            _receiver.OpenCurtains();
        }
    }
    public class NoCommand : ICommand
    {
        public void Execute() => Console.WriteLine("Команда не назначена!");
        public void Undo() => Console.WriteLine("Отменить нечего!");
    }

}
