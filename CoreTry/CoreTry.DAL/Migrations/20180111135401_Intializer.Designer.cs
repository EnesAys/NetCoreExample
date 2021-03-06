﻿// <auto-generated />
using CoreTry.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CoreTry.DAL.Migrations
{
    [DbContext(typeof(UserColorContext))]
    [Migration("20180111135401_Intializer")]
    partial class Intializer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreTry.DAL.Color", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColorName");

                    b.HasKey("ID");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("CoreTry.DAL.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("ColorID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Mail");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.HasIndex("ColorID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoreTry.DAL.User", b =>
                {
                    b.HasOne("CoreTry.DAL.Color", "Color")
                        .WithMany("Users")
                        .HasForeignKey("ColorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
