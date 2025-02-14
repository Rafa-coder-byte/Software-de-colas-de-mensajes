﻿// <auto-generated />
using System;
using MessageQueue.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MessageQueue.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("MessageQueue.Domain.Entities.Consumer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Consumers", (string)null);
                });

            modelBuilder.Entity("MessageQueue.Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProducerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReadBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Messages", (string)null);
                });

            modelBuilder.Entity("MessageQueue.Domain.Entities.Producer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Producers", (string)null);
                });

            modelBuilder.Entity("MessageQueue.Domain.Entities.Consumer", b =>
                {
                    b.OwnsOne("MessageQueue.Domain.ValueObjects.NetworkEndpoint", "Endpoint", b1 =>
                        {
                            b1.Property<Guid>("ConsumerId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("IP")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("TEXT")
                                .HasColumnName("IPAddress");

                            b1.Property<int>("Port")
                                .HasColumnType("INTEGER")
                                .HasColumnName("PortNumber");

                            b1.HasKey("ConsumerId");

                            b1.ToTable("Consumers");

                            b1.WithOwner()
                                .HasForeignKey("ConsumerId");
                        });

                    b.Navigation("Endpoint")
                        .IsRequired();
                });

            modelBuilder.Entity("MessageQueue.Domain.Entities.Message", b =>
                {
                    b.HasOne("MessageQueue.Domain.Entities.Producer", null)
                        .WithMany()
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MessageQueue.Domain.ValueObjects.MessageContent", "Content", b1 =>
                        {
                            b1.Property<Guid>("MessageId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Content")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("TEXT")
                                .HasColumnName("Body");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("TEXT")
                                .HasColumnName("Title");

                            b1.HasKey("MessageId");

                            b1.ToTable("Messages");

                            b1.WithOwner()
                                .HasForeignKey("MessageId");
                        });

                    b.Navigation("Content")
                        .IsRequired();
                });

            modelBuilder.Entity("MessageQueue.Domain.Entities.Producer", b =>
                {
                    b.OwnsOne("MessageQueue.Domain.ValueObjects.NetworkEndpoint", "Endpoint", b1 =>
                        {
                            b1.Property<Guid>("ProducerId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("IP")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("TEXT")
                                .HasColumnName("IPAddress");

                            b1.Property<int>("Port")
                                .HasColumnType("INTEGER")
                                .HasColumnName("PortNumber");

                            b1.HasKey("ProducerId");

                            b1.ToTable("Producers");

                            b1.WithOwner()
                                .HasForeignKey("ProducerId");
                        });

                    b.Navigation("Endpoint")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
