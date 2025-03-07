using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EventApp.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<ActionJury> ActionJuries { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Jurytable> Jurytables { get; set; }

    public virtual DbSet<Moderator> Moderators { get; set; }

    public virtual DbSet<Organizer> Organizers { get; set; }

    public virtual DbSet<Orientation> Orientations { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Winner> Winners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres; Username=postgres;Password=111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("actions_pkey");

            entity.ToTable("actions");

            entity.Property(e => e.ActionId).HasColumnName("action_id");
            entity.Property(e => e.ActionTitle).HasColumnName("action_title");
        });

        modelBuilder.Entity<ActionJury>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("action_jury");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.Jury1Id).HasColumnName("jury1_id");
            entity.Property(e => e.Jury2Id).HasColumnName("jury2_id");
            entity.Property(e => e.Jury3Id).HasColumnName("jury3_id");
            entity.Property(e => e.Jury4Id).HasColumnName("jury4_id");
            entity.Property(e => e.Jury5Id).HasColumnName("jury5_id");

            entity.HasOne(d => d.Jury1).WithMany()
                .HasForeignKey(d => d.Jury1Id)
                .HasConstraintName("action_jury_jury1_id_fkey");

            entity.HasOne(d => d.Jury2).WithMany()
                .HasForeignKey(d => d.Jury2Id)
                .HasConstraintName("action_jury_jury2_id_fkey");

            entity.HasOne(d => d.Jury3).WithMany()
                .HasForeignKey(d => d.Jury3Id)
                .HasConstraintName("action_jury_jury3_id_fkey");

            entity.HasOne(d => d.Jury4).WithMany()
                .HasForeignKey(d => d.Jury4Id)
                .HasConstraintName("action_jury_jury4_id_fkey");

            entity.HasOne(d => d.Jury5).WithMany()
                .HasForeignKey(d => d.Jury5Id)
                .HasConstraintName("action_jury_jury5_id_fkey");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("activity_pkey");

            entity.ToTable("activity");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.ActivityTitle)
                .HasMaxLength(100)
                .HasColumnName("activity_title");
            entity.Property(e => e.Days).HasColumnName("days");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.ModeratorId).HasColumnName("moderator_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.HasOne(d => d.Event).WithMany(p => p.Activities)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("activity_event_id_fkey");

            entity.HasOne(d => d.Moderator).WithMany(p => p.Activities)
                .HasForeignKey(d => d.ModeratorId)
                .HasConstraintName("activity_moderator_id_fkey");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("cities_pkey");

            entity.ToTable("cities");

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CityImage)
                .HasMaxLength(15)
                .HasColumnName("city_image");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .HasColumnName("city_name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("countries_pkey");

            entity.ToTable("countries");

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CountryEngName)
                .HasMaxLength(100)
                .HasColumnName("country_eng_name");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .HasColumnName("country_name");
            entity.Property(e => e.NumberCode).HasColumnName("number_code");
            entity.Property(e => e.TextCode)
                .HasMaxLength(15)
                .HasColumnName("text_code");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("event_pkey");

            entity.ToTable("event");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Days).HasColumnName("days");
            entity.Property(e => e.EventTitle)
                .HasMaxLength(200)
                .HasColumnName("event_title");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.City).WithMany(p => p.Events)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("event_city_id_fkey");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("gender_pkey");

            entity.ToTable("gender");

            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.GenderName)
                .HasMaxLength(10)
                .HasColumnName("gender_name");
        });

        modelBuilder.Entity<Jurytable>(entity =>
        {
            entity.HasKey(e => e.JuryId).HasName("jurytable_pkey");

            entity.ToTable("jurytable");

            entity.Property(e => e.JuryId).HasColumnName("jury_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.OrientationId).HasColumnName("orientation_id");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .HasColumnName("phone_number");
            entity.Property(e => e.Photo)
                .HasMaxLength(25)
                .HasColumnName("photo");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");

            entity.HasOne(d => d.Country).WithMany(p => p.Jurytables)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("jurytable_country_id_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.Jurytables)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("jurytable_gender_id_fkey");

            entity.HasOne(d => d.Orientation).WithMany(p => p.Jurytables)
                .HasForeignKey(d => d.OrientationId)
                .HasConstraintName("jurytable_orientation_id_fkey");
        });

        modelBuilder.Entity<Moderator>(entity =>
        {
            entity.HasKey(e => e.ModeratorId).HasName("moderator_pkey");

            entity.ToTable("moderator");

            entity.Property(e => e.ModeratorId).HasColumnName("moderator_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.OrientationId).HasColumnName("orientation_id");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .HasColumnName("phone_number");
            entity.Property(e => e.Photo)
                .HasMaxLength(25)
                .HasColumnName("photo");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");

            entity.HasOne(d => d.Country).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("moderator_country_id_fkey");

            entity.HasOne(d => d.Event).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("moderator_event_id_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("moderator_gender_id_fkey");

            entity.HasOne(d => d.Orientation).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.OrientationId)
                .HasConstraintName("moderator_orientation_id_fkey");
        });

        modelBuilder.Entity<Organizer>(entity =>
        {
            entity.HasKey(e => e.OrganizerId).HasName("organizers_pkey");

            entity.ToTable("organizers");

            entity.Property(e => e.OrganizerId).HasColumnName("organizer_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .HasColumnName("phone_number");
            entity.Property(e => e.Photo)
                .HasMaxLength(20)
                .HasColumnName("photo");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");

            entity.HasOne(d => d.Country).WithMany(p => p.Organizers)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("organizers_country_id_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.Organizers)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("organizers_gender_id_fkey");
        });

        modelBuilder.Entity<Orientation>(entity =>
        {
            entity.HasKey(e => e.OrientationId).HasName("orientations_pkey");

            entity.ToTable("orientations");

            entity.Property(e => e.OrientationId).HasColumnName("orientation_id");
            entity.Property(e => e.OrientationTitle)
                .HasMaxLength(100)
                .HasColumnName("orientation_title");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("participants_pkey");

            entity.ToTable("participants");

            entity.Property(e => e.ParticipantId).HasColumnName("participant_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Image)
                .HasMaxLength(20)
                .HasColumnName("image");
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");

            entity.HasOne(d => d.Country).WithMany(p => p.Participants)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("participants_country_id_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.Participants)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("participants_gender_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Countryid).HasColumnName("countryid");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Photo)
                .HasMaxLength(25)
                .HasColumnName("photo");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");

            entity.HasOne(d => d.Country).WithMany(p => p.Users)
                .HasForeignKey(d => d.Countryid)
                .HasConstraintName("users_countryid_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("users_gender_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("users_role_id_fkey");
        });

        modelBuilder.Entity<Winner>(entity =>
        {
            entity.HasKey(e => e.WinnderId).HasName("winners_pkey");

            entity.ToTable("winners");

            entity.Property(e => e.WinnderId).HasColumnName("winnder_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.ParticipantId).HasColumnName("participant_id");

            entity.HasOne(d => d.Event).WithMany(p => p.Winners)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("winners_event_id_fkey");

            entity.HasOne(d => d.Participant).WithMany(p => p.Winners)
                .HasForeignKey(d => d.ParticipantId)
                .HasConstraintName("winners_participant_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
