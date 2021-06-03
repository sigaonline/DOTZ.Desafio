using DOTZ.Desafio.DAL.Interface.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DOTZ.Desafio.DAL.Interface.EntitieMappers
{
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.UserId)
                     .HasConversion(prop => prop, prop => prop)
                     .IsRequired()
                     .HasColumnName("UserId")
                     .HasColumnType("int");

            builder.Property(prop => prop.PostalCode)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("PostalCode")
                .HasColumnType("varchar(9)");

            builder.Property(prop => prop.Street)
               .HasConversion(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("Street")
               .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Number)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Number")
                .HasColumnType("varchar(5)");

            builder.Property(prop => prop.Complement)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Complement")
                .HasColumnType("varchar(100)");
            
            builder.Property(prop => prop.District)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("District")
                .HasColumnType("varchar(50)");

            builder.Property(prop => prop.State)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("State")
                .HasColumnType("varchar(50)");

            builder.Property(prop => prop.City)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("varchar(50)");

            builder.Property(prop => prop.Phone)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Phone")
                .HasColumnType("varchar(50)");

        }
    }
}
