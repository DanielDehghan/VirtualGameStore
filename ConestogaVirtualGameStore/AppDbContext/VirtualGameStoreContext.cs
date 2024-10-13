﻿using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MyVirtualGameStore.AppDbContext
{

    public class VirtualGameStoreContext : IdentityDbContext<ApplicationUser>
    {
        public VirtualGameStoreContext(DbContextOptions<VirtualGameStoreContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
     .Property(g => g.Price)
     .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Game>().HasData(
              new Game { GameId = 1, Title = "Assassin's Creed Mirage", Genere = "Action RPG", ReleaseDate = new DateTime(2023, 10, 05), Description = "An action RPG set in a historical setting, featuring stealth and combat elements.", Platform = "PlayStation 5, Xbox Series X/S, PC", Price = 59.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202208/1718/NFf86jgU4AeVYgJBEoEKBpxW.jpg" },
new Game { GameId = 2, Title = "Call of Duty MW3", Genere = "First-Person Shooter", ReleaseDate = new DateTime(2023, 11, 10), Description = "The latest installment in the Call of Duty series, offering intense first-person shooter action.", Platform = "PlayStation 5, Xbox Series X/S, PC", Price = 69.99m, CoverImageURL = "https://cdn2.steamgriddb.com/grid/3c8907c9dc26266603441dcb03dbe620.png" },
new Game { GameId = 3, Title = "Cyberpunk 2077", Genere = "Action RPG", ReleaseDate = new DateTime(2020, 12, 10), Description = "A futuristic open-world RPG set in the dystopian Night City, filled with cybernetic enhancements and complex narratives.", Platform = "PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, PC", Price = 39.99m, CoverImageURL = "https://upload.wikimedia.org/wikipedia/en/9/9f/Cyberpunk_2077_box_art.jpg" },
new Game { GameId = 4, Title = "God of War Ragnarok", Genere = "Action-Adventure", ReleaseDate = new DateTime(2022, 11, 09), Description = "An epic sequel to the critically acclaimed God of War, featuring Norse mythology and Kratos' journey.", Platform = "PlayStation 4, PlayStation 5", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202207/1210/4xJ8XB3bi888QTLZYdl7Oi0s.png" },
new Game { GameId = 5, Title = "Resident Evil 4 Remake", Genere = "Survival Horror", ReleaseDate = new DateTime(2023, 03, 24), Description = "A modern remake of the classic survival horror game, offering updated graphics and gameplay mechanics.", Platform = "PlayStation 4, PlayStation 5, Xbox Series X/S, PC", Price = 59.99m, CoverImageURL = "https://upload.wikimedia.org/wikipedia/en/d/df/Resident_Evil_4_remake_cover_art.jpg" },
new Game { GameId = 6, Title = "Last of Us: Part 2", Genere = "Action-Adventure", ReleaseDate = new DateTime(2020, 06, 19), Description = "A narrative-driven action-adventure game that continues the story of Ellie and Joel in a post-apocalyptic world.", Platform = "PlayStation 4", Price = 59.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202312/0117/315718bce7eed62e3cf3fb02d61b81ff1782d6b6cf850fa4.png" }

            );

            modelBuilder.Entity<Member>().HasData(
              new Member
              {
                  Member_ID = 1,
                  FirstName = "John",
                  LastName = "Doe",
                  Email = "john.doe@example.com",
                  Password = "password123",
                  Address = "123 Main St",
                  Country = "USA",
                  City = "New York",
                  Province = "NY",
                  Postal_Code = "10001",
                  Phone_Number = "555-1234",
                  Language_ID = null, // Assuming no foreign key for Language
                  Cart_ID = null,     // Assuming no foreign key for Cart
                  Register_Date = DateTime.Now
              },
              new Member
              {
                  Member_ID = 2,
                  FirstName = "Jane",
                  LastName = "Smith",
                  Email = "jane.smith@example.com",
                  Password = "password456",
                  Address = "456 Elm St",
                  Country = "Canada",
                  City = "Toronto",
                  Province = "ON",
                  Postal_Code = "M5H 2N2",
                  Phone_Number = "555-5678",
                  Language_ID = null,
                  Cart_ID = null,
                  Register_Date = DateTime.Now
              }

          );
        }
    }

}
