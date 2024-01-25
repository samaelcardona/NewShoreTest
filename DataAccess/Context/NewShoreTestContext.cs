using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NewShoreTest.Models.DataAccessModels;

namespace NewShoreTest.DataAccess.Context;

public partial class NewShoreTestContext : DbContext
{
    public NewShoreTestContext()
    {
    }

    public NewShoreTestContext(DbContextOptions<NewShoreTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Journey> Journeys { get; set; }

    public virtual DbSet<JourneyFlight> JourneyFlights { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:NewShoreTest");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Flight__8A9E148E45914C99");

            entity.ToTable("Flight");

            entity.HasIndex(e => new { e.Origin, e.Destination }, "UQ_Flight_Flight").IsUnique();

            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.Destination).HasMaxLength(50);
            entity.Property(e => e.Origin).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TransportId).HasColumnName("TransportID");
        });

        modelBuilder.Entity<Journey>(entity =>
        {
            entity.HasKey(e => e.JourneyId).HasName("PK__Journey__4159B9CF65929B6A");

            entity.ToTable("Journey");

            entity.HasIndex(e => new { e.Origin, e.Destination }, "UQ_Journey_Flight").IsUnique();

            entity.Property(e => e.JourneyId).HasColumnName("JourneyID");
            entity.Property(e => e.Destination).HasMaxLength(50);
            entity.Property(e => e.Origin).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<JourneyFlight>(entity =>
        {
            entity.HasKey(e => e.JourneyFlightId).HasName("PK__JourneyF__1B8C28AF1C37D8F7");

            entity.ToTable("JourneyFlight");

            entity.HasIndex(e => new { e.JourneyId, e.FlightId }, "UQ_JourneyFlight_Flight").IsUnique();

            entity.Property(e => e.JourneyFlightId).HasColumnName("JourneyFlightID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.JourneyId).HasColumnName("JourneyID");

            entity.HasOne(d => d.Flight).WithMany(p => p.JourneyFlights)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JourneyFlight_FlightID");

            entity.HasOne(d => d.Journey).WithMany(p => p.JourneyFlights)
                .HasForeignKey(d => d.JourneyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JourneyFlight_JourneyID");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.TransportId).HasName("PK__Transpor__19E9A17D60BB1658");

            entity.ToTable("Transport");

            entity.Property(e => e.TransportId).HasColumnName("TransportID");
            entity.Property(e => e.FlightCarrier).HasMaxLength(50);
            entity.Property(e => e.FlightNumber).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
