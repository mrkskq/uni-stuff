import java.util.*;
import java.util.concurrent.Semaphore;


public class DotProduct {

    static double dotProduct = 0;
    // DEFINE OTHER GLOBAL VARIABLES

    static final BoundedRandomGenerator random = new BoundedRandomGenerator();
    private static final int ARRAY_LENGTH = 10000000;
    private static final int NUM_THREADS = 10;
    private static final int CHUNK = ARRAY_LENGTH / NUM_THREADS;
    static double MAX = 0;


    // TODO: Define sychronization elements
    static Semaphore lock;
    static Semaphore semaphore;

    static void init() {
        // TODO: Initialize synchronization elements
        lock = new Semaphore(1);
        semaphore = new Semaphore(0);
    }

    // DO NOT CHANGE
    public static int[] getSubArray(int[] array, int start, int end) {
        return Arrays.copyOfRange(array, start, end);
    }

    public static void main(String[] args) throws InterruptedException {

        init();

        int[] a = ArrayGenerator.generate(ARRAY_LENGTH);
        int[] b = ArrayGenerator.generate(ARRAY_LENGTH);

        // TODO: Make the CalculateThread class a thread and start 10 instances
        // Each instance should take a subarray from the original array with equal length

        List<CalculateThread> calculateThreads = new ArrayList<CalculateThread>();

        for (int i = 0; i < NUM_THREADS; i++) {
            CalculateThread calculateThread = new CalculateThread(a, b, (i*CHUNK), (i*CHUNK)+CHUNK);
            calculateThreads.add(calculateThread);
        }

        //CalculateThread calculateThread = new CalculateThread(a,b,0,ARRAY_LENGTH); //change this if necessary

        // TODO: Create and start 10 threads for calculating the dot product

        for (CalculateThread calculateThread : calculateThreads) {
            calculateThread.start();
        }

        /*
        for (CalculateThread calculateThread : calculateThreads) {
            calculateThread.join();
        }
         */

        semaphore.acquire(NUM_THREADS); //aku e so join, bez ova

        // Replace the call to calculateDotProduct below with calculateDotProductParallel
        /* samo ova bez join i bez start
        for (CalculateThread calculateThread : calculateThreads) {
            calculateThread.calculateDotProductParallel();
        }
         */

        System.out.println("Max localSum: " + MAX);

        // TODO: Update the value of the global variable dotProduct

        // DO NOT CHANGE

        System.out.println("Your calculated dot product is: " + dotProduct);
        System.out.println("The actual dot product is: " + ArrayGenerator.calculateDotProduct(a,b));

        SynchronizationChecker.checkResult();

    }



    // TO DO: Make the CalculateThread class a thread, you can add methods and attributes
    static class CalculateThread extends Thread{

        private int[] a;
        private int[] b;
        int startSearch;
        int endSearch;
        private double localSum = 0;

        public CalculateThread(int[] a,int[] b, int startSearch, int endSearch) {
            this.a = a;
            this.b = b;
            this.startSearch=startSearch;
            this.endSearch=endSearch;
        }

        public Double calculateDotProduct() {
            double prod=0.0;
            for(int i=0;i<a.length;i++){
                prod+=a[i]*b[i];
            }

            return prod;
        }

        public void calculateDotProductParallel() throws InterruptedException {
            // TO DO: Implement and run this method from the thread
            // The method should not return a result
            // Take care of the proper synchronization

            for (int i = this.startSearch; i < this.endSearch; i++) {
                localSum += a[i]*b[i];
            }

            lock.acquire();
            dotProduct += localSum;
            if (localSum > MAX){
                MAX = localSum;
            }
            lock.release();

            semaphore.release(); //aku e so join, bez ova
        }

        @Override
        public void run() {
            try {
                calculateDotProductParallel();
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
        }
    }

    /******************************************************
     // DO NOT CHANGE THE CODE BELOW TO THE END OF THE FILE
     *******************************************************/

    static class BoundedRandomGenerator {
        static final Random random = new Random();
        static final int RANDOM_BOUND_UPPER = 10;
        static final int RANDOM_BOUND_LOWER = 6;

        public int nextInt() {
            return random.nextInt(RANDOM_BOUND_UPPER - RANDOM_BOUND_LOWER) + RANDOM_BOUND_LOWER;
        }

    }

    static class ArrayGenerator {

        private static double actualDotProduct = 0.0;

        static int[] generate(int length) {
            int[] array = new int[length];

            for (int i = 0; i < length; i++) {
                int num = DotProduct.random.nextInt();
                array[i]=num;

            }

            return array;
        }

        public static double calculateDotProduct( int[] a,  int[] b) {
            double prod=0.0;
            for(int i=0;i<a.length;i++){
                prod+=a[i]*b[i];
            }

            actualDotProduct=prod;
            return prod;
        }
    }

    static class SynchronizationChecker {
        public static void checkResult() {
            if (ArrayGenerator.actualDotProduct != dotProduct) {
                throw new RuntimeException("The calculated result is not equal to the actual dot product!");
            }
        }
    }
}
