package kolokviumska2;

import java.io.*;
import java.net.Socket;
import java.time.LocalDateTime;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class Worker extends Thread{

    private Socket socket;
    private String filePath;
    private static Lock lock = new ReentrantLock();

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

            String line = reader.readLine();
            if (!line.equals("HANDSHAKE")){
                socket.close();
            }

            writer.write("Logged in " + socket.getInetAddress() + "\n");
            writer.flush();

            String msg;
            int total = 0;

            while ((msg = reader.readLine()) != null) {
                if (msg.equals("STOP")){
                    break;
                }

                int number = Integer.parseInt(msg);
                total += number;

                fileWriter.write(number + " " + LocalDateTime.now()  + " " + socket.getInetAddress() +  "\n");
                fileWriter.flush();
            }

            lock.lock();
            SharedResource.count = SharedResource.count + total;
            lock.unlock();

            writer.write(SharedResource.count + "\n");
            writer.write("LOGGED OUT");
            writer.flush();

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
            if (fileWriter != null){
                try {
                    fileWriter.close();
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

    private static class SharedResource {
        private static int count;
    }
}
