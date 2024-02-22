using System;
using System.Collections.Generic;

namespace EsemkaLibrary.Api.Models;

public partial class BookCategory
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
