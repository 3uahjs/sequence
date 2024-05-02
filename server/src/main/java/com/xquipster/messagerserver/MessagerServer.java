package com.xquipster.messagerserver;

import com.xquipster.messagerserver.api.ClientRequest;

import java.net.ServerSocket;
import java.util.HashMap;
import java.util.function.Function;

public class MessagerServer {
    private final int port;
    private MessagerServer(){
        port = -1;
    }
    private Function<String, String> reactionFunction;
    public MessagerServer(int port){
        this.port = port;
    }
    public void launchServer(){
        registerReactionFunction();
        ConnectionCallback callback = null;
        try {
            ServerSocket server = new ServerSocket(port);
            callback = new ConnectionCallback(server.accept());
        }catch (Exception e){
            e.printStackTrace();
            System.exit(1);
        }
        callback.start(reactionFunction);
    }

    private void registerReactionFunction() {
        reactionFunction = s -> {
            try {
                ClientRequest request = new ClientRequest(s);
                String response = null;
                HashMap<String, String> args = request.getBody();
                if (args.containsKey("loginId")){

                }else if(args.containsKey("loginName") && args.containsKey("loginPassword")){

                }
                return response;
            }catch (Exception e){
                return null;
            }
        };
    }

    public static void main(String[] args) {
        MessagerServer server = new MessagerServer(3000);
        server.launchServer();
    }
}
