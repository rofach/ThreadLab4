public class Philosopher implements Runnable {
    private final Table table;
    private final int minFork;
    private final int maxFork;
    private final int id;

    public Philosopher(Table table, int id) {
        this.table = table;
        this.id = id;
        int leftFork = id;
        int rightFork = (id + 1) % 5;
        minFork = Math.min(leftFork, rightFork);
        maxFork = Math.max(leftFork, rightFork);
    }

    @Override
    public void run() {
        for (int i = 0; i < 10; i++) {
            System.out.println("Philosopher " + id + " is thinking " + (i + 1) + " times");               
            table.getFork(minFork);      
            table.getFork(maxFork);    
            System.out.println("Philosopher " + id + " is eating " + (i + 1) + " times");
            table.putFork(maxFork);
            table.putFork(minFork);
        }
    }
}