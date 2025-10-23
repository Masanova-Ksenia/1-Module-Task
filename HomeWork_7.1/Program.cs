using System;
using System.Collections.Generic;


namespace HomeWork_7._1
{
    public class Program
    {
        public static void Main()
        {
            var light = new Light();
            var door = new Door();
            var thermostat = new Thermostat();
            var tv = new TV();
            var invoker = new Invoker();

            invoker.ExecuteCommand(new LightOnCommand(light));
            invoker.ExecuteCommand(new DoorOpenCommand(door));
            invoker.ExecuteCommand(new TempUpCommand(thermostat));
            invoker.ExecuteCommand(new TVOnCommand(tv));

            invoker.UndoCommand();
            invoker.UndoCommand();
            invoker.UndoCommand();
            invoker.UndoCommand();
            invoker.UndoCommand();
        }
    }
}
