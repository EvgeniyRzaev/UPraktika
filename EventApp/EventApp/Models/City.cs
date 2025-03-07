using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public string CityImage { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
