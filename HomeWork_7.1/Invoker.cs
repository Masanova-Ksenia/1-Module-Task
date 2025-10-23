using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7._1
{
    public class Invoker
    {
        private Stack<ICommand> history = new Stack<ICommand>();
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            history.Push(command);
        }
        public void UndoCommand()
        {
            if (history.Count > 0)
                history.Pop().Undo();
            else
                Console.WriteLine("Нет команд для отмены");
        }
    }
}
