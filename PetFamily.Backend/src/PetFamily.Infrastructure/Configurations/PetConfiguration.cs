using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Entities;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Infrastructure.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pets");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                   .HasConversion(
                   id => id.Value,
                   value => PetId.Create(value));

            builder.ComplexProperty(p => p.Nickname, pb =>
            {
                pb.Property(pr => pr.Value)
                  .IsRequired()
                  .HasMaxLength(Nickname.MAX_LENGTH)
                  .HasColumnName("nickname");
            });

            builder.ComplexProperty(p => p.Description, pb =>
            {
                pb.Property(pr => pr.Value)
                    .IsRequired()
                    .HasMaxLength(Description.MAX_LENGTH)
                    .HasColumnName("description");
            });

            builder.ComplexProperty(p => p.Color, pb =>
            {
                pb.Property(pr => pr.Value)
                    .IsRequired()
                    .HasMaxLength(Color.MAX_LENGTH)
                    .HasColumnName("color");
            });

            builder.ComplexProperty(p => p.InfoAboutHealthPet, pb =>
            {
                pb.Property(pr => pr.Value)
                    .IsRequired()
                    .HasMaxLength(InfoAboutHealthPet.MAX_LENGTH)
                    .HasColumnName("info_about_health_pet");
            });

            builder.ComplexProperty(p => p.AddressLocatePet, pb =>
            {
                pb.Property(pr => pr.Value)
                  .IsRequired()
                  .HasMaxLength(AddressLocatePet.MAX_LENGTH)
                  .HasColumnName("address_locate_pet");
            });

            builder.ComplexProperty(p => p.Weight, pb =>
            {
                pb.Property(pr => pr.Value)
                  .IsRequired()
                  .HasColumnName("weight");
            });

            builder.ComplexProperty(p => p.Height, pb =>
            {
                pb.Property(pr => pr.Value)
                  .IsRequired()
                  .HasColumnName("height");
            });

            builder.ComplexProperty(p => p.PhoneNumber, pb =>
            {
                pb.Property(pr => pr.Value)
                  .IsRequired()
                  .HasMaxLength(PhoneNumber.MAX_LENGTH)
                  .HasColumnName("phone_number");
            });

            builder.Property(v => v.IsCostrate)
                   .IsRequired();

            builder.Property(v => v.DateOfBirth)
                   .IsRequired();

            builder.Property(v => v.IsVaccinated)
                   .IsRequired();

            builder.Property(v => v.StatusHelp)
                   .HasConversion(
                   sh => (int)sh,
                   value => (EStatusHelp)value);

            builder.OwnsOne(v => v.PetDetalis, pd =>
            {
                pd.ToJson();

                pd.OwnsMany(d => d.BankDetalis, bd =>
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

            builder.Property(v => v.DateCreate)
                   .IsRequired();

            builder.ComplexProperty(p => p.SpeciesAndBreed, pb =>
            {
                pb.IsRequired();

                pb.Property(n => n.SpecieId)
                  .HasConversion(
                    id => id.Value,
                    value => SpeciesId.Create(value))
                  .HasColumnName("species_id");

                pb.Property(n => n.BreedId)
                   .HasConversion(
                    id => id.Value,
                    value => BreedId.Create(value))
                   .HasColumnName("breed_id");
            });
        }
    }
}
