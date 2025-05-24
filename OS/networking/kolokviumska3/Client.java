package kolokviumska3;

import java.io.*;
import java.net.Socket;
import java.util.Scanner;

public class Client extends Thread{

    String serverName;
    int serverPort;

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

            String line;
            String msg;

            writer.write("HANDSHAKE\n");
            writer.flush();

            if (!(line = reader.readLine()).contains("Logged in")) {
                socket.close();
            }

            Scanner scanner = new Scanner(System.in);

            while((msg = scanner.nextLine()) != null){

                writer.write(msg + "\n");
                writer.flush();

                System.out.println(reader.readLine()); //ispecati go zborot + IMA/NEMA, ili ak napisit STOP - ispecati go counter-ot

                if (msg.equalsIgnoreCase("STOP")){
                    break;
                }
            }

            line = reader.readLine();
            System.out.println(line); //LOGGED OUT

        } catch (IOException e) {
            throw new RuntimeException(e);
        } finally {
            if (reader != null) {
                try {
                    reader.close();
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
            if (writer != null) {
                try {
                    writer.close();
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
            if (socket != null) {
                try {
                    socket.close();
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
        }
    }

    public static void main(String[] args) {
        Client client = new Client("localhost", 7392);
        client.start();
    }
}
