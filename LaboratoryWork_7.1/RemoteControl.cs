using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7._1
{
    public class RemoteControl
    {
        private ICommand _onCommand;
        private ICommand _offCommand;
        private ICommand _lastCommand;
        private List<string> _log = new List<string>();
        public void SetCommands(ICommand onCommand, ICommand offCommand)
        {
            _onCommand = onCommand;
            _offCommand = offCommand;
        }
        public void PressOnButton()
        {
            if (_onCommand == null)
            {
                Console.WriteLine("Ошибка: кнопка 'Вкл' не назначена!");
                return;
            }

            _onCommand.Execute();
            _lastCommand = _onCommand;
            _log.Add($"[{DateTime.Now}] Выполнено: {_onCommand.GetType().Name}");
        }

        public void PressOffButton()
        {
            if (_offCommand == null)
            {
                Console.WriteLine("Ошибка: кнопка 'Выкл' не назначена!");
                return;
            }

            _offCommand.Execute();
            _lastCommand = _offCommand;
            _log.Add($"[{DateTime.Now}] Выполнено: {_offCommand.GetType().Name}");
        }

        public void PressUndoButton()
        {
            if (_lastCommand != null)
            {
                Console.WriteLine("Отмена последней команды...");
                _lastCommand.Undo();
                _log.Add($"[{DateTime.Now}] Отмена: {_lastCommand.GetType().Name}");
            }
            else
            {
                Console.WriteLine("Нет команды для отмены.");
            }
        }

        public void ShowLog()
        {
            foreach (var entry in _log)
                Console.WriteLine(entry);
        }
    }
}
