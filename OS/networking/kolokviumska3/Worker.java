package kolokviumska3;

import java.io.*;
import java.net.Socket;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class Worker extends Thread{

    Socket socket;
    String filePath;
    static HashMap<String, Integer> words = new HashMap<>();
    static int counter = 0; //broj na poznati zborovi, broj na unikatni zborovi
    static Lock lock = new ReentrantLock();

    public Worker(Socket socket, String filePath) {
        this.socket = socket;
        this.filePath = filePath;
    }

    @Override
    public void run() {
        BufferedReader reader = null;
        BufferedWriter writer = null;
        BufferedWriter fileWriter = null;

        try {
            reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            writer = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
            fileWriter = new BufferedWriter(new FileWriter(filePath, true));

            String line;

            if(!(line = reader.readLine()).equals("HANDSHAKE")) {
                socket.close();
            }

            writer.write("Logged in " + socket.getRemoteSocketAddress() + "\n");
            writer.flush();

            while(!(line = reader.readLine()).equalsIgnoreCase("STOP")) {

                //IMA
                if (words.containsKey(line)) {
                    words.put(line, words.get(line) + 1);
                  
                    writer.write(line + " IMA\n");
                    writer.flush();
                }

                //NEMA
                else {
                    lock.lock();
                    counter++;
                    lock.unlock();
                  
                    words.put(line, 1);
                    writer.write(line + " NEMA\n");
                    writer.flush();
                  
                    fileWriter.write(line + " " + LocalDateTime.now() + " " + socket.getRemoteSocketAddress() + "\n");
                    fileWriter.flush();
                }
            }

            writer.write(counter + "\n");
            writer.flush();

            writer.write("LOGGED OUT\n");
            writer.flush();

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
            if (fileWriter != null) {
                try {
                    fileWriter.close();
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
