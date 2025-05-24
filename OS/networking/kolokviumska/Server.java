package kajStefan;


import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Server extends Thread{
    private int port;
    private String filePath;

    public Server(int port, String filePath) {
        this.port = port;
        this.filePath = filePath;
    }

    public void run() {
        System.out.println("Server starting...");
        ServerSocket serverSocket = null;

        try {
            serverSocket = new ServerSocket(this.port);
            System.out.println("SERVER: started!");
            System.out.println("SERVER: waiting for connections...");

            while(true){
                Socket clientSocket = null;

                try {
                    clientSocket = serverSocket.accept();
                    System.out.println("SERVER: new clientSocket!");
                    new Worker(clientSocket, filePath).start();

                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public static void main(String[] args) {
        //String filePath = System.getenv("LOG_FILE"); -----> i namesto log.txt ke pishime filePath dolu

        Server server = new Server(7301, "log.txt");
        server.start();
    }
}

