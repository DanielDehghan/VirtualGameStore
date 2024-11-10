﻿// <auto-generated />
using System;
using ConestogaVirtualGameStore.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ConestogaVirtualGameStore.AppDbContext;

#nullable disable

namespace ConestogaVirtualGameStore.Migrations
{
    [DbContext(typeof(VirtualGameStoreContext))]
    partial class VirtualGameStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Address = "108 University Ave E",
                            City = "Waterloo",
                            Country = "Canada",
                            Date = new DateTime(2024, 12, 15, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "A meetup event with the Conestoga Esports team and their fans",
                            Name = "Conestoga Esports Meetup",
                            PostalCode = "N2J 2W2",
                            Province = "Ontario"
                        },
                        new
                        {
                            EventId = 2,
                            Address = "299 Doon Valley Dr",
                            City = "Kitchener",
                            Country = "Canada",
                            Date = new DateTime(2024, 12, 18, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A retro game sale with many popular and beloved classic games",
                            Name = "Conestoga Retro Game Sale",
                            PostalCode = "N2G 4M4",
                            Province = "Ontario"
                        },
                        new
                        {
                            EventId = 3,
                            Address = "775 Main Street East",
                            City = "Milton",
                            Country = "Canada",
                            Date = new DateTime(2024, 12, 20, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A game convention with sales, fan-favourite game actors, and sneak peak on new game releases on the Conestoga Video Game Store website",
                            Name = "Conestoga Gaming Convention",
                            PostalCode = "L9T 3Z3",
                            Province = "Ontario"
                        },
                        new
                        {
                            EventId = 4,
                            Address = "850 Fountain Street South",
                            City = "Cambridge",
                            Country = "Canada",
                            Date = new DateTime(2024, 12, 28, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A game tournament that has competitors facing each other in various fighting and fps games to win a cash prize",
                            Name = "Conestoga Gaming Tournament",
                            PostalCode = "N3H 0A8",
                            Province = "Ontario"
                        });
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<string>("CoverImageURL")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Genere")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GameId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202208/1718/NFf86jgU4AeVYgJBEoEKBpxW.jpg",
                            Description = "An action RPG set in a historical setting, featuring stealth and combat elements.",
                            Genere = "Action RPG",
                            Platform = "PlayStation 5, Xbox Series X/S, PC",
                            Price = 59.99m,
                            ReleaseDate = new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Assassin's Creed Mirage"
                        },
                        new
                        {
                            GameId = 2,
                            CoverImageURL = "https://cdn2.steamgriddb.com/grid/3c8907c9dc26266603441dcb03dbe620.png",
                            Description = "The latest installment in the Call of Duty series, offering intense first-person shooter action.",
                            Genere = "First-Person Shooter",
                            Platform = "PlayStation 5, Xbox Series X/S, PC",
                            Price = 69.99m,
                            ReleaseDate = new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Call of Duty MW3"
                        },
                        new
                        {
                            GameId = 3,
                            CoverImageURL = "https://upload.wikimedia.org/wikipedia/en/9/9f/Cyberpunk_2077_box_art.jpg",
                            Description = "A futuristic open-world RPG set in the dystopian Night City, filled with cybernetic enhancements and complex narratives.",
                            Genere = "Action RPG",
                            Platform = "PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, PC",
                            Price = 39.99m,
                            ReleaseDate = new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Cyberpunk 2077"
                        },
                        new
                        {
                            GameId = 4,
                            CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202207/1210/4xJ8XB3bi888QTLZYdl7Oi0s.png",
                            Description = "An epic sequel to the critically acclaimed God of War, featuring Norse mythology and Kratos' journey.",
                            Genere = "Action-Adventure",
                            Platform = "PlayStation 4, PlayStation 5",
                            Price = 69.99m,
                            ReleaseDate = new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "God of War Ragnarok"
                        },
                        new
                        {
                            GameId = 5,
                            CoverImageURL = "https://upload.wikimedia.org/wikipedia/en/d/df/Resident_Evil_4_remake_cover_art.jpg",
                            Description = "A modern remake of the classic survival horror game, offering updated graphics and gameplay mechanics.",
                            Genere = "Survival Horror",
                            Platform = "PlayStation 4, PlayStation 5, Xbox Series X/S, PC",
                            Price = 59.99m,
                            ReleaseDate = new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Resident Evil 4 Remake"
                        },
                        new
                        {
                            GameId = 6,
                            CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202312/0117/315718bce7eed62e3cf3fb02d61b81ff1782d6b6cf850fa4.png",
                            Description = "A narrative-driven action-adventure game that continues the story of Ellie and Joel in a post-apocalyptic world.",
                            Genere = "Action-Adventure",
                            Platform = "PlayStation 4",
                            Price = 59.99m,
                            ReleaseDate = new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Last of Us: Part 2"
                        });
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Member", b =>
                {
                    b.Property<int>("Member_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Member_ID"));

