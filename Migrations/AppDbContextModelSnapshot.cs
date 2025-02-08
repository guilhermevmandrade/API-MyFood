﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFood.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyFood.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyFood.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Calories")
                        .HasColumnType("numeric")
                        .HasColumnName("calories");

                    b.Property<decimal>("Carbs")
                        .HasColumnType("numeric")
                        .HasColumnName("carbs");

                    b.Property<decimal>("Fats")
                        .HasColumnType("numeric")
                        .HasColumnName("fats");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Protein")
                        .HasColumnType("numeric")
                        .HasColumnName("protein");

                    b.HasKey("Id");

                    b.ToTable("food");
                });

            modelBuilder.Entity("MyFood.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("MealTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("meal_time");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("meal");
                });

            modelBuilder.Entity("MyFood.Models.MealFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FoodId")
                        .HasColumnType("integer")
                        .HasColumnName("food_id");

                    b.Property<int>("MealId")
                        .HasColumnType("integer")
                        .HasColumnName("meal_id");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric")
                        .HasColumnName("quantity");

                    b.Property<int>("Unit")
                        .HasColumnType("integer")
                        .HasColumnName("unit");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("MealId");

                    b.ToTable("meal_food");
                });

            modelBuilder.Entity("MyFood.Models.NutritionalGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("CarbsPercentage")
                        .HasColumnType("double precision")
                        .HasColumnName("carbs_percentage");

                    b.Property<int>("DailyCalories")
                        .HasColumnType("integer")
                        .HasColumnName("daily_calories");

                    b.Property<double>("FatPercentage")
                        .HasColumnType("double precision")
                        .HasColumnName("fat_percentage");

                    b.Property<double>("ProteinPercentage")
                        .HasColumnType("double precision")
                        .HasColumnName("protein_percentage");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("nutritional_goal");
                });

            modelBuilder.Entity("MyFood.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityLevel")
                        .HasColumnType("integer")
                        .HasColumnName("activity_level");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("height");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("MyFood.Models.Meal", b =>
                {
                    b.HasOne("MyFood.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyFood.Models.MealFood", b =>
                {
                    b.HasOne("MyFood.Models.Food", null)
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyFood.Models.Meal", null)
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyFood.Models.NutritionalGoal", b =>
                {
                    b.HasOne("MyFood.Models.User", null)
                        .WithOne()
                        .HasForeignKey("MyFood.Models.NutritionalGoal", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
