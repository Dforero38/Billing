using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Billing.Domain.Entity
{
    public partial class BillingContext : DbContext
    {
        public BillingContext()
        {
        }

        public BillingContext(DbContextOptions<BillingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<MovementBill> MovementBills { get; set; }
        public virtual DbSet<MovementProduct> MovementProducts { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Residue> Residues { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<TypeCustomer> TypeCustomers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdTypeCustomerNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IdTypeCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__IdType__2A4B4B5E");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("Mark");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovementBill>(entity =>
            {
                entity.ToTable("MovementBill");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Iva).HasColumnType("money");

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.MovementBills)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovementB__IdCus__300424B4");

                entity.HasOne(d => d.IdTransactionTypeNavigation)
                    .WithMany(p => p.MovementBills)
                    .HasForeignKey(d => d.IdTransactionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovementB__IdTra__30F848ED");
            });

            modelBuilder.Entity<MovementProduct>(entity =>
            {
                entity.ToTable("MovementProduct");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.TotalValue).HasColumnType("money");

                entity.Property(e => e.UnitValue).HasColumnType("money");

                entity.HasOne(d => d.IdMovementBillNavigation)
                    .WithMany(p => p.MovementProducts)
                    .HasForeignKey(d => d.IdMovementBill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovementP__IdMov__398D8EEE");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.MovementProducts)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovementP__IdPro__3A81B327");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("money");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__IdCusto__2D27B809");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.IdMarkNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdMark)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__IdMark__33D4B598");
            });

            modelBuilder.Entity<Residue>(entity =>
            {
                entity.ToTable("Residue");

                entity.Property(e => e.Stok).HasColumnType("money");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Residues)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Residue__IdProdu__36B12243");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionType");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeCustomer>(entity =>
            {
                entity.ToTable("TypeCustomer");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
