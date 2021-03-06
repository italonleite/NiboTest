﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nibo.Data.Context;

namespace Nibo.Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200623162231_v5")]
    partial class v5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nibo.Business.Models.BankStatement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("BankStatements");
                });

            modelBuilder.Entity("Nibo.Business.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnName("Trnamt")
                        .HasColumnType("decimal");

                    b.Property<Guid>("BankStatementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Memo")
                        .HasColumnName("Memo")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("TransactionPostDate")
                        .HasColumnName("Dtposted")
                        .HasColumnType("datetime");

                    b.Property<int>("Type")
                        .HasColumnName("Trntype")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BankStatementId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Nibo.Business.Models.Transaction", b =>
                {
                    b.HasOne("Nibo.Business.Models.BankStatement", "BankStatement")
                        .WithMany("Transactions")
                        .HasForeignKey("BankStatementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
