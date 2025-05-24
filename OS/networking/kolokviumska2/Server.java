package kolokviumska2;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Server extends Thread {

    private int port;
    private String filePath;

    public Server(int port, String filePath) {
        this.port = port;
        this.filePath = filePath;
    }

    @Override
    public void run() {
        ServerSocket serverSocket = null;
        try {
            serverSocket = new ServerSocket(this.port);

            while (true){
                Socket clientSocket = null;
                try {
                    clientSocket = serverSocket.accept();
                    Worker worker = new Worker(clientSocket, filePath);
                    worker.start();
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static void main(String[] args) {
        //String filePath = System.getenv(NUMBERS_FILE);
        Server server = new Server(7319, "numbers.txt");
        server.start();
    }
}
