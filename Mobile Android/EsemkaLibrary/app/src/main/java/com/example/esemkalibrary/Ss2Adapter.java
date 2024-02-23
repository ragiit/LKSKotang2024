package com.example.esemkalibrary;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.esemkalibrary.databinding.ListBooksBinding;
import com.example.esemkalibrary.databinding.ListUsersBinding;

public class Ss2Adapter extends RecyclerView.Adapter<Ss2Adapter.VH> {

//    private final JSONArray jsonArray;
//
//
//    public RecipeAdapter(JSONArray jsonArray) {
//        this.jsonArray = jsonArray;
//    }

    public Ss2Adapter() {

    }


    @NonNull
    @Override
    public Ss2Adapter.VH onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        return new Ss2Adapter.VH(
                ListUsersBinding.inflate(LayoutInflater.from(parent.getContext()), parent, false)
        );
    }

    @Override
    public void onBindViewHolder(@NonNull Ss2Adapter.VH holder, int position) {

    }

    @Override
    public int getItemCount() {
        return 50;
    }

    public class VH extends RecyclerView.ViewHolder {
        private ListUsersBinding binding;
        private Context context;

        public VH(ListUsersBinding binding) {
            super(binding.getRoot());
            this.binding = binding;
            this.context = binding.getRoot().getContext();
        }
    }
}
