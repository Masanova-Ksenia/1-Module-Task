using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._1
{
    class Program
    {
        static void Main()
        {
            SmartHomeReceiver home = new SmartHomeReceiver();
            RemoteControl remote = new RemoteControl(5);
            var livingroom = new Light("Гостиная");
            var bedroom = new AirConditioner();

            remote.SetCommand(0, new LightOnCommand(livingroom));
            remote.SetCommand(1, new ACOnCommand(bedroom));
            remote.SetCommand(2, new CurtainsOpenCommand(home));

            remote.PressButton(0);
            remote.PressButton(1);
            remote.PressButton(2);
            remote.PressButton(3);

            remote.PressUndo();
            remote.PressUndo();

            var macro = new MacroCommand(new List<ICommand>
        {
            new LightOffCommand(livingroom),
            new ACOffCommand(bedroom),
            new CurtainsCloseCommand(home),
        });

            macro.Execute();
            macro.Undo();

            remote.StartRecording();
            remote.PressButton(0);
            remote.PressButton(3);
            remote.PressButton(2);
            var recordedMacro = remote.StopRecording();

            recordedMacro.Execute();

            remote.PressButton(4);
            remote.PressButton(99);
        }
    }
}
