using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._1
{
    public class RemoteControl
    {
        private ICommand[] _commands;
        private Stack<ICommand> _history = new Stack<ICommand>();
        private List<ICommand> _macroRecord = new List<ICommand>();
        private bool _isRecording = false;

        public RemoteControl(int slots)
        {
            _commands = new ICommand[slots];
            for (int i = 0; i < slots; i++)
                _commands[i] = new NoCommand();
        }

        public void SetCommand(int slot, ICommand command)
        {
            if (slot >= 0 && slot < _commands.Length)
                _commands[slot] = command;
        }

        public void PressButton(int slot)
        {
            if (slot < 0 || slot >= _commands.Length)
            {
                Console.WriteLine("Неверный слот!");
                return;
            }

            _commands[slot].Execute();
            _history.Push(_commands[slot]);

            if (_isRecording) _macroRecord.Add(_commands[slot]);
        }

        public void PressUndo()
        {
            if (_history.Count > 0)
            {
                ICommand last = _history.Pop();
                last.Undo();
            }
            else
            {
                Console.WriteLine("Нет команд для отмены!");
            }
        }
        public void StartRecording()
        {
            _macroRecord.Clear();
            _isRecording = true;
            Console.WriteLine("Началась запись макрокоманды...");
        }

        public MacroCommand StopRecording()
        {
            _isRecording = false;
            Console.WriteLine("Запись макрокоманды завершена.");
            return new MacroCommand(new List<ICommand>(_macroRecord));
        }
    }
}
