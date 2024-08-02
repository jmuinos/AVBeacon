using AvBeacon.Domain.Common;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Users.Recruiters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
{
    public void Configure(EntityTypeBuilder<JobOffer> builder)
    {
        builder.HasKey(jo => jo.Id);

        // Relación uno a muchos con Recruiter
        builder.HasOne<Recruiter>()
               .WithMany()
               .HasForeignKey(jo => jo.RecruiterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(jo => jo.Title, titleBuilder =>
        {
            titleBuilder.WithOwner();

            titleBuilder.Property(title => title.Value)
                        .HasColumnName(nameof(JobOffer.Title))
                        .HasMaxLength(Title.MaxLength)
                        .IsRequired();
        });

        builder.OwnsOne(jo => jo.Description, descriptionBuilder =>
        {
            descriptionBuilder.WithOwner();

            descriptionBuilder.Property(description => description.Value)
                              .HasColumnName(nameof(JobOffer.Description))
                              .HasMaxLength(Title.MaxLength)
                              .IsRequired();
        });

        builder.Property(jo => jo.DateTimeUtc).IsRequired();

        builder.Property(jo => jo.CreatedOnUtc).IsRequired();

        builder.Property(jo => jo.ModifiedOnUtc);

        builder.Property(jo => jo.DeletedOnUtc);

        builder.Property(jo => jo.Deleted).HasDefaultValue(false);

        builder.HasQueryFilter(jo => !jo.Deleted);
    }
}