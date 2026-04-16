using ThreadLab4;

class Program
{
    static void Main(string[] args)
    {
        Table table = new Table();

        for (int i = 0; i < 5; i++)
        {
            int id = i;
            new Thread(() => new Philosopher(table, id).Run()).Start();
        }
    }
}