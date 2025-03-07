using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class ActionJury
{
    public int? ActivityId { get; set; }

    public int? Jury1Id { get; set; }

    public int? Jury2Id { get; set; }

    public int? Jury3Id { get; set; }

    public int? Jury4Id { get; set; }

    public int? Jury5Id { get; set; }

    public virtual Jurytable? Jury1 { get; set; }

    public virtual Jurytable? Jury2 { get; set; }

    public virtual Jurytable? Jury3 { get; set; }

    public virtual Jurytable? Jury4 { get; set; }

    public virtual Jurytable? Jury5 { get; set; }
}
