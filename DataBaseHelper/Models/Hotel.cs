using System;
using System.Collections.Generic;

namespace DataBaseHelper.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string? HotelName { get; set; }

    public string? LocationName { get; set; }

    public int? StarsCount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
