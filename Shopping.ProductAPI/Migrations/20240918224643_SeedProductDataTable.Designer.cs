﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopping.ProductAPI.Model.Context;

#nullable disable

namespace Shopping.ProductAPI.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20240918224643_SeedProductDataTable")]
    partial class SeedProductDataTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Shopping.ProductAPI.Model.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 3L,
                            CategoryName = "Camisa Social",
                            Description = "Camisa masculina social confeccionada em tecido 100% algodão. Colarinho estruturado e manga comprida acabada em punho com botão. Fecho à frente com botões. Modelagem slim. Logo D bordado na altura do peito.",
                            ImageUrl = "https://github.com/vitorhaga/Shopping/blob/master/Shopping.Images/camisa_social_rosa.jpg?raw=true",
                            Name = "Camisa Social Slim Masculina Manga Comprida Rosa Claro",
                            Price = 70m
                        },
                        new
                        {
                            Id = 4L,
                            CategoryName = "Camisa Social",
                            Description = "Camisa masculina social slim. Colarinho francês e manga comprida acabada em punho com botão. Fecho à frente com botões. Modelagem slim. Logo D bordado na altura do peito.",
                            ImageUrl = "https://github.com/vitorhaga/Shopping/blob/master/Shopping.Images/camisa_social_marrom_xadrez.jpg?raw=true",
                            Name = "Camisa Slim Masculina Manga Comprida Marrom Xadrez",
                            Price = 223.3m
                        },
                        new
                        {
                            Id = 5L,
                            CategoryName = "Blazer",
                            Description = "Blazer feminino alongado e acinturado. Gola com lapela e manga comprida. Bolsos de aba na frente. Fecho frontal com 1 botão forrado. Interno forrado. Tecido leve, crepe.",
                            ImageUrl = "https://github.com/vitorhaga/Shopping/blob/master/Shopping.Images/blazer-feminino-alongado-de-crepe-e-botao-forrado-preto.jpg?raw=true",
                            Name = "Blazer Feminino Alongado de Crepe e Botão Forrado Preto",
                            Price = 573.3m
                        },
                        new
                        {
                            Id = 6L,
                            CategoryName = "Calça",
                            Description = "Calça casual em sarja masculina. Bolsos na frente e detalhe de bolsos embutidos atrás. Fecho frontal com zíper e botão. Cós com passantes. Modelo slim.",
                            ImageUrl = "https://github.com/vitorhaga/Shopping/blob/master/Shopping.Images/calca-casual-de-sarja-masculina-slim-areia.jpg?raw=true",
                            Name = "Calça Casual de Sarja Masculina Slim Areia",
                            Price = 459m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}