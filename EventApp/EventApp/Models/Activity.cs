using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class Activity
{
    public int ActivityId { get; set; }

    public string ActivityTitle { get; set; } = null!;

    public int? EventId { get; set; }

    public int Days { get; set; }

    public TimeOnly StartTime { get; set; }

    public int? ModeratorId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Moderator? Moderator { get; set; }
}
