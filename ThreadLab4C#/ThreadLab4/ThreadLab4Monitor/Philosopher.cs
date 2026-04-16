using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadLab4
{
    public class Philosopher
    {
        private Table _table;
        private int _minFork;
        private int _maxFork;
        private int _id;

        public Philosopher(Table table, int id)
        {
            _table = table;
            _id = id;
            int leftFork = id;
            int rightFork = (id + 1) % 5;

            _minFork = Math.Min(leftFork, rightFork);
            _maxFork = Math.Max(leftFork, rightFork);
        }

        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Philosopher " + _id + " is thinking " + (i + 1) + " times");
                _table.getFork(_minFork);
                Thread.Sleep(10);
                _table.getFork(_maxFork);
                Console.WriteLine("Philosopher " + _id + " is eating " + (i + 1) + " times");
                _table.putFork(_maxFork);
                _table.putFork(_minFork);
            }
        }

    }
}
