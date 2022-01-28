﻿// <auto-generated />
using System;
using DesafioFornecedores.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioFornecedores.Infra.Migrations
{
    [DbContext(typeof(ProdForneContext))]
    [Migration("20220128170438_Teste")]
    partial class Teste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Complement")
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Reference")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId")
                        .IsUnique();

                    b.ToTable("TB_Address");
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_Category");
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId")
                        .IsUnique();

                    b.ToTable("TB_Email");
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("TB_Image");
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(9)");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("TB_Phone");
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("BarCode")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<decimal>("PricePurchase")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceSales")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("TB_Product");
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("FantasyName")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FantasyName")
                        .IsUnique();

                    b.ToTable("TB_Supplier");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Supplier");
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.SupplierJuridical", b =>
                {
                    b.HasBaseType("DesafioFornecedores.Domain.Models.Supplier");

                    b.Property<string>("Cnpj")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.HasIndex("Cnpj")
                        .IsUnique()
                        .HasFilter("[Cnpj] IS NOT NULL");

                    b.HasDiscriminator().HasValue("SupplierJuridical");
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.SupplierPhysical", b =>
                {
                    b.HasBaseType("DesafioFornecedores.Domain.Models.Supplier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(256)");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasFilter("[Cpf] IS NOT NULL");

                    b.HasDiscriminator().HasValue("SupplierPhysical");
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Address", b =>
                {
                    b.HasOne("DesafioFornecedores.Domain.Models.Supplier", null)
                        .WithOne("Address")
                        .HasForeignKey("DesafioFornecedores.Domain.Models.Address", "SupplierId")
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Email", b =>
                {
                    b.HasOne("DesafioFornecedores.Domain.Models.Supplier", null)
                        .WithOne("Email")
                        .HasForeignKey("DesafioFornecedores.Domain.Models.Email", "SupplierId")
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Image", b =>
                {
                    b.HasOne("DesafioFornecedores.Domain.Models.Product", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Phone", b =>
                {
                    b.HasOne("DesafioFornecedores.Domain.Models.Supplier", null)
                        .WithMany("Phones")
                        .HasForeignKey("SupplierId")
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioFornecedores.Domain.Models.Product", b =>
                {
                    b.HasOne("DesafioFornecedores.Domain.Models.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
