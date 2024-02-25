using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EsemkaLibrary.Api.Models;

public partial class EsemkaLibraryContext : DbContext
{
    public EsemkaLibraryContext()
    {
    }

    public EsemkaLibraryContext(DbContextOptions<EsemkaLibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<BookContent> BookContents { get; set; }

    public virtual DbSet<BookLike> BookLikes { get; set; }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseInMemoryDatabase("Example");


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //=> optionsBuilder.UseSqlServer("Server=.\\ITSSB;Database=EsemkaLibrary;Trusted_Connection=True;TrustServerCertificate=True");
    //=> optionsBuilder.UseSqlServer("Server=.\\ITSSB;Database=EsemkaLibrary;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC2781244C67");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cover)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.Categories).WithMany(p => p.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookDetail",
                    r => r.HasOne<BookCategory>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BookDetai__Categ__3C69FB99"),
                    l => l.HasOne<Book>().WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BookDetai__BookI__3B75D760"),
                    j =>
                    {
                        j.HasKey("BookId", "CategoryId").HasName("PK_BookDetail");
                        j.ToTable("BookDetails");
                        j.IndexerProperty<int>("BookId").HasColumnName("BookID");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("CategoryID");
                    });
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookCate__3214EC275A6A38BE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BookContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookCont__3214EC27E64C791F");

            entity.ToTable("BookContent");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.Content).IsUnicode(false);

            entity.HasOne(d => d.Book).WithMany(p => p.BookContents)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__BookConte__BookI__3F466844");
        });

        modelBuilder.Entity<BookLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookLike__3214EC27F5A6F711");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Book).WithMany(p => p.BookLikes)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__BookLikes__BookI__49C3F6B7");

            entity.HasOne(d => d.User).WithMany(p => p.BookLikes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__BookLikes__UserI__48CFD27E");
        });

        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookmark__3214EC2701675AF7");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Book).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__Bookmarks__BookI__45F365D3");

            entity.HasOne(d => d.User).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bookmarks__UserI__44FF419A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC2716DDEDAC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FullName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.JoinDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Motto)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}