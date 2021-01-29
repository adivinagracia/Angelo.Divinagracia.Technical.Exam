using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angelo.Divinagracia.Technical.Exam
{
    public interface IBank
    {
        void Withdraw(double amount);
        void Deposit(double amount);
        double GetBalance();
        void catchException(string message);
    }
}
