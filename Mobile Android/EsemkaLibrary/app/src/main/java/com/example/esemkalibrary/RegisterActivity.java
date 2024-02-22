package com.example.esemkalibrary;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

import com.example.esemkalibrary.databinding.ActivityRegisterBinding;

import org.json.JSONException;
import org.json.JSONObject;

public class RegisterActivity extends AppCompatActivity {

    private ActivityRegisterBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityRegisterBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

    }

    public void clickLoginLabel(View view) {
        finish();

        if (binding.edtUsername.getText().toString().isEmpty() || binding.edtPassword.getText().toString().isEmpty() || binding.edtFullName.getText().toString().isEmpty() || binding.edtSignature.getText().toString().isEmpty() || binding.edtDateOfBirth.getText().toString().isEmpty()) {
            Toast.makeText(this, "Please insert all fields", Toast.LENGTH_SHORT).show();
        } else {
            Helper httpHelper = new Helper();
            httpHelper.setHttpCallback(new Helper.HttpCallback() {
                @Override
                public void onSuccess(String result) {
                    finish();
                }

                @Override
                public void onError(String error) {
                    if (error.contains("409")) {
                        Toast.makeText(RegisterActivity.this, "Username is already in use", Toast.LENGTH_SHORT).show();
                    }
                }
            });

            JSONObject jsonObject = new JSONObject();

            try {
                jsonObject.put("username", binding.edtUsername.getText());
                jsonObject.put("password", binding.edtPassword.getText());
                jsonObject.put("fullName", binding.edtFullName.getText());
                jsonObject.put("signature", binding.edtSignature.getText());
                jsonObject.put("dateOfBirth", binding.edtDateOfBirth.getText());
            } catch (JSONException e) {
                e.printStackTrace();
            }

            String jsonData = jsonObject.toString();

            httpHelper.execute("register", "POST", jsonData);
        }
    }

    public void clickRegister(View view) {
    }
}