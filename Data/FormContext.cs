using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HIPS_FS.Models;

#nullable disable

namespace HIPS_FS.Data
{
    public partial class FormContext : DbContext
    {
        public FormContext()
        {
        }

        public FormContext(DbContextOptions<FormContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryName> CategoryNames { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<FamilyName> FamilyNames { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormDescription> FormDescriptions { get; set; }
        public virtual DbSet<FormGroup> FormGroups { get; set; }
        public virtual DbSet<FormMovement> FormMovements { get; set; }
        public virtual DbSet<FormName> FormNames { get; set; }
        public virtual DbSet<Movement> Movements { get; set; }
        public virtual DbSet<MovementCategory> MovementCategories { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<SeriesName> SeriesNames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "form");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryName>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.NameId })
                    .HasName("PK_categoryname");

                entity.ToTable("CategoryName", "form");

                entity.HasIndex(e => e.CategoryId, "fkIdx_365");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryNames)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryName");
            });

            modelBuilder.Entity<Description>(entity =>
            {
                entity.ToTable("Description", "form");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(3000);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("Family", "form");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<FamilyName>(entity =>
            {
                entity.HasKey(e => new { e.FamilyId, e.NameId })
                    .HasName("PK_familyname");

                entity.ToTable("FamilyName", "form");

                entity.HasIndex(e => e.FamilyId, "fkIdx_337");

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.FamilyNames)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FamilyName_Family");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable("Form", "form");

                entity.HasIndex(e => e.FamilyId, "fkIdx_320");

                entity.HasIndex(e => e.SeriesId, "fkIdx_323");

                entity.HasIndex(e => e.SourceFormId, "fkIdx_438");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.Forms)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Form_Family");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.Forms)
                    .HasForeignKey(d => d.SeriesId)
                    .HasConstraintName("FK_Form_Series");

                entity.HasOne(d => d.SourceForm)
                    .WithMany(p => p.InverseSourceForm)
                    .HasForeignKey(d => d.SourceFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Form_SourceForm");
            });

            modelBuilder.Entity<FormDescription>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.DescriptionId })
                    .HasName("PK_formdescription");

                entity.ToTable("FormDescription", "form");

                entity.HasIndex(e => e.DescriptionId, "fkIdx_390");

                entity.HasIndex(e => e.FormId, "fkIdx_393");

                entity.HasOne(d => d.Description)
                    .WithMany(p => p.FormDescriptions)
                    .HasForeignKey(d => d.DescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormDescription_Description");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormDescriptions)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormDescription_Form");
            });

            modelBuilder.Entity<FormGroup>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.GroupId })
                    .HasName("PK_formstyle");

                entity.ToTable("FormGroup", "form");

                entity.HasIndex(e => e.FormId, "fkIdx_300");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormGroups)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormGroup_Form");
            });

            modelBuilder.Entity<FormMovement>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.MovementId })
                    .HasName("PK_formmovement");

                entity.ToTable("FormMovement", "form");

                entity.HasIndex(e => e.FormId, "fkIdx_374");

                entity.HasIndex(e => e.MovementId, "fkIdx_377");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormMovements)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormMovement_Form");

                entity.HasOne(d => d.Movement)
                    .WithMany(p => p.FormMovements)
                    .HasForeignKey(d => d.MovementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormMovement_Movement");
            });

            modelBuilder.Entity<FormName>(entity =>
            {
                entity.HasKey(e => new { e.NameId, e.FormId })
                    .HasName("PK_formname");

                entity.ToTable("FormName", "form");

                entity.HasIndex(e => e.FormId, "fkIdx_277");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormNames)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormName_Form");
            });

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.ToTable("Movement", "form");

                entity.Property(e => e.FootTechniqueId).HasColumnName("FootTechniqueID");
            });

            modelBuilder.Entity<MovementCategory>(entity =>
            {
                entity.HasKey(e => new { e.MovementId, e.CategoryId })
                    .HasName("PK_movementcategory");

                entity.ToTable("MovementCategory", "form");

                entity.HasIndex(e => e.MovementId, "fkIdx_352");

                entity.HasIndex(e => e.CategoryId, "fkIdx_362");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.MovementCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovementCategory_Category");

                entity.HasOne(d => d.Movement)
                    .WithMany(p => p.MovementCategories)
                    .HasForeignKey(d => d.MovementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovementCategory_Movement");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.ToTable("Series", "form");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SeriesName>(entity =>
            {
                entity.HasKey(e => new { e.SeriesId, e.NameId })
                    .HasName("PK_seriesname");

                entity.ToTable("SeriesName", "form");

                entity.HasIndex(e => e.SeriesId, "fkIdx_334");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.SeriesNames)
                    .HasForeignKey(d => d.SeriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeriesName_Series");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
