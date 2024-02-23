package com.example.esemkalibrary;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.esemkalibrary.databinding.ListBooksBinding;

import org.json.JSONObject;

public class SsAdapter extends RecyclerView.Adapter<SsAdapter.VH> {

//    private final JSONArray jsonArray;
//
//
//    public RecipeAdapter(JSONArray jsonArray) {
//        this.jsonArray = jsonArray;
//    }

    public SsAdapter() {

    }


    @NonNull
    @Override
    public SsAdapter.VH onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        return new VH(
                ListBooksBinding.inflate(LayoutInflater.from(parent.getContext()), parent, false)
        );
    }

    @Override
    public void onBindViewHolder(@NonNull SsAdapter.VH holder, int position) {

    }

    @Override
    public int getItemCount() {
        return 50;
    }

    public class VH extends RecyclerView.ViewHolder {
        private ListBooksBinding binding;
        private Context context;

        public VH(ListBooksBinding binding) {
            super(binding.getRoot());
            this.binding = binding;
            this.context = binding.getRoot().getContext();
        }
    }
}