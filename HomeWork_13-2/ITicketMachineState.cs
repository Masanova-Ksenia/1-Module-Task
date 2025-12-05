using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13_2
{
    public interface ITicketMachineState
    {
        void SelectTicket();
        void InsertMoney();
        void DispenseTicket();
        void CancelTransaction();
    }
    public class IdleState : ITicketMachineState
    {
        private TicketMachine _machine;
        public IdleState(TicketMachine machine) => _machine = machine;
        public void SelectTicket()
        {
            Console.WriteLine("Билет выбран. Ожидание внесения денег...");
            _machine.CurrentState = _machine.WaitingForMoneyState;
        }
        public void InsertMoney() => Console.WriteLine("Сначала выберите билет!");
        public void DispenseTicket() => Console.WriteLine("Сначала выберите билет!");
        public void CancelTransaction() => Console.WriteLine("Нет транзакции для отмены!");
    }
    public class WaitingForMoneyState : ITicketMachineState
    {
        private TicketMachine _machine;
        public WaitingForMoneyState(TicketMachine machine) => _machine = machine;
        public void SelectTicket() => Console.WriteLine("Билет уже выбран!");
        public void InsertMoney()
        {
            Console.WriteLine("Деньги внесены.");
            _machine.CurrentState = _machine.MoneyReceivedState;
        }
        public void DispenseTicket() => Console.WriteLine("Сначала внесите деньги!");
        public void CancelTransaction()
        {
            Console.WriteLine("Транзакция отменена.");
            _machine.CurrentState = _machine.TransactionCanceledState;
        }
    }
    public class MoneyReceivedState : ITicketMachineState
    {
        private TicketMachine _machine;
        public MoneyReceivedState(TicketMachine machine) => _machine = machine;
        public void SelectTicket() => Console.WriteLine("Билет уже выбран!");
        public void InsertMoney() => Console.WriteLine("Деньги уже внесены!");
        public void DispenseTicket()
        {
            Console.WriteLine("Билет выдан!");
            _machine.CurrentState = _machine.TicketDispensedState;
        }
        public void CancelTransaction()
        {
            Console.WriteLine("Транзакция отменена, деньги возвращены.");
            _machine.CurrentState = _machine.TransactionCanceledState;
        }
    }
    public class TicketDispensedState : ITicketMachineState
    {
        private TicketMachine _machine;
        public TicketDispensedState(TicketMachine machine) => _machine = machine;
        public void SelectTicket() => Console.WriteLine("Возьмите билет. Автомат возвращается в ожидание...");
        public void InsertMoney() => Console.WriteLine("Возьмите билет сначала!");
        public void DispenseTicket() => Console.WriteLine("Билет уже выдан!");
        public void CancelTransaction() => Console.WriteLine("Невозможно отменить, билет уже выдан.");
        public void ReturnToIdle() => _machine.CurrentState = _machine.IdleState;
    }
    public class TransactionCanceledState : ITicketMachineState
    {
        private TicketMachine _machine;
        public TransactionCanceledState(TicketMachine machine) => _machine = machine;
        public void SelectTicket() => Console.WriteLine("Начинаем новую транзакцию.");
        public void InsertMoney() => Console.WriteLine("Сначала выберите билет!");
        public void DispenseTicket() => Console.WriteLine("Транзакция отменена!");
        public void CancelTransaction() => Console.WriteLine("Транзакция уже отменена.");
        public void ReturnToIdle() => _machine.CurrentState = _machine.IdleState;
    }
}
