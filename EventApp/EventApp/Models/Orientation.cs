using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class Orientation
{
    public int OrientationId { get; set; }

    public string OrientationTitle { get; set; } = null!;

    public virtual ICollection<Jurytable> Jurytables { get; set; } = new List<Jurytable>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
