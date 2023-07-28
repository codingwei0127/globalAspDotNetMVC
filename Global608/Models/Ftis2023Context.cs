using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Global608.Models;

public partial class Ftis2023Context : DbContext
{
    public Ftis2023Context()
    {
    }

    public Ftis2023Context(DbContextOptions<Ftis2023Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Global03AvgHourPower> Global03AvgHourPowers { get; set; }

    public virtual DbSet<Global06Ch1KWrtHour> Global06Ch1KWrtHours { get; set; }

    public virtual DbSet<Global07Ch2KWrtHour> Global07Ch2KWrtHours { get; set; }

    public virtual DbSet<Global08OpNo3Hour> Global08OpNo3Hours { get; set; }

    public virtual DbSet<Global08TotalkWrtHour> Global08TotalkWrtHours { get; set; }

    public virtual DbSet<Global09Ch1MonthKWrt> Global09Ch1MonthKWrts { get; set; }

    public virtual DbSet<Global10Ch2MonthKWrt> Global10Ch2MonthKWrts { get; set; }

    public virtual DbSet<Global11AllMonthKWrt> Global11AllMonthKWrts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Global03AvgHourPower>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_03_Avg_Hour_Power");

            entity.Property(e => e.Ch1Chwflow).HasColumnName("CH1_CHWFlow");
            entity.Property(e => e.Ch1Chwtin).HasColumnName("CH1_CHWTin");
            entity.Property(e => e.Ch1Chwtout).HasColumnName("CH1_CHWTout");
            entity.Property(e => e.Ch1Cwflow).HasColumnName("CH1_CWFlow");
            entity.Property(e => e.Ch1Cwtin).HasColumnName("CH1_CWTin");
            entity.Property(e => e.Ch1Cwtout).HasColumnName("CH1_CWTout");
            entity.Property(e => e.Ch1Dbt).HasColumnName("CH1_DBT");
            entity.Property(e => e.Ch1Rh).HasColumnName("CH1_RH");
            entity.Property(e => e.Ch2Chwflow).HasColumnName("CH2_CHWFlow");
            entity.Property(e => e.Ch2Chwtin).HasColumnName("CH2_CHWTin");
            entity.Property(e => e.Ch2Chwtout).HasColumnName("CH2_CHWTout");
            entity.Property(e => e.Ch2Cwtin).HasColumnName("CH2_CWTin");
            entity.Property(e => e.Ch2Cwtout).HasColumnName("CH2_CWTout");
            entity.Property(e => e.Rt1).HasColumnName("RT1");
            entity.Property(e => e.Rt2).HasColumnName("RT2");
            entity.Property(e => e.Time).HasColumnType("datetime");
            entity.Property(e => e.TotalRt).HasColumnName("TotalRT");
        });

        modelBuilder.Entity<Global06Ch1KWrtHour>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_06_Ch1_kWRT_hour");

            entity.Property(e => e.Ch1kWrt).HasColumnName("Ch1kWRT");
            entity.Property(e => e.Rt1).HasColumnName("RT1");
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<Global07Ch2KWrtHour>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_07_Ch2_kWRT_hour");

            entity.Property(e => e.Ch2kWrt).HasColumnName("Ch2kWRT");
            entity.Property(e => e.Rt2).HasColumnName("RT2");
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<Global08OpNo3Hour>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_08_OpNo3_hour");

            entity.Property(e => e.Time).HasColumnType("datetime");
            entity.Property(e => e.TotalRt).HasColumnName("TotalRT");
            entity.Property(e => e.TotalkWrt).HasColumnName("TotalkWRT");
        });

        modelBuilder.Entity<Global08TotalkWrtHour>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_08_TotalkWRT_hour");

            entity.Property(e => e.Time).HasColumnType("datetime");
            entity.Property(e => e.TotalRt).HasColumnName("TotalRT");
            entity.Property(e => e.TotalkWrt).HasColumnName("TotalkWRT");
        });

        modelBuilder.Entity<Global09Ch1MonthKWrt>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_09_Ch1_Month_kWRT");

            entity.Property(e => e.Ch1kWrt).HasColumnName("Ch1kWRT");
            entity.Property(e => e.Rt1).HasColumnName("RT1");
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<Global10Ch2MonthKWrt>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_10_Ch2_Month_kWRT");

            entity.Property(e => e.Ch2kWrt).HasColumnName("Ch2kWRT");
            entity.Property(e => e.Rt2).HasColumnName("RT2");
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<Global11AllMonthKWrt>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Global_11_All_Month_kWRT");

            entity.Property(e => e.Time).HasColumnType("datetime");
            entity.Property(e => e.TotalRt).HasColumnName("TotalRT");
            entity.Property(e => e.TotalkWrt).HasColumnName("TotalkWRT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
