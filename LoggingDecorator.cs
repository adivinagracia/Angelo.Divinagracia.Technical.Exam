using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angelo.Divinagracia.Technical.Exam
{
    public class LoggingDecorator : BankDecorator
    {
        public LoggingDecorator(IBank bank) : base(bank) { }

        public override void Deposit(double amount)
        {
            try
            {
                base.Deposit(amount);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Transaction Type : Deposit");
                Console.WriteLine("Amount           : " + amount.ToString("n2"));
                Console.WriteLine("Balance          : " + this.GetBalance());
                Console.WriteLine("-----------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Amount: " + amount.ToString("n2"));
                Console.WriteLine(ex.Message);
            }
        }

        public override double GetBalance()
        {
            return base.GetBalance();
        }

        public override void Withdraw(double amount)
        {
            try
            {
                base.Withdraw(amount);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Transaction Type : Withdraw");
                Console.WriteLine("Amount           : " + amount.ToString("n2"));
                Console.WriteLine("Balance          : " + this.GetBalance());
                Console.WriteLine("-----------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Amount: " + amount.ToString("n2"));
                Console.WriteLine(ex.Message);
            }
        }

        public override void catchException(string message)
        {
            try
            {
                base.catchException(message);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Invalid Command");
                Console.WriteLine("-----------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
