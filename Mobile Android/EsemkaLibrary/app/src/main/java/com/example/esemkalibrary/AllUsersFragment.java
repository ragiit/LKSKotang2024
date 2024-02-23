package com.example.esemkalibrary;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import org.json.JSONArray;
import org.json.JSONException;

public class AllUsersFragment extends Fragment {
    private RecyclerView recyclerView;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_all_users, container, false);

        recyclerView  = view.findViewById(R.id.recyclerView);

        Helper httpHelper3 = new Helper();
        httpHelper3.setHttpCallback(new Helper.HttpCallback() {
            @Override
            public void onSuccess(String result) {
                try {
                    Ss2Adapter adapter = new Ss2Adapter(new JSONArray(result));
                    recyclerView.setAdapter(adapter);
                    LinearLayoutManager layoutManager = new LinearLayoutManager(getContext());
                    recyclerView.setLayoutManager(layoutManager);
                } catch (JSONException e) {
                }
            }

            @Override
            public void onError(String error) {
                // Handle error
            }
        });

        httpHelper3.execute("users", "GET", "");

        return  view;
    }
}