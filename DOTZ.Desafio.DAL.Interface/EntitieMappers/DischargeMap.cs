using DOTZ.Desafio.DAL.Interface.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DOTZ.Desafio.DAL.Interface.EntitieMappers
{
    public class DischargeMap : IEntityTypeConfiguration<Discharge>
    {
        public void Configure(EntityTypeBuilder<Discharge> builder)
        {
            builder.ToTable("Discharge");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.UserId)
                     .HasConversion(prop => prop, prop => prop)
                     .IsRequired()
                     .HasColumnName("PointsValue")
                     .HasColumnType("int");

            builder.Property(prop => prop.ProductId)
                     .HasConversion(prop => prop, prop => prop)
                     .IsRequired()
                     .HasColumnName("ProductId")
                     .HasColumnType("int");

            builder.Property(prop => prop.UserId)
                     .HasConversion(prop => prop, prop => prop)
                     .IsRequired()
                     .HasColumnName("PointsValue")
                     .HasColumnType("int");

        }
    }
}
