using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyVirtualGameStore.AppDbContext
{
    public class VirtualGameStoreContext : IdentityDbContext<ApplicationUser>
    {
        public VirtualGameStoreContext(DbContextOptions<VirtualGameStoreContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Member> Members { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<MemberEvent> MembersEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .Property(g => g.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = 1, Title = "Assassin's Creed Mirage", Genre = "Action RPG", ReleaseDate = new DateTime(2023, 10, 05), Description = "An action RPG set in a historical setting, featuring stealth and combat elements.", Platform = "PlayStation 5, Xbox Series X/S, PC", Price = 59.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202208/1718/NFf86jgU4AeVYgJBEoEKBpxW.jpg" },
                new Game { GameId = 2, Title = "Call of Duty MW3", Genre = "First-Person Shooter", ReleaseDate = new DateTime(2023, 11, 10), Description = "The latest installment in the Call of Duty series, offering intense first-person shooter action.", Platform = "PlayStation 5, Xbox Series X/S, PC", Price = 69.99m, CoverImageURL = "https://cdn2.steamgriddb.com/grid/3c8907c9dc26266603441dcb03dbe620.png" },
                new Game { GameId = 3, Title = "Cyberpunk 2077", Genre = "Action RPG", ReleaseDate = new DateTime(2020, 12, 10), Description = "A futuristic open-world RPG set in the dystopian Night City, filled with cybernetic enhancements and complex narratives.", Platform = "PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, PC", Price = 39.99m, CoverImageURL = "https://upload.wikimedia.org/wikipedia/en/9/9f/Cyberpunk_2077_box_art.jpg" },
                new Game { GameId = 4, Title = "God of War Ragnarok", Genre = "Action-Adventure", ReleaseDate = new DateTime(2022, 11, 09), Description = "An epic sequel to the critically acclaimed God of War, featuring Norse mythology and Kratos' journey.", Platform = "PlayStation 4, PlayStation 5", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202207/1210/4xJ8XB3bi888QTLZYdl7Oi0s.png" },
                new Game { GameId = 5, Title = "Resident Evil 4 Remake", Genre = "Survival Horror", ReleaseDate = new DateTime(2023, 03, 24), Description = "A modern remake of the classic survival horror game, offering updated graphics and gameplay mechanics.", Platform = "PlayStation 4, PlayStation 5, Xbox Series X/S, PC", Price = 59.99m, CoverImageURL = "https://upload.wikimedia.org/wikipedia/en/d/df/Resident_Evil_4_remake_cover_art.jpg" },
                new Game { GameId = 6, Title = "Last of Us: Part 2", Genre = "Action-Adventure", ReleaseDate = new DateTime(2020, 06, 19), Description = "A narrative-driven action-adventure game that continues the story of Ellie and Joel in a post-apocalyptic world.", Platform = "PlayStation 4", Price = 59.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202312/0117/315718bce7eed62e3cf3fb02d61b81ff1782d6b6cf850fa4.png" }
            );

            modelBuilder.Entity<Event>().HasData(
                 new Event { EventId = 1, Name = "Conestoga Esports Meetup", Date = new DateTime(2024, 12, 15, 14, 30, 0), Address = "108 University Ave E", Country = "Canada", City = "Waterloo", Province = "Ontario", PostalCode = "N2J 2W2", Description = "A meetup event with the Conestoga Esports team and their fans" },
                 new Event { EventId = 2, Name = "Conestoga Retro Game Sale", Date = new DateTime(2024, 12, 18, 12, 0, 0), Address = "299 Doon Valley Dr", Country = "Canada", City = "Kitchener", Province = "Ontario", PostalCode = "N2G 4M4", Description = "A retro game sale with many popular and beloved classic games" },
                 new Event { EventId = 3, Name = "Conestoga Gaming Convention", Date = new DateTime(2024, 12, 20, 8, 0, 0), Address = "775 Main Street East", Country = "Canada", City = "Milton", Province = "Ontario", PostalCode = "L9T 3Z3", Description = "A game convention with sales, fan-favourite game actors, and sneak peak on new game releases on the Conestoga Video Game Store website" },
                 new Event { EventId = 4, Name = "Conestoga Gaming Tournament", Date = new DateTime(2024, 12, 28, 17, 0, 0), Address = "850 Fountain Street South", Country = "Canada", City = "Cambridge", Province = "Ontario", PostalCode = "N3H 0A8", Description = "A game tournament that has competitors facing each other in various fighting and fps games to win a cash prize" }
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
