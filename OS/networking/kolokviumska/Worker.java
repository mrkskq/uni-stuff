package kajStefan;

import java.io.*;
import java.net.Socket;
import java.text.DateFormat;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class Worker extends Thread {
    private Socket socket;
    private String logFilePath;
    private static int counter = 0;
    private static final Lock lock = new ReentrantLock();

    public Worker(Socket socket, String logFilePath) {
        this.socket = socket;
        this.logFilePath = logFilePath;
    }

    public void run() {
        BufferedReader reader = null;
        BufferedWriter writer = null;
        BufferedWriter fileWriter = null;

        lock.lock();
        try {
            reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            writer = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
            fileWriter = new BufferedWriter(new FileWriter(logFilePath, true));

            String line;

            if (!(line = reader.readLine()).equalsIgnoreCase("LOGIN")) {
                return;
            }

            System.out.println("CLIENT:" + line); //Ispecati LOGIN
            counter++;

            writer.write("Logged in " + socket.getInetAddress().getHostAddress() + "\n");
            writer.write("Total messages: " + counter + "\n");
            writer.flush();

            while (!(line = reader.readLine()).isEmpty()) {
                System.out.println("CLIENT: " + line); //gi citat porakite od klientot i gi pecatit
                writer.write("SERVER: " + line + "\n"); //mu gi vrakjat porakite na klientot
                writer.flush();

                fileWriter.write("Poraka: " + line + "\nVreme na pristiganje: " + LocalDateTime.now() + "\nIP adresa na klient: " + socket.getInetAddress() + "\n\n");
                fileWriter.flush();
            }

            if ((line = reader.readLine()).equalsIgnoreCase("LOGOUT")) {
                System.out.println("CLIENT: " + line); //ispecati LOGOUT
                writer.write("SERVER: Vkupen broj na isprateni poraki do sega: " + counter + "\n");
                writer.write("SERVER: LOGGED OUT\n");
                writer.flush();
            }

        } catch (IOException e) {
            throw new RuntimeException(e);

        } finally {
            lock.unlock();

            if (fileWriter != null) {
                try {
                    fileWriter.close();
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
