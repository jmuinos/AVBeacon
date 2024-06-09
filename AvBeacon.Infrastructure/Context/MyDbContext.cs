using AvBeacon.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext() { }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options) { }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<JobApplication> JobApplications { get; set; }

    public virtual DbSet<JobOffer> JobOffers { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder
           .UseSqlServer("Server=J-LAPTOP;Database=AvBeaconDb;User Id=sa;Password=Qwerty123.;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasIndex(e => e.ApplicantId, "IX_Educations_ApplicantId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.Applicant).WithMany(p => p.Educations).HasForeignKey(d => d.ApplicantId);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasIndex(e => e.ApplicantId, "IX_Experiences_ApplicantId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.RecruiterName).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Applicant).WithMany(p => p.Experiences).HasForeignKey(d => d.ApplicantId);
        });

        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.HasIndex(e => e.ApplicantId, "IX_JobApplications_ApplicantId");

            entity.HasIndex(e => e.JobOfferId, "IX_JobApplications_JobOfferId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Applicant).WithMany(p => p.JobApplications).HasForeignKey(d => d.ApplicantId);

            entity.HasOne(d => d.JobOffer).WithMany(p => p.JobApplications)
                  .HasForeignKey(d => d.JobOfferId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<JobOffer>(entity =>
        {
            entity.HasIndex(e => e.RecruiterId, "IX_JobOffers_RecruiterId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Recruiter).WithMany(p => p.JobOffers).HasForeignKey(d => d.RecruiterId);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.UserType).HasMaxLength(13);

            entity.HasMany(d => d.Skills).WithMany(p => p.Applicants)
                  .UsingEntity<Dictionary<string, object>>(
                                                           "ApplicantSkill",
                                                           r => r.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
                                                           l => l.HasOne<User>().WithMany()
                                                                 .HasForeignKey("ApplicantId"),
                                                           j =>
                                                           {
                                                               j.HasKey("ApplicantId", "SkillId");
                                                               j.ToTable("ApplicantSkill");
                                                               j.HasIndex(new[] { "ApplicantId", "SkillId" },
                                                                          "IX_ApplicantSkill_ApplicantId_SkillId")
                                                                .IsUnique();
                                                               j.HasIndex(new[] { "SkillId" },
                                                                          "IX_ApplicantSkill_SkillId");
                                                           });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}