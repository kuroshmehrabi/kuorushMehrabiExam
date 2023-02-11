﻿using System;
using System.Collections.Generic;

namespace Library.Data;

public class Libraryy
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public short LibraryNumber { get; set; }

    public int CityId { get; set; }

    public virtual ICollection<Book> Books { get; } = new List<Book>();
    public City City { get; set; }
}
