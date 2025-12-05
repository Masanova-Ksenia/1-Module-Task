using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13_2
{
    public class TicketMachine
    {
        public ITicketMachineState CurrentState { get; set; }
        public ITicketMachineState IdleState { get; }
        public ITicketMachineState WaitingForMoneyState { get; }
        public ITicketMachineState MoneyReceivedState { get; }
        public ITicketMachineState TicketDispensedState { get; }
        public ITicketMachineState TransactionCanceledState { get; }

        public TicketMachine()
        {
            IdleState = new IdleState(this);
            WaitingForMoneyState = new WaitingForMoneyState(this);
            MoneyReceivedState = new MoneyReceivedState(this);
            TicketDispensedState = new TicketDispensedState(this);
            TransactionCanceledState = new TransactionCanceledState(this);
            CurrentState = IdleState;
        }
        public void SelectTicket() => CurrentState.SelectTicket();
        public void InsertMoney() => CurrentState.InsertMoney();
        public void DispenseTicket() => CurrentState.DispenseTicket();
        public void CancelTransaction() => CurrentState.CancelTransaction();
    }
}
