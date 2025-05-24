package kolokviumska3;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Server extends Thread{

    int port;
    String filePath;

    public Server(int port, String filePath) {
        this.port = port;
        this.filePath = filePath;
    }

    @Override
    public void run() {
        ServerSocket serverSocket = null;
        try {
            serverSocket = new ServerSocket(port);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        while (true) {
            try {
                Socket clientSocket = serverSocket.accept();
                Worker worker = new Worker(clientSocket, filePath);
                worker.start();
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
    }

    public static void main(String[] args) {
        //String filePath = System.getenv("WORDS_FILE");
        Server server = new Server(7392, "wordsFile.txt");
        server.start();
    }
}
