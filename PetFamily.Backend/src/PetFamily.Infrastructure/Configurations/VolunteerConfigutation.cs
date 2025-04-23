using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Entities;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configurations
{
    public class VolunteerConfigutation : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("volunteers");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));

            builder.ComplexProperty(v => v.FullName, vb =>
            {
                vb.Property(t => t.Value)
                    .IsRequired()
                    .HasMaxLength(FullName.MAX_LENGTH)
                    .HasColumnName("full_name");
            });

            builder.ComplexProperty(v => v.Email, vb =>
            {
                vb.Property(t => t.Value)
                    .IsRequired()
                    .HasMaxLength(Email.MAX_LENGTH)
                    .HasColumnName("email");
            });

            builder.ComplexProperty(v => v.Description, vb =>
            {
                vb.Property(t => t.Value)
                    .IsRequired()
                    .HasMaxLength(Description.MAX_LENGTH)
                    .HasColumnName("description");
            });

            builder.ComplexProperty(v => v.ExperienceYear, vb =>
            {
                vb.Property(pr => pr.Value)
                  .IsRequired()
                  .HasColumnName("experience_year");
            });

            builder.ComplexProperty(v => v.PhoneNumber, vb =>
            {
                vb.Property(t => t.Value)
                    .IsRequired()
                    .HasMaxLength(PhoneNumber.MAX_LENGTH)
                    .HasColumnName("phoneNumber");
            });

            builder.OwnsOne(v => v.VolunteerDetalis, vd =>
            {
                vd.ToJson();

                vd.OwnsMany(d => d.SocialNetworks, sb =>
                {
                    sb.Property(s => s.Name)
                        .IsRequired()
                        .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                    sb.Property(s => s.Link)
                        .IsRequired()
                        .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                });

                vd.OwnsMany(d => d.BankDetalis, bd =>
                {
                    bd.Property(bd => bd.Name)
                        .IsRequired()
                        .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

                    bd.Property(bd => bd.Description)
                        .IsRequired()
                        .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

                    bd.Property(bd => bd.HowDoTransfer)
                        .IsRequired()
                        .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                });
            });

            builder.HasMany(v => v.Pets)
                .WithOne()
                .HasForeignKey("volunteer_id");
        }
    }
}
