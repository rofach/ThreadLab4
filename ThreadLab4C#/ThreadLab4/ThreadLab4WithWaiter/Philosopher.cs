using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadLab4WithWaiter;

namespace ThreadLab4
{
    public class Philosopher
    {
        private readonly Table _table;
        private readonly Waiter _waiter;
        private readonly int _leftFork;
        private readonly int _rightFork;
        private readonly int _id;

        public Philosopher(Table table, int id, Waiter waiter)
        {
            _table = table;
            _id = id;
            _leftFork = id;
            _rightFork = (id + 1) % 5;
            _waiter = waiter;
        }

        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Philosopher " + _id + " is thinking " + (i + 1) + " times");
                _waiter.RequestPermission();
                _table.GetFork(_leftFork);
                _table.GetFork(_rightFork);
                Console.WriteLine("Philosopher " + _id + " is eating " + (i + 1) + " times");
                _table.PutFork(_leftFork);
                _table.PutFork(_rightFork);
                _waiter.ReleasePermission();
            }
        }

    }
}
