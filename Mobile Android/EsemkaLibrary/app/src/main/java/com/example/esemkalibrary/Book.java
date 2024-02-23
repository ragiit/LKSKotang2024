package com.example.esemkalibrary;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class Book {
    private int id;
    private String title;
    private String author;
    @SerializedName("publicationYear")
    private int publicationYear;
    private String isbn;
    private String cover;
    @SerializedName("bookContents")
    private List<BookContent> bookContents;

    // Buatlah constructor, getter, dan setter sesuai kebutuhan Anda


    public Book(int id, String title, String author, int publicationYear, String isbn, String cover, List<BookContent> bookContents) {
        this.id = id;
        this.title = title;
        this.author = author;
        this.publicationYear = publicationYear;
        this.isbn = isbn;
        this.cover = cover;
        this.bookContents = bookContents;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public int getPublicationYear() {
        return publicationYear;
    }

    public void setPublicationYear(int publicationYear) {
        this.publicationYear = publicationYear;
    }

    public String getIsbn() {
        return isbn;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    public String getCover() {
        return cover;
    }

    public void setCover(String cover) {
        this.cover = cover;
    }

    public List<BookContent> getBookContents() {
        return bookContents;
    }

    public void setBookContents(List<BookContent> bookContents) {
        this.bookContents = bookContents;
    }
}
