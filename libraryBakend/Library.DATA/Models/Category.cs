using System;
using System.Collections.Generic;

namespace Library.Data;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
