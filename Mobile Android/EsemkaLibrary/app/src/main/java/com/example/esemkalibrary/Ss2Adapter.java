package com.example.esemkalibrary;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.example.esemkalibrary.databinding.ListBooksBinding;
import com.example.esemkalibrary.databinding.ListUsersBinding;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class Ss2Adapter extends RecyclerView.Adapter<Ss2Adapter.VH> {

//    private final JSONArray jsonArray;
//
//
//    public RecipeAdapter(JSONArray jsonArray) {
//        this.jsonArray = jsonArray;
//    }

    private final JSONArray jsonArray;

    public Ss2Adapter(JSONArray jsonArray) {
        this.jsonArray = jsonArray;
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
        try {
            JSONObject jsonObject = jsonArray.getJSONObject(position);
            holder.binding.textViewUsername.setText( "Username: " +jsonObject.getString("username"));
            holder.binding.textViewFullName.setText("Full Name: " + jsonObject.getString("fullName"));
            holder.binding.textViewDateOfBirth.setText("Date of Birth: " + jsonObject.getString("dateOfBirth"));
            holder.binding.tvMotto.setText("Motto: " + jsonObject.getString("motto"));
        } catch (JSONException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public int getItemCount() {
        return jsonArray.length();
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
