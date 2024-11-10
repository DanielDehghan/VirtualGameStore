using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConestogaVirtualGameStore.AppDbContext
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
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<MemberRelationship> MembersRelationships { get; set; }


        public DbSet<Wishlist> Wishlist { get; set; }

        public DbSet<Wishlist_Games> Wishlist_Games { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .Property(g => g.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MemberRelationship>()
                .HasOne(mr => mr.Member)
                .WithMany(m => m.MemberRelationshipPrimary)
                .HasForeignKey(mr => mr.Member_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MemberRelationship>()
                .HasOne(mr => mr.MemberAdded)
                .WithMany(m => m.MemberRelationshipRelated)
                .HasForeignKey(mr => mr.MemberAdded_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MemberRelationship>()
                .HasOne(mr => mr.Relationship)
                .WithMany(r => r.MemberRelationship)
                .HasForeignKey(mr => mr.Relationship_ID);

            modelBuilder.Entity<Wishlist>()
               .HasOne(w => w.Member)
               .WithMany(m => m.Wishlists)
               .HasForeignKey(w => w.Member_ID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist_Games>()
                .HasKey(wg => new { wg.Wishlist_ID, wg.GameId });

            modelBuilder.Entity<Wishlist_Games>()
                .HasOne(wg => wg.Wishlist)
                .WithMany(w => w.Wishlist_Games)
                .HasForeignKey(wg => wg.Wishlist_ID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist_Games>()
                .HasOne(wg => wg.Game)
                .WithMany(g => g.Wishlist_Games)
                .HasForeignKey(wg => wg.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Relationship>().HasData(
                new Relationship { Relationship_ID = 1, Relationship_Type = "Friend" },
                new Relationship { Relationship_ID = 2, Relationship_Type = "Family" }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = 1, Title = "Assassin's Creed Mirage", Genere = "Action RPG", ReleaseDate = new DateTime(2023, 10, 05), Description = "An action RPG set in a historical setting, featuring stealth and combat elements.", Platform = "PlayStation 5, Xbox Series X/S, PC", Price = 59.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202208/1718/NFf86jgU4AeVYgJBEoEKBpxW.jpg" },
                new Game { GameId = 2, Title = "Call of Duty MW3", Genere = "First-Person Shooter", ReleaseDate = new DateTime(2023, 11, 10), Description = "The latest installment in the Call of Duty series, offering intense first-person shooter action.", Platform = "PlayStation 5, Xbox Series X/S, PC", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202308/1722/15f4ab1e0fe6a37609b164362a653c0e5bcee98a861d0f10.png" },
                new Game { GameId = 3, Title = "Cyberpunk 2077", Genere = "Action RPG", ReleaseDate = new DateTime(2020, 12, 10), Description = "A futuristic open-world RPG set in the dystopian Night City, filled with cybernetic enhancements and complex narratives.", Platform = "PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, PC", Price = 39.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202008/0416/6Bo40lnWU0BhgrOUm7Cb6by3.png" },
                new Game { GameId = 4, Title = "God of War Ragnarok", Genere = "Action-Adventure", ReleaseDate = new DateTime(2022, 11, 09), Description = "An epic sequel to the critically acclaimed God of War, featuring Norse mythology and Kratos' journey.", Platform = "PlayStation 4, PlayStation 5", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202207/1210/4xJ8XB3bi888QTLZYdl7Oi0s.png" },
                new Game { GameId = 5, Title = "Resident Evil 4 Remake", Genere = "Survival Horror", ReleaseDate = new DateTime(2023, 03, 24), Description = "A modern remake of the classic survival horror game, offering updated graphics and gameplay mechanics.", Platform = "PlayStation 4, PlayStation 5, Xbox Series X/S, PC", Price = 59.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202207/2509/85p2Dwh5iDhUzRKe40QeNYh3.png" },
                new Game { GameId = 6, Title = "Last of Us: Part 2", Genere = "Action-Adventure", ReleaseDate = new DateTime(2020, 06, 19), Description = "A narrative-driven action-adventure game that continues the story of Ellie and Joel in a post-apocalyptic world.", Platform = "PlayStation 4", Price = 59.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202312/0117/315718bce7eed62e3cf3fb02d61b81ff1782d6b6cf850fa4.png" },
                new Game { GameId = 7, Title = "Elden Ring", Genere = "Action RPG", ReleaseDate = new DateTime(2022, 02, 25), Description = "In a dark fantasy world created by Hidetaka Miyazaki (Dark Souls) and George R. R. Martin (A Song of Ice and Fire), the player is a Tarnished who is called back to the Lands Between to restore the Elden Ring and become the Elden Lord.", Platform = "PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, PC", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202110/2000/phvVT0qZfcRms5qDAk0SI3CM.png" },
                new Game { GameId = 8, Title = "Call of Duty: Modern Warfare II", Genere = "First-Person Shooter", ReleaseDate = new DateTime(2022, 10, 28), Description = "Task Force 141 faces its greatest threat yet - a newly aligned menace with deep, yet unknown, connections.", Platform = "PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, PC", Price = 59.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202205/2800/W5uSEsW7yefCNTHatS03v5q7.png" },
                new Game { GameId = 9, Title = "Fallout 4", Genere = "Action RPG", ReleaseDate = new DateTime(2015, 11, 10), Description = "In the post-apocalyptic Boston, Massachusetts area, you play as the Sole Survivor of Vault 111, recently revived from centuries of forced cryostasis, determined to find your kidnapped son.", Platform = "PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, PC", Price = 59.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202009/2419/BWMVfyxONkIAlAJVQd96qPuN.png" },
                new Game { GameId = 10, Title = "Call of Duty: Modern Warfare", Genere = "First-Person Shooter", ReleaseDate = new DateTime(2019, 10, 25), Description = "Captain Price and the SAS partner with the CIA and the Urzikstani Liberation Force to retrieve stolen chemical weapons. The fight takes you from London to the Middle East and beyond, as this joint task force battles to stop a global war.", Platform = "PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, PC", Price = 59.99m, CoverImageURL = "https://image.api.playstation.com/cdn/UP0002/CUSA08829_00/xmKUnAOenEAKspB3FlOg80aQZfEoCYcE.png" },
                new Game { GameId = 11, Title = "Spider-Man 2", Genere = "Action-Adventure", ReleaseDate = new DateTime(2023, 10, 20), Description = "Spider-Men, Peter Parker and Miles Morales, return for an exciting new adventure in the critically acclaimed Marvel's Spider-Man franchise.", Platform = "PlayStation 5", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202306/1219/1c7b75d8ed9271516546560d219ad0b22ee0a263b4537bd8.png" },
                new Game { GameId = 12, Title = "Call of Duty: Black Ops 6", Genere = "First-Person Shooter", ReleaseDate = new DateTime(2024, 10, 25), Description = "As the Gulf War seizes the world's attention, a covert and enigmatic group has penetrated the upper echelons of the CIA, labeling those who oppose them as betrayers. Black Ops veteran Frank Woods and his squad, once celebrated as heroes by their agency and nation, now find themselves banished and pursued by the very military entity that forged them. They are now outcasts in their own land, hunted by the machinery of war that they once served.", Platform = "PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, PC", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202405/2921/2819b5df32c19b4b9e972dc3281b474937bb2570312b38a2.png" },
                new Game { GameId = 13, Title = "Until Dawn", Genere = "Survival Horror", ReleaseDate = new DateTime(2024, 10, 4), Description = "Until Dawn is a branching narrative survival horror game in which any choice of action by the player may cause other consequences later in the story. It was rebuilt from the ground up with stunning visuals in Unreal Engine 5.", Platform = "PlayStation 5, PC", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202401/2910/d48262b72a5a2daa3ca3aed6c8f42c44f3fdaf2902265a13.png" },
                new Game { GameId = 14, Title = "Silent Hill 2 Remake", Genere = "Survival Horror", ReleaseDate = new DateTime(2024, 10, 8), Description = "Having received a letter from his deceased wife, James heads to where they shared so many memories, in the hope of seeing her one more time: Silent Hill. There, by the lake, he finds a woman eerily similar to her.", Platform = "PlayStation 5, PC", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202210/2000/IgwsFz9BiBrFvyV7pIWpoVgd.png" },
                new Game { GameId = 15, Title = "God of War", Genere = "Action-Adventure", ReleaseDate = new DateTime(2018, 04, 20), Description = "After wiping out the gods of Mount Olympus, Kratos moves on to the frigid lands of Scandinavia, where he and his son must embark on an odyssey across a dangerous world of gods and monsters.", Platform = "PlayStation 5, PC", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/img/rnd/202010/2217/p3pYq0QxntZQREXRVdAzmn1w.png" },
                new Game { GameId = 16, Title = "Alan Wake II", Genere = "Survival Horror", ReleaseDate = new DateTime(2023, 10, 27), Description = "13 years after bestselling writer Alan Wake went missing, a string of ritualistic murders occur in the town of Bright Falls, Washington. Saga Anderson, an FBI agent, is sent to Bright Falls to investigate the murders.", Platform = "Xbox Series X/S, PlayStation 5, PC", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202305/2420/83ef93949d474052cc87b86617a5498505d4b50390280394.jpg" },
                new Game { GameId = 17, Title = "Diablo IV", Genere = "Action RPG", ReleaseDate = new DateTime(2023, 06, 06), Description = "After millions have been slaughtered by the actions of the High Heavens and Burning Hells alike. In the power vacuum, a legendary name resurfaces - Lilith, daughter of Mephisto, the whispered progenitor of humanity.", Platform = "Xbox Series X/S, PlayStation 5, PC", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202405/3123/1abfc0f37be11993bd5e67fcb1a9e2c0d656142ace2f232e.png" },
                new Game { GameId = 18, Title = "Rainbow Six: Siege", Genere = "First-Person Shooter", ReleaseDate = new DateTime(2023, 12, 08), Description = "A team of soldiers and militarists are recruited into an elite counter terrorism unit. Their objective is to fight terrorism across the globe. A threat has emerged that targets the Western world and its interests around the world.", Platform = "Xbox Series X/S, PlayStation 5, PC", Price = 50.00m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202209/2121/UlfMBx2yUHge8Vlz7eszqw13.png" },
                new Game { GameId = 19, Title = "Control", Genere = "Action-Adventure", ReleaseDate = new DateTime(2019, 08, 27), Description = "You are Jesse Faden, a young woman with a troubled past. You become the new Director of the Bureau of Control - Our frontline in researching and fighting against supernatural enemies like the Hiss threatening our very existence.", Platform = "Xbox Series X/S, PlayStation 5, PC", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/img/cfn/113078vQ_SpN-Wt1Ejgw5dPLXKnMvMfvZuekrerzhAOXaNrwZuCL6R6YEP4lUSGhMDthl6iyr4LbA_w565pBSa1xbUcHXtH8.png" },
                new Game { GameId = 20, Title = "Resident Evil Village", Genere = "Survival Horror", ReleaseDate = new DateTime(2021, 05, 07), Description = "Ethan Winters' world suddenly comes crashing down when Chris Redfield's appearance sets off a chain of events that ultimately leads him to a mysterious village.", Platform = "Xbox Series X/S, PlayStation 5, PC", Price = 69.99m, CoverImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202101/0812/FkzwjnJknkrFlozkTdeQBMub.png" }
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
                },
                new Member
                {
                    Member_ID = 3,
                    FirstName = "Amelia",
                    LastName = "Hawke",
                    Email = "amelia.hawke@example.com",
                    Password = "password123",
                    Address = "123 Maple St",
                    Country = "USA",
                    City = "New York",
                    Province = "NY",
                    Postal_Code = "10001",
                    Phone_Number = "555-1234",
                    Language_ID = null,
                    Cart_ID = null,
                    Register_Date = DateTime.Now
                },
                new Member
                {
                    Member_ID = 4,
                    FirstName = "Leo",
                    LastName = "Montgomery",
                    Email = "leo.montgomery@example.com",
                    Password = "password234",
                    Address = "456 Oak St",
                    Country = "Canada",
                    City = "Vancouver",
                    Province = "BC",
                    Postal_Code = "V6B 3A2",
                    Phone_Number = "555-2345",
                    Language_ID = null,
                    Cart_ID = null,
                    Register_Date = DateTime.Now
                },

                new Member
                {
                    Member_ID = 5,
                    FirstName = "Clara",
                    LastName = "Fitzgerald",
                    Email = "clara.fitzgerald@example.com",
                    Password = "password345",
                    Address = "789 Pine St",
                    Country = "UK",
                    City = "London",
                    Province = "England",
                    Postal_Code = "EC1A 1BB",
                    Phone_Number = "555-3456",
                    Language_ID = null,
                    Cart_ID = null,
                    Register_Date = DateTime.Now
                },

                new Member
                {
                    Member_ID = 6,
                    FirstName = "Ethan",
                    LastName = "Rivers",
                    Email = "ethan.rivers@example.com",
                    Password = "password456",
                    Address = "101 Birch St",
                    Country = "USA",
                    City = "Los Angeles",
                    Province = "CA",
                    Postal_Code = "90001",
                    Phone_Number = "555-4567",
                    Language_ID = null,
                    Cart_ID = null,
                    Register_Date = DateTime.Now
                },

                new Member
                {
                    Member_ID = 7,
                    FirstName = "Sofia",
                    LastName = "Langford",
                    Email = "sofia.langford@example.com",
                    Password = "password567",
                    Address = "202 Cedar St",
                    Country = "Australia",
                    City = "Sydney",
                    Province = "NSW",
                    Postal_Code = "2000",
                    Phone_Number = "555-5678",
                    Language_ID = null,
                    Cart_ID = null,
                    Register_Date = DateTime.Now
                },

                new Member
                {
                    Member_ID = 8,
                    FirstName = "Jackson",
                    LastName = "Mercer",
                    Email = "jackson.mercer@example.com",
                    Password = "password678",
                    Address = "303 Willow St",
                    Country = "USA",
                    City = "Chicago",
                    Province = "IL",
                    Postal_Code = "60601",
                    Phone_Number = "555-6789",
                    Language_ID = null,
                    Cart_ID = null,
                    Register_Date = DateTime.Now
                },

                new Member
                {
                    Member_ID = 9,
                    FirstName = "Ava",
                    LastName = "Kensington",
                    Email = "ava.kensington@example.com",
                    Password = "password789",
                    Address = "404 Elm St",
                    Country = "Canada",
                    City = "Montreal",
                    Province = "QC",
                    Postal_Code = "H3B 2A7",
                    Phone_Number = "555-7890",
                    Language_ID = null,
                    Cart_ID = null,
                    Register_Date = DateTime.Now
                },

                new Member
                {
                    Member_ID = 10,
                    FirstName = "Oliver",
                    LastName = "Stanton",
                    Email = "oliver.stanton@example.com",
                    Password = "password890",
                    Address = "505 Pine St",
                    Country = "UK",
                    City = "Manchester",
                    Province = "England",
                    Postal_Code = "M1 1AE",
                    Phone_Number = "555-8901",
                    Language_ID = null,
                    Cart_ID = null,
                    Register_Date = DateTime.Now
                },

                new Member
                {
                    Member_ID = 11,
                    FirstName = "Isabella",
                    LastName = "Drake",
                    Email = "isabella.drake@example.com",
                    Password = "password901",
                    Address = "606 Oak St",
                    Country = "Australia",
                    City = "Melbourne",
                    Province = "VIC",
                    Postal_Code = "3000",
                    Phone_Number = "555-9012",
                    Language_ID = null,
                    Cart_ID = null,
                    Register_Date = DateTime.Now
                },

                new Member
                {
                    Member_ID = 12,
                    FirstName = "Mason",
                    LastName = "Carlisle",
                    Email = "mason.carlisle@example.com",
                    Password = "password012",
                    Address = "707 Maple St",
                    Country = "USA",
                    City = "San Francisco",
                    Province = "CA",
                    Postal_Code = "94101",
                    Phone_Number = "555-0123",
                    Language_ID = null,
                    Cart_ID = null,
                    Register_Date = DateTime.Now
                }

            );

        }
    }

}
