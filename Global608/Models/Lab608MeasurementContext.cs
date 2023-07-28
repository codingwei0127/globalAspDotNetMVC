using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Global608.Models;

public partial class Lab608MeasurementContext : DbContext
{
    public Lab608MeasurementContext()
    {
    }

    public Lab608MeasurementContext(DbContextOptions<Lab608MeasurementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Global> Globals { get; set; }

    public virtual DbSet<Global07Ch1avg> Global07Ch1avgs { get; set; }

    public virtual DbSet<Global08Ch2avg> Global08Ch2avgs { get; set; }

    public virtual DbSet<Global10> Global10s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Global>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Global");

            entity.Property(e => e.Ch1Chwflow).HasColumnName("CH1_CHWFlow");
            entity.Property(e => e.Ch1Chwtin).HasColumnName("CH1_CHWTin");
            entity.Property(e => e.Ch1Chwtout).HasColumnName("CH1_CHWTout");
            entity.Property(e => e.Ch1Cwflow).HasColumnName("CH1_CWFlow");
            entity.Property(e => e.Ch1Cwtin).HasColumnName("CH1_CWTin");
            entity.Property(e => e.Ch1Cwtout).HasColumnName("CH1_CWTout");
            entity.Property(e => e.Ch1Dbt).HasColumnName("CH1_DBT");
            entity.Property(e => e.Ch1Kw).HasColumnName("CH1_Kw");
            entity.Property(e => e.Ch1Rh).HasColumnName("CH1_RH");
            entity.Property(e => e.Ch2Chwflow).HasColumnName("CH2_CHWFlow");
            entity.Property(e => e.Ch2Chwtin).HasColumnName("CH2_CHWTin");
            entity.Property(e => e.Ch2Chwtout).HasColumnName("CH2_CHWTout");
            entity.Property(e => e.Ch2Cwtin).HasColumnName("CH2_CWTin");
            entity.Property(e => e.Ch2Cwtout).HasColumnName("CH2_CWTout");
            entity.Property(e => e.Ch2Kw).HasColumnName("CH2_Kw");
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<Global07Ch1avg>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_07_CH1Avg");

            entity.Property(e => e.Ch1Kw).HasColumnName("CH1_Kw");
            entity.Property(e => e.Ch1kWperRt).HasColumnName("CH1kWPerRT");
            entity.Property(e => e.Ch1rt).HasColumnName("CH1RT");
            entity.Property(e => e.Time).HasMaxLength(4000);
        });

        modelBuilder.Entity<Global08Ch2avg>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_08_CH2Avg");

            entity.Property(e => e.Ch2Kw).HasColumnName("CH2_Kw");
            entity.Property(e => e.Ch2kWperRt).HasColumnName("CH2kWPerRT");
            entity.Property(e => e.Ch2rt).HasColumnName("CH2RT");
            entity.Property(e => e.Time).HasMaxLength(4000);
        });

        modelBuilder.Entity<Global10>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_10");

            entity.Property(e => e.Expr1).HasColumnType("datetime");
            entity.Property(e => e.TotalKwrt).HasColumnName("TotalKWRT");
            entity.Property(e => e.TotalRt).HasColumnName("TotalRT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
