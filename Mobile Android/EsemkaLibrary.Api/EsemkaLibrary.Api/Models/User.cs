using System;
using System.Collections.Generic;

namespace EsemkaLibrary.Api.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Signature { get; set; }

    public DateTime JoinDate { get; set; }

    public virtual ICollection<BookLike> BookLikes { get; set; } = new List<BookLike>();

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();
}
