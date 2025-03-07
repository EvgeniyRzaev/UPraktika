using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string? EventTitle { get; set; }

    public DateOnly StartDate { get; set; }

    public int Days { get; set; }

    public int? CityId { get; set; }

    public string? Photo { get; set; }
    public Bitmap Image => Converter.LoadImage(Photo, "C:\\Users\\kkrok\\OneDrive\\Desktop\\EventApp\\Assets\\Мероприятия_import\\");

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual City? City { get; set; }

    public virtual ICollection<Winner> Winners { get; set; } = new List<Winner>();
}
