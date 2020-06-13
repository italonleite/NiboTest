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
    [DbContext(typeof(MeuDbContext))]
    [Migration("20200613174138_removendoclasses")]
    partial class removendoclasses
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

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("StatementEnd")
                        .HasColumnName("DTEND")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StatementStart")
                        .HasColumnName("DTSTART")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("BankStatements");
                });

            modelBuilder.Entity("Nibo.Business.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnName("TRNAMT")
                        .HasColumnType("decimal(5,2)");

                    b.Property<Guid>("BankStatementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Memo")
                        .HasColumnName("MEMO")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("TransactionPostDate")
                        .HasColumnName("DTPOSTED")
                        .HasColumnType("datetime");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("TRNTYPE")
                        .HasColumnType("varchar(10)");

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
