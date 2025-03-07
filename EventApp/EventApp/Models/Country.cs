using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string CountryEngName { get; set; } = null!;

    public string TextCode { get; set; } = null!;

    public int NumberCode { get; set; }

    public virtual ICollection<Jurytable> Jurytables { get; set; } = new List<Jurytable>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();

    public virtual ICollection<Organizer> Organizers { get; set; } = new List<Organizer>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
