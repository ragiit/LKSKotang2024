package com.example.esemkalibrary;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

import com.example.esemkalibrary.databinding.ActivityLoginBinding;

import org.json.JSONException;
import org.json.JSONObject;

public class LoginActivity extends AppCompatActivity {

    private ActivityLoginBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityLoginBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        binding.edtUsername.setText("johndoe");
        binding.edtPassword.setText("password1");
    }

    public void clickRegister(View view) {
        startActivity(new Intent(this, RegisterActivity.class));
    }

    public void clickLogin(View view) {
        if (binding.edtUsername.getText().toString().isEmpty() || binding.edtPassword.getText().toString().isEmpty()) {
            Toast.makeText(this, "Please insert Username and Password!", Toast.LENGTH_SHORT).show();
        } else {

            Helper httpHelper = new Helper();
            httpHelper.setHttpCallback(new Helper.HttpCallback() {
                @Override
                public void onSuccess(String result) {
                    try {
                        JSONObject jsonObject = new JSONObject(result);
                        Helper.jwtToken = jsonObject.getString("token");
                    } catch (JSONException e) {

                    }


                    startActivity(new Intent(LoginActivity.this, HomeActivity.class));
                }

                @Override
                public void onError(String error) {
                    Toast.makeText(LoginActivity.this, "Please correct the error and try again", Toast.LENGTH_SHORT).show();
                }
            });

            JSONObject jsonObject = new JSONObject();

            try {
                jsonObject.put("username", binding.edtUsername.getText());
                jsonObject.put("password", binding.edtPassword.getText());
            } catch (JSONException e) {
                e.printStackTrace();
            }

            String jsonData = jsonObject.toString();

            httpHelper.execute("login", "POST", jsonData);
        }
    }
}