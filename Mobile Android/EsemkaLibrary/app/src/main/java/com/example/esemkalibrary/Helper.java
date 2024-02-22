package com.example.esemkalibrary;

import android.os.AsyncTask;
import android.util.Log;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;

public class Helper extends AsyncTask<String, Void, String> {

    private  static  String BASE_URL = "http://10.0.2.2:5008/api/";
    public static  String jwtToken = "";
    private static final String TAG = "HttpHelper";
    private HttpCallback callback;

    public interface HttpCallback {
        void onSuccess(String result);
        void onError(String error);
    }

    public void setHttpCallback(HttpCallback callback) {
        this.callback = callback;
    }

    @Override
    protected String doInBackground(String... params) {
        String urlString = BASE_URL +  params[0];
        String method = params[1];
        String data = params[2];
        String result = "";

        try {
            URL url = new URL(urlString);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod(method);
            connection.setRequestProperty("Content-Type", "application/json");


            // Set JWT token in the request header
            if (jwtToken != null && !jwtToken.isEmpty()) {
                connection.setRequestProperty("Authorization", "Bearer " + jwtToken);
            }


            if (method.equals("POST")) {
                connection.setDoOutput(true);
                OutputStream outputStream = connection.getOutputStream();
                outputStream.write(data.getBytes());
                outputStream.flush();
                outputStream.close();
            }

            int responseCode = connection.getResponseCode();
            if (responseCode == HttpURLConnection.HTTP_OK) {
                BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(connection.getInputStream()));
                String line;
                while ((line = bufferedReader.readLine()) != null) {
                    result += line;
                }
                bufferedReader.close();
            } else {
                result = "Error: " + responseCode;
            }

            connection.disconnect();
        } catch (IOException e) {
            Log.e(TAG, "Error", e);
            result = e.getMessage();
        }

        return result;
    }

    @Override
    protected void onPostExecute(String result) {
        if (result.startsWith("Error")) {
            callback.onError(result);
        } else {
            callback.onSuccess(result);
        }
    }
}