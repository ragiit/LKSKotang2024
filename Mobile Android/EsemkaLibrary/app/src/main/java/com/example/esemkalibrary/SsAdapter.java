package com.example.esemkalibrary;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.example.esemkalibrary.databinding.ListBooksBinding;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class SsAdapter extends RecyclerView.Adapter<SsAdapter.VH> {

//    private final JSONArray jsonArray;
//
//
//    public RecipeAdapter(JSONArray jsonArray) {
//        this.jsonArray = jsonArray;
//    }

    private final JSONArray jsonArray;

    public SsAdapter(JSONArray jsonArray) {
        this.jsonArray = jsonArray;
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
        try {
            JSONObject jsonObject = jsonArray.getJSONObject(position);
            holder.binding.bookTitle.setText(jsonObject.getString("title"));
            holder.binding.bookIsbn.setText("ISBN: " + jsonObject.getString("isbn"));
            holder.binding.bookCategory.setText("Category: " + jsonObject.getString("category"));
            holder.binding.bookLikes.setText("Likes: " + jsonObject.getString("likes"));
            String img = Helper.BASE_URL_IMAGE +   jsonObject.getString("cover");
            Glide.with(holder.context).load(img).into(holder.binding.bookImage);

            holder.itemView.setOnClickListener(v -> {
                BookDetailActivity.selectedBook = jsonObject;
                holder.context.startActivity(new Intent(holder.context, BookDetailActivity.class));
            });



        } catch (JSONException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public int getItemCount() {
        return jsonArray.length();
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