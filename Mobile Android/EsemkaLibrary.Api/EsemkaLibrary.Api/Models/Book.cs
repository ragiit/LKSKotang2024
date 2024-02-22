using System;
using System.Collections.Generic;

namespace EsemkaLibrary.Api.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public int? PublicationYear { get; set; }

    public string? Isbn { get; set; }

    public string? Cover { get; set; }

    public virtual ICollection<BookContent> BookContents { get; set; } = new List<BookContent>();

    public virtual ICollection<BookLike> BookLikes { get; set; } = new List<BookLike>();

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual ICollection<BookCategory> Categories { get; set; } = new List<BookCategory>();
}
