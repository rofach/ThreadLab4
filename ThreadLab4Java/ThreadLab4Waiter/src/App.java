public class App {
    public static void main(String[] args) throws Exception {
        Table table = new Table();
        Waiter waiter = new Waiter();

        for (int i = 0; i < 5; i++) {
            new Thread(new Philosopher(table, i, waiter)).start();
        }
    }
}
