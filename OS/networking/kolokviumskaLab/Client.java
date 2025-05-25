package kolokviumskaLab;

import java.io.*;
import java.net.Socket;
import java.util.Scanner;

public class Client extends Thread{

    private String serverName;
    private int serverPort;
    private String filePath;

    public Client(String serverName, int serverPort, String filePath) {
        this.serverName = serverName;
        this.serverPort = serverPort;
        this.filePath = filePath;
    }

    @Override
    public void run() {
        Socket socket = null;
        BufferedReader reader = null;
        BufferedWriter writer = null;
        BufferedReader fileReader = null;

        try {
            socket = new Socket(serverName, serverPort);
            reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            writer = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
            fileReader = new BufferedReader(new FileReader(filePath));

            Scanner scanner = new Scanner(System.in);
            String msg = scanner.nextLine(); //hello:index
            String index = msg.split(":")[1];

            writer.write(msg + "\n"); //isprati hello:index
            writer.flush();

            String line;
            System.out.println(reader.readLine()); //ispecati index:hello

            writer.write(scanner.nextLine() + "\n"); //isprati index:attach:filename.txt (filename.txt == proba.txt)
            writer.flush();

            while ((line = fileReader.readLine()) != null) {
                writer.write(line + "\n"); //prakjaj ja sodrzinata na fajlot
                writer.flush();
            }
            writer.write(index + ":over\n"); //prati za kraj
            writer.flush();

            System.out.println(reader.readLine()); //Sodrzinata na fajlot e uspeshno primena
            System.out.println(reader.readLine()); //index:fileSize:broj



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
            if (fileReader != null) {
                try {
                    fileReader.close();
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
        //trebit namesto localhost "194.149.135.49" i porta 9753
        Client client = new Client("localhost", 9754, "proba.txt");
        client.start();
    }
}
