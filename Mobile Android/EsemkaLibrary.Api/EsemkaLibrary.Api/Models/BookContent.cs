using System;
using System.Collections.Generic;

namespace EsemkaLibrary.Api.Models;

public partial class BookContent
{
    public int Id { get; set; }

    public int? BookId { get; set; }

    public string? Content { get; set; }

    public virtual Book? Book { get; set; }
}
