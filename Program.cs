using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angelo.Divinagracia.Technical.Exam
{
    class Program
    {
        static void Main(string[] args)
        {
         IBank bank = new Bank(5000);
            IBank bankValidator = new ValidationDecorator(bank);
            IBank bankLogger = new LoggingDecorator(bankValidator);
            bool continueToRun = true;
            try
            {
                while (continueToRun)
                {
                    continueToRun = true;

                    Console.WriteLine("Balance: " + bank.GetBalance().ToString("n2"));
                    Console.Write("Enter action followed by amount. e.g. \"withdraw 2000\" : ");

                    var input = Console.ReadLine();
                    char[] delimeter = { ' ' };

                    string[] words = input.Split(delimeter);

                    var action = words[0];
                    double amount = 0.00;
                    if (!words.Contains("balance")) { amount = Convert.ToDouble(words[1]); }

                    switch (action)
                    {
                        case "withdraw":
                            bankLogger.Withdraw(amount);
                            break;

                        case "deposit":
                            bankLogger.Deposit(amount);
                            break;

                        case "balance":
                            Console.WriteLine("Your current balance is: " + bankLogger.GetBalance().ToString("n2"));
                            break;

                        case "exit":
                            continueToRun = false;
                            break;

                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
            }

            catch (Exception ee)
            {
                bankLogger.catchException(ee.Message);
                Console.ReadLine();
            }
        }
    }
}
