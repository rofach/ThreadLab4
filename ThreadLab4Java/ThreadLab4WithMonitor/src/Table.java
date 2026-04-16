public class Table {
    private final boolean[] isEating;
    private final Object locker;

    public Table() {
        locker = new Object();
        isEating = new boolean[5];
    }

    public void takeForks(int id) {
        synchronized (locker) {
            int left = (id + 4) % 5;
            int right = (id + 1) % 5;
            while (isEating[left] || isEating[right]) {
                try {
                    locker.wait();
                } catch (InterruptedException e) {
                    Thread.currentThread().interrupt();
                    return;
                }
            }

            isEating[id] = true;
        }
    }

    public void putForks(int id) {
        synchronized (locker) {
            isEating[id] = false;
            locker.notifyAll();
        }
    }
}