using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClass
{
    public class Class1
    {
        public delegate void AccountHandler(Account sender, AccountEventArgs e);

        public class Account
        {
            public event AccountHandler Notify;
            public int Sum { get; private set; }
            public string Fio;
            AccountHandler taken;
            public Account(int sum, string fio)
            {
                Sum = sum;
                Fio = fio;
            }
            public void RegisterHandler(AccountHandler del)
            {
                taken += del;
            }
            public void Add(int sum)
            {
                Sum += sum;
                Notify?.Invoke(this, new AccountEventArgs($"На счет поступило {sum}", sum));
            }
            public void Take(int sum)
            {
                if (Sum >= sum)
                {
                    Sum -= sum;
                    Notify?.Invoke(this, new AccountEventArgs($"Сумма {sum} снята со счета", sum));
                }
                else
                {
                    Notify?.Invoke(this, new AccountEventArgs("Нету денег на счёте", sum));
                }
            }
        }
        public class AccountEventArgs
        {
            public string Message { get; }
            public int Sum { get; }
            public AccountEventArgs(string message, int sum)
            {
                Message = message;
                Sum = sum;
            }
        }
    }
}



