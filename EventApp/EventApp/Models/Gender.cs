using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class Gender
{
    public int GenderId { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<Jurytable> Jurytables { get; set; } = new List<Jurytable>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();

    public virtual ICollection<Organizer> Organizers { get; set; } = new List<Organizer>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
