import java.util.concurrent.Semaphore;

public class Waiter {
    private final Semaphore semaphore = new Semaphore(4);

    public void requestPermission() {
        try {
            semaphore.acquire();
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        }
    }

    public void releasePermission() {
        semaphore.release();
    }
}