using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadLab4
{
    public class Table
    {
        private readonly bool[] _isEating;
        private readonly object _locker;

        public Table()
        {
            _locker = new object();
            _isEating = new bool[5];
        }

        public void TakeForks(int id)
        {
            lock (_locker)
            {
                int left = (id + 4) % 5;
                int right = (id + 1) % 5;

                while (_isEating[left] || _isEating[right])
                {
                    Monitor.Wait(_locker);
                }

                _isEating[id] = true;
            }
        }

        public void PutForks(int id)
        {
            lock (_locker)
            {
                _isEating[id] = false;
                Monitor.PulseAll(_locker);
            }
        }
    }
}
