using System;
using System.Collections.Generic;

namespace EsemkaLibrary.Api.Models;

public partial class BookLike
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? BookId { get; set; }

    public DateTime? LikeDate { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
