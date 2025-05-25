package kolokviumskaLab;

import java.io.*;
import java.net.Socket;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class Worker extends Thread {

    private Socket socket;
    private static int fileSize = 0;
    private static Lock lock = new ReentrantLock();

    public Worker(Socket socket) {
        this.socket = socket;
    }

    @Override
    public void run() {
        BufferedReader reader = null;
        BufferedWriter writer = null;
        String index;
        String filePath;

        try {
            reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            writer = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));

            String line;

            line = reader.readLine(); //procitaj hello:index
            index = line.split(":")[1]; //zemi go indeksot

            if (!line.equalsIgnoreCase("hello:" + index)){
                socket.close();
            }

            writer.write(index + ":hello\n");
            writer.flush();

            line = reader.readLine(); //procitaj index:attach:filename.txt
            filePath = line.split(":")[2]; //zemi go filePath

            if (!line.equalsIgnoreCase(index + ":attach:" + filePath)){
                socket.close();
            }

            while (!(line = reader.readLine()).equalsIgnoreCase(index + ":over")){
                System.out.println(line);
            }

            writer.write("Sodrzinata na fajlot e uspeshno primena\n");
            writer.flush();

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
            if (socket != null) {
                try {
                    socket.close();
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
        }
    }
}
