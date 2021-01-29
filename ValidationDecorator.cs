using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angelo.Divinagracia.Technical.Exam
{
    public class ValidationDecorator : BankDecorator
    {
        public ValidationDecorator(IBank bank) : base(bank) { }

        public override void Deposit(double amount)
        {
            if (amount > 50000)
            {
                throw new Exception("Maximum deposit amount is 50,000.00");
            }
            else if (amount < 1000)
            {
                throw new Exception("Minimum deposit amount is 1,000.00");
            }
            else
            {
                base.Deposit(amount);
            }
        }

        public override double GetBalance()
        {
            return base.GetBalance();
        }

        public override void Withdraw(double amount)
        {
            var balance = base.GetBalance();

            if (amount > 10000)
            {
                throw new Exception("Maximum withdrawal amount is 10,000.00");
            }
            else if (amount < 300)
            {
                throw new Exception("Minimum withdrawal amount is 300.00");
            }
            else if (amount > balance)
            {
                throw new Exception("Insuficient balance");
            }
            else
            {
                base.Withdraw(amount);
            }
        }
    }
}
