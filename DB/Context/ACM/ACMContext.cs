using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ACM.ACM_Models;
using System.Diagnostics;

namespace ACM.Context
{
    public partial class ACMContext : DbContext
    {
        public ACMContext()
        {
            Database.EnsureCreated();
        }

        public ACMContext(string connectionstring) : base()
        {
            Database.EnsureCreated();
        }

        public ACMContext(DbContextOptions<ACMContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<AppState> AppStates { get; set; } = null!;
        public virtual DbSet<CouponDailyAvailability> CouponDailyAvailabilities { get; set; } = null!;
        public virtual DbSet<CouponItem> CouponItems { get; set; } = null!;
        public virtual DbSet<CouponRule> CouponRules { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            if (!optionsBuilder.IsConfigured)
            {
                string? dataPath;
                var registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\ACM Service", true);
                if (registryKey is not null)
                {
                    dataPath = registryKey.GetValue("DbPath") as string;
                    if (dataPath is not null)
                    {
                        optionsBuilder.UseSqlite($"Data Source={dataPath}");
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppState>(entity =>
            {
                entity.ToTable("AppState");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("datetime('now')");
            });

            modelBuilder.Entity<CouponDailyAvailability>(entity =>
            {
                entity.ToTable("CouponDailyAvailability");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar")
                    .HasColumnName("id");

                entity.Property(e => e.CouponRuleId)
                    .HasColumnType("varchar")
                    .HasColumnName("couponRuleId");

                entity.Property(e => e.DayIndex)
                    .HasColumnType("integer")
                    .HasColumnName("dayIndex");

                entity.Property(e => e.EndHour)
                    .HasColumnType("integer")
                    .HasColumnName("endHour");

                entity.Property(e => e.EndMinute)
                    .HasColumnType("integer")
                    .HasColumnName("endMinute");

                entity.Property(e => e.IsActive)
                    .HasColumnType("boolean")
                    .HasColumnName("isActive");

                entity.Property(e => e.StartHour)
                    .HasColumnType("integer")
                    .HasColumnName("startHour");

                entity.Property(e => e.StartMinute)
                    .HasColumnType("integer")
                    .HasColumnName("startMinute");

                entity.HasOne(d => d.CouponRule)
                    .WithMany(p => p.CouponDailyAvailabilities)
                    .HasForeignKey(d => d.CouponRuleId);
            });

            modelBuilder.Entity<CouponItem>(entity =>
            {
                entity.ToTable("CouponItem");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("integer")
                    .HasColumnName("amount");

                entity.Property(e => e.CouponRuleId)
                    .HasColumnType("varchar")
                    .HasColumnName("couponRuleId");

                entity.Property(e => e.IsRequired)
                    .HasColumnType("boolean")
                    .HasColumnName("isRequired")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ItemName)
                    .HasColumnType("varchar")
                    .HasColumnName("itemName");

                entity.Property(e => e.Operation)
                    .HasColumnType("varchar")
                    .HasColumnName("operation");

                entity.HasOne(d => d.CouponRule)
                    .WithMany(p => p.CouponItems)
                    .HasForeignKey(d => d.CouponRuleId);
            });

            modelBuilder.Entity<CouponRule>(entity =>
            {
                entity.ToTable("CouponRule");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar")
                    .HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("nvarchar")
                    .HasColumnName("endDate");

                entity.Property(e => e.IsActive)
                    .HasColumnType("boolean")
                    .HasColumnName("isActive");

                entity.Property(e => e.IsDiscountExclusive)
                    .HasColumnType("boolean")
                    .HasColumnName("isDiscountExclusive");

                entity.Property(e => e.MaxApplications)
                    .HasColumnType("smallint")
                    .HasColumnName("maxApplications")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Name)
                    .HasColumnType("nvarchar")
                    .HasColumnName("name");

                entity.Property(e => e.Notes)
                    .HasColumnType("nvarchar")
                    .HasColumnName("notes");

                entity.Property(e => e.ReceiptName)
                    .HasColumnType("nvarchar")
                    .HasColumnName("receiptName");

                entity.Property(e => e.StartDate)
                    .HasColumnType("nvarchar")
                    .HasColumnName("startDate");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar")
                    .HasColumnName("id");

                entity.Property(e => e.AlteredPrice)
                    .HasColumnType("smallint")
                    .HasColumnName("alteredPrice");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("datetime('now')");

                entity.Property(e => e.FposSaleId)
                    .HasColumnType("nvarchar")
                    .HasColumnName("fposSaleId");

                entity.Property(e => e.FposSaleItemId)
                    .HasColumnType("nvarchar")
                    .HasColumnName("fposSaleItemId");

                entity.Property(e => e.Operation)
                    .HasColumnType("nvarchar")
                    .HasColumnName("operation");

                entity.Property(e => e.OperationAmount)
                    .HasColumnType("smallint")
                    .HasColumnName("operationAmount");

                entity.Property(e => e.OriginalPrice)
                    .HasColumnType("smallint")
                    .HasColumnName("originalPrice");

                entity.Property(e => e.Rule)
                    .HasColumnType("varchar")
                    .HasColumnName("rule");

                entity.Property(e => e.RuleItem)
                    .HasColumnType("varchar")
                    .HasColumnName("ruleItem");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
