package com.xquipster.messagerserver;

import com.sun.istack.internal.NotNull;
import com.xquipster.messagerserver.api.ClientRequest;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.net.Socket;
import java.util.Map;
import java.util.function.Function;

public class ConnectionCallback {
    private final Socket socket;
    private boolean running = false;
    private DataInputStream in;
    private DataOutputStream out;
    public ConnectionCallback(@NotNull Socket socket){
        this.socket = socket;
    }
    private ConnectionCallback(){
        this.socket = null;
    }

    public void start(Function<String, String> reactionFunction){
        if (socket != null){
            try {
                in = new DataInputStream(socket.getInputStream());
                out = new DataOutputStream(socket.getOutputStream());
                running = true;
                while (running){
                    try {
                        String str = in.readUTF();
                        String reaction = reactionFunction.apply(str);
                        if(reaction != null) out.writeUTF(reaction);
                    }catch (Exception ignored){
                    }
                }
                in.close();
                out.close();
                socket.close();
            }catch (Exception e){
                e.printStackTrace();
            }
        }
    }

    public void sendToClient(String id, Map.Entry<String, String>... entries) {
        if (socket != null && socket.isConnected()){
            StringBuilder s = new StringBuilder(id + "!~|\n\r+-\n");
            for (Map.Entry<String, String> e : entries){
                s.append(e.getKey()).append("=").append(e.getValue());
            }
            try {
                out.writeUTF(s.toString());
            }catch (Exception ignored){}
        }
    }

    public void setRunning(boolean running) {
        this.running = running;
    }
}
