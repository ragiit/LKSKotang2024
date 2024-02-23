package com.example.esemkalibrary;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

public class MyBookmarkFragment extends Fragment {

    private RecyclerView recyclerView;
    private SsAdapter bookAdapter;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment

        View view = inflater.inflate(R.layout.fragment_my_bookmark, container, false);

        bookAdapter = new SsAdapter();

        LinearLayoutManager layoutManager = new LinearLayoutManager(getContext());

        recyclerView = view.findViewById(R.id.recyclerView);

        recyclerView.setLayoutManager(layoutManager);

        recyclerView.setAdapter(bookAdapter);

        return  view;
    }
}