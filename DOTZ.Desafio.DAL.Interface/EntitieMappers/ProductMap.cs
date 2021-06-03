using DOTZ.Desafio.DAL.Interface.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DOTZ.Desafio.DAL.Interface.EntitieMappers
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.PointsValue)
                     .HasConversion(prop => prop, prop => prop)
                     .IsRequired()
                     .HasColumnName("PointsValue")
                     .HasColumnType("int");

            builder.Property(prop => prop.Description)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar(50)");

        }
    }
}
