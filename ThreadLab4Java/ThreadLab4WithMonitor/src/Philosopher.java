public class Philosopher implements Runnable {
    private final Table table;
    private final int id;

    public Philosopher(Table table, int id) {
        this.table = table;
        this.id = id;
    }

    @Override
    public void run() {
        for (int i = 0; i < 10; i++) {
            System.out.println("Philosopher " + id + " is thinking " + (i + 1) + " times");
            table.takeForks(id);
            System.out.println("Philosopher " + id + " is eating " + (i + 1) + " times");
            table.putForks(id);
        }
        
    }
}