using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace EventApp.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public int? Countryid { get; set; }

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Photo { get; set; } = null!;
    public Bitmap Image => Converter.LoadImage(Photo, "C:\\Users\\kkrok\\OneDrive\\Desktop\\EventApp\\Assets\\Модераторы_import\\");
    public int? GenderId { get; set; }

    public int? RoleId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual Role? Role { get; set; }
}
