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

public class MyBookmarkFragment extends Fragment {

    private RecyclerView recyclerView;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment

        View view = inflater.inflate(R.layout.fragment_my_bookmark, container, false);


        recyclerView = view.findViewById(R.id.recyclerView);

        Helper httpHelper2 = new Helper();
        httpHelper2.setHttpCallback(new Helper.HttpCallback() {
            @Override
            public void onSuccess(String result) {
                try {
                    SsAdapter adapter = new SsAdapter(new JSONArray(result));
                    recyclerView.setAdapter(adapter);
                    recyclerView.setLayoutManager(new LinearLayoutManager(getContext()));
                } catch (JSONException e) {
                }
            }

            @Override
            public void onError(String error) {
                // Handle error
            }
        });

        httpHelper2.execute("my-bookmarks", "GET", "");

        return  view;
    }
}