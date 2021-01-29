using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angelo.Divinagracia.Technical.Exam
{
    public class Bank : IBank
    {
        private double _initialBalance;
        private string _exception;
        public Bank(double initialBalance)
        {
            _initialBalance = initialBalance;
        }

        public void catchException(string message)
        {
            _exception = message;
        }

        public void Deposit(double amount)
        {
            _initialBalance += amount;
        }

        public double GetBalance()
        {
            return _initialBalance;
        }

        public void Withdraw(double amount)
        {
            _initialBalance -= amount;
        }
    }
}
