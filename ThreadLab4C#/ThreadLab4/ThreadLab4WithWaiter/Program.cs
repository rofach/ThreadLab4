using ThreadLab4;
using ThreadLab4WithWaiter;

class Program
{
    static void Main(string[] args)
    {
        Table table = new Table();
        Waiter waiter = new Waiter();

        for (int i = 0; i < 5; i++)
        {
            int id = i;
            new Thread(() => new Philosopher(table, id, waiter).Run()).Start();
        }
    }
}