using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadLab4;

namespace ThreadLab4WithWaiter
{
    public class Waiter
    {
        private readonly Semaphore _semaphore = new Semaphore(4, 4);

        public void RequestPermission()
        {
            _semaphore.WaitOne();
        }
        public void ReleasePermission()
        {
            _semaphore.Release();
        }
    }
}
