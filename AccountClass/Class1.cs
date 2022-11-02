using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClass
{
    class AccountEventArgs
    {
        // Сообщение
        public string Message { get; }
        // Сумма, на которую изменился счет
        public int Sum { get; }
        public AccountEventArgs(string message, int sum)
        {
            Message = message;
            Sum = sum;
        }
    }
    public class AccountClass
    {
        public delegate void AccountDelegate(string message, int sum);
        public delegate void AccountEventArgs(Account sender, AccountEventArgs e);
        public event AccountHandler Notify;
    }
    public delegate void AccountHandler(string message);
    public class Account
    {
        public int sum;
        public string fio;
        // Создаем переменную делегата
        AccountHandler taken;
        public Account(int sum, string fio)
        {
            this.sum = sum;
            this.fio = fio;
        }
        // Регистрируем делегат
        public void RegisterHandler(AccountHandler del)
        {
            taken = del;
        }
        public void Add(int sum) => this.sum += sum;
        public void Take(int sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;
                // вызываем делегат, передавая ему сообщение
                taken?.Invoke($"Со счета списано {sum} у.е.");
            }
            else
            {
                taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
            }
        }
    }
}



