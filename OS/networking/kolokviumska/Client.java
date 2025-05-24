package kajStefan;

import java.io.*;
import java.net.InetAddress;
import java.net.Socket;

public class Client extends Thread {
    private String hostname;
    private int serverPort;

    public Client(String hostname, int serverPort) {
        this.hostname = hostname;
        this.serverPort = serverPort;
    }

    @Override
    public void run() {
        Socket socket = null;
        BufferedReader reader = null;
        BufferedWriter writer = null;

        try {
            socket = new Socket(InetAddress.getByName(this.hostname), this.serverPort);
            reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            writer = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));

            writer.write("LOGIN\n");
            writer.flush();

            String line = reader.readLine();
            System.out.println(line); //pecati Logged in...

            line = reader.readLine();
            System.out.println(line); //Pecati Total messages: ...

            //prakjaj mu poraki na serverot
            writer.write("Pozdrav od Stefan\n");
            writer.write("Da vidime nesto andrej od 4ti test vestacka nabrzinka voved nesto i da\n");
            writer.write("\n");
            writer.flush();

            writer.write("LOGOUT\n");
            writer.flush();

            while ((line = reader.readLine()) != null) {
                System.out.println(line); //pecati gi echo porakite od serverot sho gi vrakjat
            }

        } catch (IOException e) {
            throw new RuntimeException(e);

        } finally {
            if (writer != null) {
                try {
                    writer.close();
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
            if (reader != null) {
                try {
                    reader.close();
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
        Client client = new Client("localhost", 7301);
        client.start();
    }
}
