using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class Jurytable
{
    public int JuryId { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int? GenderId { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public int? CountryId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int? OrientationId { get; set; }

    public string Password { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public virtual Country? Country { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual Orientation? Orientation { get; set; }
}
