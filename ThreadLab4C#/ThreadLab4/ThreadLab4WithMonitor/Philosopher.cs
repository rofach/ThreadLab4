using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadLab4
{
    public class Philosopher
    {
        private readonly Table _table;
        private readonly int _id;

        public Philosopher(Table table, int id)
        {
            _table = table;
            _id = id;
        }

        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Philosopher " + _id + " is thinking " + (i + 1) + " times");
                _table.TakeForks(_id);
                Console.WriteLine("Philosopher " + _id + " is eating " + (i + 1) + " times");
                _table.PutForks(_id);
            }
        }

    }
}
