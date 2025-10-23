using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7._1
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class LightOnCommand : ICommand
    {
        private Light _light;
        public LightOnCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.On();
        }
        public void Undo()
        {
            _light.Off();
        }
    }
    public class LightOffCommand : ICommand
    {
        private Light _light;
        public LightOffCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.Off();
        }
        public void Undo()
        {
            _light.On();
        }
    }
    public class TelevisionOnCommand : ICommand
    {
        private Television _tv;
        public TelevisionOnCommand(Television tv)
        {
            _tv = tv;
        }
        public void Execute()
        {
            _tv.On();
        }
        public void Undo()
        {
            _tv.Off();
        }
    }
    public class TelevisionOffCommand : ICommand
    {
        private Television _tv;
        public TelevisionOffCommand(Television tv)
        {
            _tv = tv;
        }
        public void Execute()
        {
            _tv.Off();
        }
        public void Undo()
        {
            _tv.On();
        }
    }
    public class AirConditionerOnCommand : ICommand
    {
        private AirConditioner _aircond;
        public AirConditionerOnCommand(AirConditioner aircond)
        {
            _aircond = aircond;
        }
        public void Execute()
        {
            _aircond.On();
        }
        public void Undo()
        {
            _aircond.Off();
        }
    }
    public class AirConditionerOffCommand : ICommand
    {
        private AirConditioner _aircond;
        public AirConditionerOffCommand(AirConditioner aircond)
        {
            _aircond = aircond;
        }
        public void Execute()
        {
            _aircond.Off();
        }
        public void Undo()
        {
            _aircond.On();
        }
    }
    public class AirConditionerEcoModeCommand : ICommand
    {
        private AirConditioner _aircond;
        public AirConditionerEcoModeCommand(AirConditioner aircond)
        {
            _aircond = aircond;
        }
        public void Execute()
        {
            _aircond.EcoMode();
        }
        public void Undo()
        {
            _aircond.On();
        }
    }
    public class AudioSystemOnCommand : ICommand
    {
        private AudioSystem _audio;
        public AudioSystemOnCommand(AudioSystem audio) => _audio = audio;
        public void Execute() => _audio.On();
        public void Undo() => _audio.Off();
    }

    public class AudioSystemOffCommand : ICommand
    {
        private AudioSystem _audio;
        public AudioSystemOffCommand(AudioSystem audio) => _audio = audio;
        public void Execute() => _audio.Off();
        public void Undo() => _audio.On();
    }
    public class MacroCommand : ICommand
    {
        private List<ICommand> _commands;
        public MacroCommand(List<ICommand> commands) => _commands = commands;

        public void Execute()
        {
            foreach (var command in _commands)
                command.Execute();
        }

        public void Undo()
        {
            foreach (var command in _commands)
                command.Undo();
        }
    }
}
