using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Appointment.DataAccessLayer.EFModels;

public partial class AppointmentBookingDbContext : DbContext
{
    public AppointmentBookingDbContext()
    {
    }

    public AppointmentBookingDbContext(DbContextOptions<AppointmentBookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC299319FF3");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PatientEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PatientName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PatientPhone)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Docto__3F466844");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctor__2DC00EBFFC878D44");

            entity.ToTable("Doctor");

            entity.HasIndex(e => e.UserId, "UQ__Doctor__1788CC4D401D7E80").IsUnique();

            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Doctor__UserId__3B75D760");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C671796C9");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D1053411CC3512").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
