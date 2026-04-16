public class Philosopher implements Runnable {
    private final Table table;
    private final Waiter waiter;
    private final int leftFork;
    private final int rightFork;
    private final int id;

    public Philosopher(Table table, int id, Waiter waiter) {
        this.table = table;
        this.id = id;
        this.leftFork = id;
        this.rightFork = (id + 1) % 5;
        this.waiter = waiter;
    }

    @Override
    public void run() {
        for (int i = 0; i < 10; i++) {
            System.out.println("Philosopher " + id + " is thinking " + (i + 1) + " times");
            waiter.requestPermission();
            table.getFork(leftFork);
            table.getFork(rightFork);
            System.out.println("Philosopher " + id + " is eating " + (i + 1) + " times");
            table.putFork(leftFork);
            table.putFork(rightFork);
            waiter.releasePermission();
        }
        
    }
}