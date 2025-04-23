
import java.util.Arrays;
import java.util.Random;


public class DotProduct {

    static double dotProduct = 0;
    // DEFINE OTHER GLOBAL VARIABLES

    static final BoundedRandomGenerator random = new BoundedRandomGenerator();

    private static final int ARRAY_LENGTH = 10000000;

    private static final int NUM_THREADS = 10;


    // TODO: Define sychronization elements

    static void init() {
        // TODO: Initialize synchronization elements
    }

    // DO NOT CHANGE
    public static int[] getSubArray(int[] array, int start, int end) {
        return Arrays.copyOfRange(array, start, end);
    }

    public static void main(String[] args) {

        init();

        int[] a = ArrayGenerator.generate(ARRAY_LENGTH);
        int[] b = ArrayGenerator.generate(ARRAY_LENGTH);

        // TODO: Make the CalculateThread class a thread and start 10 instances
        // Each instance should take a subarray from the original array with equal length

        CalculateThread calculateThread = new CalculateThread(a,b,0,ARRAY_LENGTH); //change this if necessary

        // TODO: Create and start 10 threads for calculating the dot product

        // Replace the call to calculateDotProduct below with calculateDotProductParallel
        dotProduct = calculateThread.calculateDotProduct();

        // TODO: Update the value of the global variable dotProduct

        // DO NOT CHANGE

        System.out.println("Your calculated dot product is: " + dotProduct);
        System.out.println("The actual dot product is: " + ArrayGenerator.calculateDotProduct(a,b));

        SynchronizationChecker.checkResult();

    }



    // TO DO: Make the CalculateThread class a thread, you can add methods and attributes
    static class CalculateThread {

        private int[] a;
        private int[] b;
        int startSearch;
        int endSearch;

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

        public void calculateDotProductParallel() {
            // TO DO: Implement and run this method from the thread
            // The method should not return a result
            // Take care of the propper synchronization
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
