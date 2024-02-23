package com.example.esemkalibrary;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Retrofit;

public class HomeFragment extends Fragment {

    private RecyclerView recyclerView;
    private RecyclerView recyclerView2;
    private SsAdapter bookAdapter;
    private SsAdapter bookAdapter2;
    private TextView tvName;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_home, container, false);



        recyclerView = view.findViewById(R.id.recyclerView);
        recyclerView2 = view.findViewById(R.id.recyclerView2);
        tvName = view.findViewById(R.id.tvName);


        Helper httpHelper = new Helper();
        httpHelper.setHttpCallback(new Helper.HttpCallback() {
            @Override
            public void onSuccess(String result) {
                try {
                    JSONObject jsonObject = new JSONObject(result);
                    tvName.setText("Welcome, " + jsonObject.getString("fullName"));
                } catch (JSONException e) {
                }
            }

            @Override
            public void onError(String error) {
                // Handle error
            }
        });

        httpHelper.execute("me", "GET", "");


        Helper httpHelper2 = new Helper();
        httpHelper2.setHttpCallback(new Helper.HttpCallback() {
            @Override
            public void onSuccess(String result) {
                try {
                    SsAdapter adapter = new SsAdapter(new JSONArray(result));
                    recyclerView2.setAdapter(adapter);
                    recyclerView2.setLayoutManager(new LinearLayoutManager(getContext()));
                } catch (JSONException e) {
                }
            }

            @Override
            public void onError(String error) {
                // Handle error
            }
        });

        httpHelper2.execute("books", "GET", "");

        Helper httpHelper3 = new Helper();
        httpHelper3.setHttpCallback(new Helper.HttpCallback() {
            @Override
            public void onSuccess(String result) {
                try {
                    SsAdapter adapter = new SsAdapter(new JSONArray(result));
                    recyclerView.setAdapter(adapter);
                    LinearLayoutManager layoutManager = new LinearLayoutManager(getContext(), LinearLayoutManager.HORIZONTAL, false);
                    recyclerView.setLayoutManager(layoutManager);
                } catch (JSONException e) {
                }
            }

            @Override
            public void onError(String error) {
                // Handle error
            }
        });

        httpHelper3.execute("books-popular", "GET", "");



        return view;
    }
}