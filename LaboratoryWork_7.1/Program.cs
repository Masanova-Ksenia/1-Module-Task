using System;
using System.Collections.Generic;

namespace LaboratoryWork_7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Light livingRoomLight = new Light();
            Television tv = new Television();
            AirConditioner airConditioner = new AirConditioner();
            AudioSystem audioSystem = new AudioSystem();

            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            ICommand tvOn = new TelevisionOnCommand(tv);
            ICommand tvOff = new TelevisionOffCommand(tv);

            ICommand airCondOn = new AirConditionerOnCommand(airConditioner);
            ICommand airCondOff = new AirConditionerOffCommand(airConditioner);
            ICommand airCondEco = new AirConditionerEcoModeCommand(airConditioner);

            ICommand audioOn = new AudioSystemOnCommand(audioSystem);
            ICommand audioOff = new AudioSystemOffCommand(audioSystem);

            ICommand eveningMode = new MacroCommand(new List<ICommand> { lightOn, tvOn, airCondOn });

            RemoteControl remote = new RemoteControl();

            Console.WriteLine("Управление светом:");
            remote.SetCommands(lightOn, lightOff);
            remote.PressOnButton();
            remote.PressOffButton();
            remote.PressUndoButton();

            Console.WriteLine("\nУправление телевизором:");
            remote.SetCommands(tvOn, tvOff);
            remote.PressOnButton();
            remote.PressOffButton();

            Console.WriteLine("\nУправление кондиционером:");
            remote.SetCommands(airCondOn, airCondOff);
            remote.PressOnButton();
            remote.PressOffButton();
            Console.WriteLine("Переключение в эконом-режим:");
            airCondEco.Execute();

            Console.WriteLine("\nУправление аудиосистемой:");
            remote.SetCommands(audioOn, audioOff);
            remote.PressOnButton();
            remote.PressOffButton();

            Console.WriteLine("\nПереключение на вечерний режим:");
            eveningMode.Execute();

            Console.WriteLine("\nПроверка обработки ошибки:");
            remote.SetCommands(null, null);
            remote.PressOnButton();

            Console.WriteLine("\nЛог действий:");
            remote.ShowLog();
        }
    }
}
