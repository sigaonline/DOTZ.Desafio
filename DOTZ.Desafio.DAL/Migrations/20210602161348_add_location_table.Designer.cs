// <auto-generated />
using DOTZ.Desafio.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DOTZ.Desafio.DAL.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20210602161348_add_location_table")]
    partial class add_location_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("DOTZ.Desafio.DAL.Interface.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("City");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Complement");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("District");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasColumnName("Number");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(9)")
                        .HasColumnName("PostalCode");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("State");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Street");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("DOTZ.Desafio.DAL.Interface.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Password");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("Role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
