﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeripheralTech.WebAPI.Database;

namespace PeripheralTech.WebAPI.Migrations
{
    [DbContext(typeof(PeripheralTechDbContext))]
    [Migration("20210705125107_migVidTitle")]
    partial class migVidTitle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Bill", b =>
                {
                    b.Property<int>("BillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("BIT");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("BillID");

                    b.HasIndex("OrderID");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZIPCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.HasIndex("CountryID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Discount", b =>
                {
                    b.Property<int>("DiscountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("DECIMAL(12,8)");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("DiscountID");

                    b.HasIndex("ProductID");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.News", b =>
                {
                    b.Property<int>("NewsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Thumbnail")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("NewsID");

                    b.HasIndex("UserID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatusID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("OrderStatusID");

                    b.HasIndex("UserID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.OrderProduct", b =>
                {
                    b.Property<int>("OrderProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("OrderProductID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderStatusID");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountInStock")
                        .HasColumnType("int");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int>("ProductTypeID")
                        .HasColumnType("int");

                    b.Property<byte[]>("Thumbnail")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ProductID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("ProductTypeID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.ProductImage", b =>
                {
                    b.Property<int>("ProductImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ProductImageID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.ProductType", b =>
                {
                    b.Property<int>("ProductTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductTypeID");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.ProductVideo", b =>
                {
                    b.Property<int>("ProductVideoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Video")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ProductVideoID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductVideo");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StaffID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("StaffID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.QuestionComment", b =>
                {
                    b.Property<int>("QuestionCommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("QuestionCommentID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("UserID");

                    b.ToTable("QuestionComment");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.StaffReview", b =>
                {
                    b.Property<int>("StaffReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ReviewContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specifications")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("StaffReviewID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("StaffReview");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfileImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("CityID");

                    b.HasIndex("UserRoleID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.UserFavoriteProduct", b =>
                {
                    b.Property<int>("UserFavoriteProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UserFavoriteProductID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("UserFavoriteProduct");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.UserReview", b =>
                {
                    b.Property<int>("UserReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UserReviewID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("UserReview");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.UserRole", b =>
                {
                    b.Property<int>("UserRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleID");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Bill", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.City", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Discount", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.News", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Order", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeripheralTech.WebAPI.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.OrderProduct", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeripheralTech.WebAPI.Database.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Product", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeripheralTech.WebAPI.Database.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.ProductImage", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.ProductVideo", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.Question", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeripheralTech.WebAPI.Database.User", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffID");

                    b.Navigation("Customer");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.QuestionComment", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeripheralTech.WebAPI.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.StaffReview", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeripheralTech.WebAPI.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.User", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID");

                    b.HasOne("PeripheralTech.WebAPI.Database.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.UserFavoriteProduct", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeripheralTech.WebAPI.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PeripheralTech.WebAPI.Database.UserReview", b =>
                {
                    b.HasOne("PeripheralTech.WebAPI.Database.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeripheralTech.WebAPI.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
