using AvBeacon.Domain._Shared;
using AvBeacon.Domain.Users.Recruiters.JobOffers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
{
    public void Configure(EntityTypeBuilder<JobOffer> builder)
    {
        builder.HasKey(jo => jo.Id);

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
                              .HasMaxLength(Description.MaxLength)
                              .IsRequired();
        });

        builder.Property(jo => jo.CreatedOnUtc).IsRequired();
        builder.Property(jo => jo.ModifiedOnUtc);
        builder.Property(jo => jo.DeletedOnUtc);
        builder.Property(jo => jo.Deleted).HasDefaultValue(false);
        builder.HasQueryFilter(jo => !jo.Deleted);
    }
}