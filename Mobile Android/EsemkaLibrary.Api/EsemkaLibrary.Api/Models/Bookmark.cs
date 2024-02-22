using System;
using System.Collections.Generic;

namespace EsemkaLibrary.Api.Models;

public partial class Bookmark
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? BookId { get; set; }

    public DateTime? BookmarkDate { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
