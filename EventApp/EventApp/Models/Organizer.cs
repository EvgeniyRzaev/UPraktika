using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class Organizer
{
    public int OrganizerId { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public int? CountryId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Password { get; set; }

    public string Photo { get; set; } = null!;

    public int? GenderId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Gender? Gender { get; set; }
}
