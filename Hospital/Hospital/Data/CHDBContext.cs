using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Hospital.Models;

namespace Hospital.Data
{
    public partial class CHDBContext : DbContext
    {
        public CHDBContext()
        {
        }

        public CHDBContext(DbContextOptions<CHDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admissions> Admissions { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Encounters> Encounters { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Medications> Medications { get; set; }
        public virtual DbSet<NursingUnits> NursingUnits { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Physicians> Physicians { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        public virtual DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public virtual DbSet<UnitDoseOrders> UnitDoseOrders { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=CHDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admissions>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.AdmissionDate })
                    .HasName("pk_admissions");

                entity.Property(e => e.NursingUnitId).IsUnicode(false);

                entity.Property(e => e.PrimaryDiagnosis).IsUnicode(false);

                entity.Property(e => e.SecondaryDiagnoses).IsUnicode(false);

                entity.HasOne(d => d.AttendingPhysician)
                    .WithMany(p => p.Admissions)
                    .HasForeignKey(d => d.AttendingPhysicianId)
                    .HasConstraintName("FK__admission__atten__4BAC3F29");

                entity.HasOne(d => d.NursingUnit)
                    .WithMany(p => p.Admissions)
                    .HasForeignKey(d => d.NursingUnitId)
                    .HasConstraintName("FK__admission__nursi__4CA06362");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Admissions)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__admission__patie__4AB81AF0");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__departme__C2232422BBD314D7");

                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.DepartmentName).IsUnicode(false);

                entity.Property(e => e.ManagerFirstName).IsUnicode(false);

                entity.Property(e => e.ManagerLastName).IsUnicode(false);
            });

            modelBuilder.Entity<Encounters>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.PhysicianId, e.EncounterDateTime })
                    .HasName("pk_encounters");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Encounters)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__encounter__patie__4F7CD00D");

                entity.HasOne(d => d.Physician)
                    .WithMany(p => p.Encounters)
                    .HasForeignKey(d => d.PhysicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__encounter__physi__5070F446");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__items__52020FDD2BDAB040");

                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.ItemDescription).IsUnicode(false);

                entity.HasOne(d => d.PrimaryVendor)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.PrimaryVendorId)
                    .HasConstraintName("FK__items__primary_v__534D60F1");
            });

            modelBuilder.Entity<Medications>(entity =>
            {
                entity.HasKey(e => e.MedicationId)
                    .HasName("PK__medicati__DD94789B4240412E");

                entity.Property(e => e.MedicationId).ValueGeneratedNever();

                entity.Property(e => e.MedicationDescription).IsUnicode(false);

                entity.Property(e => e.PackageSize).IsUnicode(false);

                entity.Property(e => e.Sig).IsUnicode(false);

                entity.Property(e => e.Strength).IsUnicode(false);
            });

            modelBuilder.Entity<NursingUnits>(entity =>
            {
                entity.HasKey(e => e.NursingUnitId)
                    .HasName("PK__nursing___0E85E2CC49DB6C96");

                entity.Property(e => e.NursingUnitId).IsUnicode(false);

                entity.Property(e => e.ManagerFirstName).IsUnicode(false);

                entity.Property(e => e.ManagerLastName).IsUnicode(false);

                entity.Property(e => e.Specialty).IsUnicode(false);
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__patients__4D5CE476F1D196C8");

                entity.Property(e => e.PatientId).ValueGeneratedNever();

                entity.Property(e => e.Allergies).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StreetAddress).IsUnicode(false);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK__patients__provin__4316F928");
            });

            modelBuilder.Entity<Physicians>(entity =>
            {
                entity.HasKey(e => e.PhysicianId)
                    .HasName("PK__physicia__8C035A3CD7F4D81B");

                entity.Property(e => e.PhysicianId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Specialty).IsUnicode(false);
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.HasKey(e => e.ProvinceId)
                    .HasName("PK__province__08DCB60F6C33EFE4");

                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProvinceName).IsUnicode(false);
            });

            modelBuilder.Entity<PurchaseOrderLines>(entity =>
            {
                entity.HasKey(e => new { e.PurchaseOrderId, e.LineNum })
                    .HasName("pk_purchase_order_lines");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__purchase___item___5EBF139D");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchase___purch__5DCAEF64");
            });

            modelBuilder.Entity<PurchaseOrders>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderId)
                    .HasName("PK__purchase__AFCA88E6DD613339");

                entity.Property(e => e.PurchaseOrderId).ValueGeneratedNever();

                entity.Property(e => e.OrderStatus).IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__purchase___depar__5629CD9C");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK__purchase___vendo__571DF1D5");
            });

            modelBuilder.Entity<UnitDoseOrders>(entity =>
            {
                entity.HasKey(e => e.UnitDoseOrderId)
                    .HasName("PK__unit_dos__BB64A31A3178A9C8");

                entity.Property(e => e.UnitDoseOrderId).ValueGeneratedNever();

                entity.Property(e => e.Dosage).IsUnicode(false);

                entity.Property(e => e.DosageRoute).IsUnicode(false);

                entity.Property(e => e.PharmacistInitials)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sig).IsUnicode(false);

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.UnitDoseOrders)
                    .HasForeignKey(d => d.MedicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__unit_dose__medic__5AEE82B9");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.UnitDoseOrders)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__unit_dose__patie__59FA5E80");
            });

            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.HasKey(e => e.VendorId)
                    .HasName("PK__vendors__0F7D2B785A4CF3AD");

                entity.Property(e => e.VendorId).ValueGeneratedNever();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.ContactFirstName).IsUnicode(false);

                entity.Property(e => e.ContactLastName).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StreetAddress).IsUnicode(false);

                entity.Property(e => e.VendorName).IsUnicode(false);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Vendors)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK__vendors__provinc__47DBAE45");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