                    b.Property<string>("Apt_suit")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Country")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasMaxLength(255)
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryInstruction")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Gender")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone_Number")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Postal_Code")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PreferredCategory")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PreferredLanguage")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PreferredPlatform")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Province")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("ReceivePromotionalEmails")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Register_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("StreetAddress")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Member_ID");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Member_ID = 1,
                            Apt_suit = "Apt 101",
                            City = "Toronto",
                            Country = "Canada",
                            DateOfBirth = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliveryInstruction = "Leave at front door",
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            Gender = "Male",
                            LastName = "Doe",
                            Password = "password123",
                            Phone_Number = "123-456-7890",
                            Postal_Code = "M5A 1A1",
                            PreferredCategory = "Action",
                            PreferredLanguage = "English",
                            PreferredPlatform = "PC",
                            Province = "ON",
                            ReceivePromotionalEmails = true,
                            Register_Date = new DateTime(2024, 11, 8, 23, 44, 47, 49, DateTimeKind.Local).AddTicks(6844),
                            StreetAddress = "123 Main St"
                        },
                        new
                        {
                            Member_ID = 2,
                            Apt_suit = "Apt 202",
                            City = "Montreal",
                            Country = "Canada",
                            DateOfBirth = new DateTime(1992, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliveryInstruction = "Call upon arrival",
                            Email = "jane.smith@example.com",
                            FirstName = "Jane",
                            Gender = "Female",
                            LastName = "Smith",
                            Password = "password456",
                            Phone_Number = "987-654-3210",
                            Postal_Code = "H2X 1A1",
                            PreferredCategory = "RPG",
                            PreferredLanguage = "French",
                            PreferredPlatform = "PlayStation",
                            Province = "QC",
                            ReceivePromotionalEmails = false,
                            Register_Date = new DateTime(2024, 11, 8, 23, 44, 47, 49, DateTimeKind.Local).AddTicks(6886),
                            StreetAddress = "456 Elm St"
                        },
                        new
                        {
                            Member_ID = 3,
                            Apt_suit = "Suite 300",
                            City = "Vancouver",
                            Country = "Canada",
                            DateOfBirth = new DateTime(1995, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliveryInstruction = "Leave with concierge",
                            Email = "alex.johnson@example.com",
                            FirstName = "Alex",
                            Gender = "Non-binary",
                            LastName = "Johnson",
                            Password = "password789",
                            Phone_Number = "321-654-9870",
                            Postal_Code = "V5K 1A1",
                            PreferredCategory = "Shooter",
                            PreferredLanguage = "English",
                            PreferredPlatform = "Xbox",
                            Province = "BC",
                            ReceivePromotionalEmails = true,
                            Register_Date = new DateTime(2024, 11, 8, 23, 44, 47, 49, DateTimeKind.Local).AddTicks(6889),
                            StreetAddress = "789 Maple Ave"
                        });
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.MemberEvent", b =>
                {
                    b.Property<int>("MemberEvent_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberEvent_ID"));

                    b.Property<int>("Event_ID")
                        .HasColumnType("int");

                    b.Property<int>("Member_ID")
                        .HasColumnType("int");

                    b.HasKey("MemberEvent_ID");

                    b.ToTable("MembersEvents");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ConestogaVirtualGameStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ConestogaVirtualGameStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConestogaVirtualGameStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ConestogaVirtualGameStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
