﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyShop.Models;

namespace MyShop.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20191122035930_SendSMSTwilo")]
    partial class SendSMSTwilo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyShop.Models.Bill", b =>
                {
                    b.Property<int>("BillID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BillTime");

                    b.Property<int>("CustomerID");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<double>("TotalAmount");

                    b.HasKey("BillID");

                    b.HasIndex("CustomerID");

                    b.ToTable("bills");
                });

            modelBuilder.Entity("MyShop.Models.BillDetail", b =>
                {
                    b.Property<int>("BillDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("BillID");

                    b.Property<int>("ProductID");

                    b.HasKey("BillDetailID");

                    b.HasIndex("BillID");

                    b.HasIndex("ProductID");

                    b.ToTable("billDetails");
                });

            modelBuilder.Entity("MyShop.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addres")
                        .HasMaxLength(100);

                    b.Property<string>("AuthyId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("CustomerID");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("MyShop.Models.Discount", b =>
                {
                    b.Property<int>("DiscountID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscountValue");

                    b.Property<DateTime>("ExpirationDay")
                        .HasMaxLength(20);

                    b.HasKey("DiscountID");

                    b.ToTable("discounts");
                });

            modelBuilder.Entity("MyShop.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<int?>("DiscountID");

                    b.Property<string>("ProductImage")
                        .HasMaxLength(50);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("TrademarkID");

                    b.Property<int>("TypeID");

                    b.Property<double>("UnitPrice");

                    b.HasKey("ProductID");

                    b.HasIndex("DiscountID");

                    b.HasIndex("TrademarkID");

                    b.HasIndex("TypeID");

                    b.ToTable("products");
                });

            modelBuilder.Entity("MyShop.Models.ProductType", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FatherTypeID");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("TypeID");

                    b.HasIndex("FatherTypeID");

                    b.ToTable("productTypes");
                });

            modelBuilder.Entity("MyShop.Models.Trademark", b =>
                {
                    b.Property<int>("TrademarkID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addres")
                        .HasMaxLength(150);

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Logo")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TrademarkID");

                    b.ToTable("trademarks");
                });

            modelBuilder.Entity("MyShop.Models.Bill", b =>
                {
                    b.HasOne("MyShop.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyShop.Models.BillDetail", b =>
                {
                    b.HasOne("MyShop.Models.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyShop.Models.Product", b =>
                {
                    b.HasOne("MyShop.Models.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountID");

                    b.HasOne("MyShop.Models.Trademark", "Trademark")
                        .WithMany()
                        .HasForeignKey("TrademarkID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyShop.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyShop.Models.ProductType", b =>
                {
                    b.HasOne("MyShop.Models.ProductType", "FatherProductType")
                        .WithMany()
                        .HasForeignKey("FatherTypeID");
                });
#pragma warning restore 612, 618
        }
    }
}
