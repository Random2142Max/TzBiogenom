using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models.Data;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Currentdailyconsumption> Currentdailyconsumptions { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodsNutrient> FoodsNutrients { get; set; }

    public virtual DbSet<Newconsumption> Newconsumptions { get; set; }

    public virtual DbSet<Nutrient> Nutrients { get; set; }

    public virtual DbSet<NutrientsSupplement> NutrientsSupplements { get; set; }

    public virtual DbSet<Physicalactivitylevel> Physicalactivitylevels { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Setnutrient> Setnutrients { get; set; }

    public virtual DbSet<Supplement> Supplements { get; set; }

    public virtual DbSet<SupplementsReview> SupplementsReviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Biogenom;Username=postgres;Password=qwerty");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("assessments_pkey");

            entity.HasOne(d => d.IdUsersNavigation).WithMany(p => p.Assessments).HasConstraintName("fk_assessments_users");
        });

        modelBuilder.Entity<Currentdailyconsumption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("currentdailyconsumptions_pkey");

            entity.HasOne(d => d.IdAssessmentsNavigation).WithMany(p => p.Currentdailyconsumptions).HasConstraintName("fk_currentdailyconsumptions_assessments");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("foods_pkey");
        });

        modelBuilder.Entity<FoodsNutrient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("foods_nutrients_pkey");

            entity.HasOne(d => d.IdFoodsNavigation).WithMany(p => p.FoodsNutrients).HasConstraintName("fk_foods_nutrients_foods");

            entity.HasOne(d => d.IdNutrientsNavigation).WithMany(p => p.FoodsNutrients).HasConstraintName("fk_foods_nutrients_nutrients");
        });

        modelBuilder.Entity<Newconsumption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("newconsumptions_pkey");

            entity.HasOne(d => d.IdCurrentdailyconsumptionsNavigation).WithMany(p => p.Newconsumptions).HasConstraintName("fk_newconsumptions_currentdailyconsumptions");

            entity.HasOne(d => d.IdNutrientsSupplementsNavigation).WithMany(p => p.Newconsumptions).HasConstraintName("fk_newconsumptions_nutrients_supplements");
        });

        modelBuilder.Entity<Nutrient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("nutrients_pkey");
        });

        modelBuilder.Entity<NutrientsSupplement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("nutrients_supplements_pkey");

            entity.HasOne(d => d.IdNutrientsNavigation).WithMany(p => p.NutrientsSupplements).HasConstraintName("fk_nutrients_supplements_nutrients");

            entity.HasOne(d => d.IdSupplementsNavigation).WithMany(p => p.NutrientsSupplements).HasConstraintName("fk_nutrients_supplements_supplements");
        });

        modelBuilder.Entity<Physicalactivitylevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("physicalactivitylevels_pkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reviews_pkey");

            entity.HasOne(d => d.IdUsersNavigation).WithMany(p => p.Reviews).HasConstraintName("fk_reviews_users");
        });

        modelBuilder.Entity<Setnutrient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("setnutrients_pkey");

            entity.HasOne(d => d.IdFoodsNutrientsNavigation).WithMany(p => p.Setnutrients).HasConstraintName("fk_setnutrients_foods_nutrients");

            entity.HasOne(d => d.IdPhysicalactivitylevelsNavigation).WithMany(p => p.Setnutrients).HasConstraintName("fk_setnutrients_physicalactivitylevels");
        });

        modelBuilder.Entity<Supplement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supplements_pkey");
        });

        modelBuilder.Entity<SupplementsReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supplements_reviews_pkey");

            entity.HasOne(d => d.IdReviewsNavigation).WithMany(p => p.SupplementsReviews).HasConstraintName("fk_supplements_reviews_reviews");

            entity.HasOne(d => d.IdSupplementsNavigation).WithMany(p => p.SupplementsReviews).HasConstraintName("fk_supplements_reviews_supplements");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
