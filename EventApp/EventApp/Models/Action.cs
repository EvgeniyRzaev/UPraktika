using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class Action
{
    public int ActionId { get; set; }

    public string ActionTitle { get; set; } = null!;

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
