package com.xquipster.messagerserver.api;

import java.util.HashMap;

public class ClientRequest {

    private final int id;
    private final HashMap<String, String> body;

    public int getId() {
        return id;
    }

    public HashMap<String, String> getBody() {
        return body;
    }

    public ClientRequest(String request) {
        String[] strings = request.split("!~|\n\r+-\n");
        try {
            this.id = Integer.parseInt(strings[0]);
        }catch (Exception e){
            throw new NullPointerException("Bad request!");
        }
        body = new HashMap<>();
        if (strings.length >= 2){
            for (int i = 1; i < strings.length; i++){
                String[] s = strings[i].split("=");
                if (s.length >= 2){
                    body.put(s[0], strings[i].substring(s[0].length()));
                }
            }
        }
    }
}
