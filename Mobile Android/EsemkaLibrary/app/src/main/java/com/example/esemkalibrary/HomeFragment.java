package com.example.esemkalibrary;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Retrofit;

public class HomeFragment extends Fragment {

    private RecyclerView recyclerView;
    private RecyclerView recyclerView2;
    private SsAdapter bookAdapter;
    private SsAdapter bookAdapter2;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view  = inflater.inflate(R.layout.fragment_home, container, false);

        bookAdapter = new SsAdapter();
        bookAdapter2 = new SsAdapter();

        LinearLayoutManager layoutManager = new LinearLayoutManager(getContext(), LinearLayoutManager.HORIZONTAL, false);

        recyclerView = view.findViewById(R.id.recyclerView);
        recyclerView2 = view.findViewById(R.id.recyclerView2);

        recyclerView.setLayoutManager(layoutManager);
        recyclerView2.setLayoutManager(new LinearLayoutManager(getContext()));

        recyclerView.setAdapter(bookAdapter);
        recyclerView2.setAdapter(bookAdapter2);

        return  view;
    }
}