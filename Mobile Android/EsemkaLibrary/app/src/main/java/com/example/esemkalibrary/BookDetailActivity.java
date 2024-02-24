package com.example.esemkalibrary;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.Toast;

import com.bumptech.glide.Glide;
import com.example.esemkalibrary.databinding.ActivityBookDetailBinding;

import org.json.JSONObject;

public class BookDetailActivity extends AppCompatActivity {


    public static JSONObject selectedBook = new JSONObject();
    private ActivityBookDetailBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityBookDetailBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        try {

            binding.textViewTitle.setText(selectedBook.getString("title"));
            binding.textViewAuthor.setText("Author: " + selectedBook.getString("author"));
            binding.textViewISBN.setText("ISBN: " + selectedBook.getString("isbn"));
            binding.tvCategory.setText("Category: " + selectedBook.getString("category"));
            binding.textViewPublicationYear.setText("Publication Year: " + selectedBook.getString("publicationYear"));
            binding.tvLikes.setText("Likes: " + selectedBook.getString("likes"));
            binding.textViewISBN.setText("ISBN: " + selectedBook.getString("isbn"));
            binding.textViewContents.setText(selectedBook.getString("content"));
            String img = Helper.BASE_URL_IMAGE + selectedBook.getString("cover");
            Glide.with(this).load(img).into(binding.bookImage);
        } catch (Exception ex) {
            Toast.makeText(this, ex.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }
}