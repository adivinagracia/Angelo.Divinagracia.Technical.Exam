using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angelo.Divinagracia.Technical.Exam
{
    public class BankDecorator : IBank
    {
        private IBank _bank;

        public BankDecorator(IBank bank)
        {
            _bank = bank;
        }

        public virtual void Deposit(double amount)
        {
            _bank.Deposit(amount);
        }

        public virtual double GetBalance()
        {
            return _bank.GetBalance();
        }

        public virtual void Withdraw(double amount)
        {
            _bank.Withdraw(amount);
        }

        public virtual void catchException(string message)
        {
           _bank.catchException(message);
        }
    }
}
