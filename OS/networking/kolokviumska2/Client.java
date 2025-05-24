package kolokviumska2;

import java.io.*;
import java.net.Socket;
import java.util.Scanner;

public class Client extends Thread{

    private String serverName;
    private int serverPort;

    public Client(String serverName, int serverPort) {
        this.serverName = serverName;
        this.serverPort = serverPort;
    }

    @Override
    public void run() {
        BufferedReader reader = null;
        BufferedWriter writer = null;
        Socket socket = null;

        try {
            socket = new Socket(serverName, serverPort);
            reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            writer = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));

            writer.write("HANDSHAKE\n");
            writer.flush();

            String line = reader.readLine();
            if (!line.equals("Logged in " + socket.getLocalAddress())){
                socket.close();
            }

            Scanner scanner = new Scanner(System.in);

            while (true){
                String msg = scanner.nextLine();
                writer.write(msg + "\n");
                writer.flush();
                if (msg.equals("STOP")){
                    break;
                }
            }

            System.out.println(reader.readLine()); //zbirot

        } catch (IOException e) {
            throw new RuntimeException(e);
        } finally {
            if (reader != null){
                try {
                    reader.close();
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
            if (writer != null){
                try {
                    writer.close();
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
            if (socket != null){
                try {
                    socket.close();
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
        }
    }

    public static void main(String[] args) {
        Client client = new Client("localhost", 7319);
        client.start();
    }
}
