using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocksAndMonitor
{
    internal class Account
    {
        private Object newLock = new object();

        private int _initialBalance;

        Random random = new Random();

        public Account(int initialBalance)
        {
            _initialBalance = initialBalance;
        }

        int Withdraw(int amount)
        {
            if (_initialBalance < 0)
            {
                throw new Exception("Not enough balance");
            }

            Monitor.Enter(newLock);
            try
            {
                if (_initialBalance >= amount)
                {
                    Console.WriteLine($"Amount drawn: {amount}");
                    _initialBalance -= amount;

                    return _initialBalance;
                }
            }
            finally
            {
                Monitor.Exit(newLock);
            }

            return 0;
        }

        public void WithdrawRandomly()
        {
            for (int i = 0; i < 100; i++)
            {
                var balance = Withdraw(random.Next(2000, 5000));

                if (balance > 0)
                {
                    Console.WriteLine($"Balance left: {balance}");
                } 
            }
        }
    }
}
