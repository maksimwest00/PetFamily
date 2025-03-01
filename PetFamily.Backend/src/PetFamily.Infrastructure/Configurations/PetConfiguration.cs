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

            builder.Property(v => v.Nickname)
                   .IsRequired()
                   .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

 

            builder.Property(v => v.Description)
                   .IsRequired()
                   .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

            //builder.HasOne(v => v.Breed);

            builder.Property(v => v.Color)
                   .IsRequired()
                   .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.Property(v => v.InfoAboutHealthPet)
                   .IsRequired()
                   .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

            builder.Property(v => v.AddressLocatePet)
                   .IsRequired()
                   .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.Property(v => v.Weight)
                   .IsRequired();

            builder.Property(v => v.Height)
                   .IsRequired();

            builder.Property(v => v.NumberPhone)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

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

            //builder.Property(v => v.SpecieId)
            //       .HasConversion(
            //       id => id.Value,
            //       value => SpecieId.Create(value));

            //builder.Property(v => v.BreedId)
            //       .HasConversion(
            //       id => id.Value,
            //       value => BreedId.Create(value));

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
