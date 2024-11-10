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
                    Password = "password123",  // This would ideally be hashed in real applications
                    PreferredLanguage = "English",
                    PreferredPlatform = "PC",
                    PreferredCategory = "Action",
                    ReceivePromotionalEmails = true,
                    Gender = "Male",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Apt_suit = "Apt 101",
                    StreetAddress = "123 Main St",
                    City = "Toronto",
                    Province = "ON",
                    Country = "Canada",
                    Postal_Code = "M5A 1A1",
                    DeliveryInstruction = "Leave at front door",
                    Phone_Number = "123-456-7890",
                    Register_Date = DateTime.Now
                },
                new Member
                {
                    Member_ID = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Password = "password456",
                    PreferredLanguage = "French",
                    PreferredPlatform = "PlayStation",
                    PreferredCategory = "RPG",
                    ReceivePromotionalEmails = false,
                    Gender = "Female",
                    DateOfBirth = new DateTime(1992, 8, 22),
                    Apt_suit = "Apt 202",
                    StreetAddress = "456 Elm St",
                    City = "Montreal",
                    Province = "QC",
                    Country = "Canada",
                    Postal_Code = "H2X 1A1",
                    DeliveryInstruction = "Call upon arrival",
                    Phone_Number = "987-654-3210",
                    Register_Date = DateTime.Now
                },
                new Member
                {
                    Member_ID = 3,
                    FirstName = "Alex",
                    LastName = "Johnson",
                    Email = "alex.johnson@example.com",
                    Password = "password789",
                    PreferredLanguage = "English",
                    PreferredPlatform = "Xbox",
                    PreferredCategory = "Shooter",
                    ReceivePromotionalEmails = true,
                    Gender = "Non-binary",
                    DateOfBirth = new DateTime(1995, 11, 5),
                    Apt_suit = "Suite 300",
                    StreetAddress = "789 Maple Ave",
                    City = "Vancouver",
                    Province = "BC",
                    Country = "Canada",
                    Postal_Code = "V5K 1A1",
                    DeliveryInstruction = "Leave with concierge",
                    Phone_Number = "321-654-9870",
                    Register_Date = DateTime.Now
                },
                new Member
                {
                    Member_ID = 4,
                    FirstName = "David",
                    LastName = "Lee",
                    Email = "david.lee@example.com",
                    Password = "Dav!d1234",
                    PreferredLanguage = "Chinese",
                    PreferredPlatform = "PC",
                    PreferredCategory = "Action",
                    ReceivePromotionalEmails = false,
                    Gender = "Male",
                    DateOfBirth = new DateTime(1995, 11, 5),
                    StreetAddress = "101 Cedar Blvd",
                    City = "Calgary",
                    Province = "AB",
                    Country = "Canada",
                    Postal_Code = "T2P 1J9",
                    Phone_Number = "403-555-0100",
                    Register_Date = DateTime.Now.AddYears(-1)
                },
                new Member
                {
                    Member_ID = 5,
                    FirstName = "Evelyn",
                    LastName = "Brown",
                    Email = "evelyn.brown@example.com",
                    Password = "P@ssw0rd!",
                    PreferredLanguage = "German",
                    PreferredPlatform = "Xbox",
                    PreferredCategory = "Strategy",
                    ReceivePromotionalEmails = true,
                    Gender = "Female",
                    DateOfBirth = new DateTime(2000, 7, 22),
                    Apt_suit = "5C",
                    StreetAddress = "303 Birch Lane",
                    City = "Edmonton",
                    Province = "AB",
                    Country = "Canada",
                    Postal_Code = "T5J 1G9",
                    DeliveryInstruction = "Leave with concierge",
                    Phone_Number = "780-555-0112",
                    Register_Date = DateTime.Now.AddDays(-15)
                },
                new Member
                {
                    Member_ID = 6,
                    FirstName = "Frank",
                    LastName = "Nguyen",
                    Email = "frank.nguyen@example.com",
                    Password = "Fr@nk4321",
                    PreferredLanguage = "Danish",
                    PreferredPlatform = "PC",
                    PreferredCategory = "Action",
                    ReceivePromotionalEmails = false,
                    Gender = "Male",
                    DateOfBirth = new DateTime(1988, 9, 9),
                    StreetAddress = "567 Elm St",
                    City = "Ottawa",
                    Province = "ON",
                    Country = "Canada",
                    Postal_Code = "K1P 1A5",
                    Phone_Number = "613-555-0185",
                    Register_Date = DateTime.Now.AddMonths(-9)
                },
                new Member
                {
                    Member_ID = 7,
                    FirstName = "Gina",
                    LastName = "Walker",
                    Email = "gina.walker@example.com",
                    Password = "Gin@123!",
                    PreferredLanguage = "Italian",
                    PreferredPlatform = "Playstation",
                    PreferredCategory = "RPG",
                    ReceivePromotionalEmails = true,
                    Gender = "Female",
                    DateOfBirth = new DateTime(1993, 1, 15),
                    StreetAddress = "234 Spruce Ave",
                    City = "Hamilton",
                    Province = "ON",
                    Country = "Canada",
                    Postal_Code = "L8P 3B5",
                    DeliveryInstruction = "Hand to resident",
                    Phone_Number = "905-555-0133",
                    Register_Date = DateTime.Now.AddMonths(-4)
                },
                new Member
                {
                    Member_ID = 8,
                    FirstName = "Henry",
                    LastName = "Perez",
                    Email = "henry.perez@example.com",
                    Password = "HenrY!678",
                    PreferredLanguage = "Spanish",
                    PreferredPlatform = "PC",
                    PreferredCategory = "Horror",
                    ReceivePromotionalEmails = false,
                    Gender = "Male",
                    DateOfBirth = new DateTime(1975, 12, 28),
                    Apt_suit = "7F",
                    StreetAddress = "128 Cypress Ct",
                    City = "Windsor",
                    Province = "ON",
                    Country = "Canada",
                    Postal_Code = "N9A 6Z8",
                    Phone_Number = "519-555-0154",
                    Register_Date = DateTime.Now.AddYears(-2)
                },
                new Member
                {
                    Member_ID = 9,
                    FirstName = "Ivy",
                    LastName = "Robinson",
                    Email = "ivy.robinson@example.com",
                    Password = "IvY2024!",
                    PreferredLanguage = "English",
                    PreferredPlatform = "Xbox",
                    PreferredCategory = "Sports",
                    ReceivePromotionalEmails = true,
                    Gender = "Female",
                    DateOfBirth = new DateTime(1996, 4, 25),
                    StreetAddress = "104 Willow Dr",
                    City = "Toronto",
                    Province = "ON",
                    Country = "Canada",
                    Postal_Code = "M5G 2M1",
                    Phone_Number = "416-555-0213",
                    Register_Date = DateTime.Now.AddMonths(-5)
                },
                new Member
                {
                    Member_ID = 10,
                    FirstName = "Jack",
                    LastName = "Martinez",
                    Email = "jack.martinez@example.com",
                    Password = "J@ckMart123",
                    PreferredLanguage = "French",
                    PreferredPlatform = "PlayStation",
                    PreferredCategory = "Horror",
                    ReceivePromotionalEmails = false,
                    Gender = "Male",
                    DateOfBirth = new DateTime(1993, 6, 12),
                    Apt_suit = "2A",
                    StreetAddress = "789 Walnut St",
                    City = "Montreal",
                    Province = "QC",
                    Country = "Canada",
                    Postal_Code = "H3B 4P2",
                    DeliveryInstruction = "Leave in mailbox",
                    Phone_Number = "514-555-0183",
                    Register_Date = DateTime.Now.AddMonths(-2)
                },
                new Member
                {
                    Member_ID = 11,
                    FirstName = "Karen",
                    LastName = "Taylor",
                    Email = "karen.taylor@example.com",
                    Password = "K@r3nT@yl0r",
                    PreferredLanguage = "English",
                    PreferredPlatform = "Switch",
                    PreferredCategory = "Adventure",
                    ReceivePromotionalEmails = true,
                    Gender = "Female",
                    DateOfBirth = new DateTime(1998, 7, 5),
                    StreetAddress = "562 Maple Grove",
                    City = "Calgary",
                    Province = "AB",
                    Country = "Canada",
                    Postal_Code = "T2P 2R8",
                    DeliveryInstruction = "Deliver to back door",
                    Phone_Number = "403-555-0157",
                    Register_Date = DateTime.Now.AddMonths(-10)
                },
                new Member
                {
                    Member_ID = 12,
                    FirstName = "Leo",
                    LastName = "Gonzales",
                    Email = "leo.gonzales@example.com",
                    Password = "Le0G0nz@!",
                    PreferredLanguage = "Spanish",
                    PreferredPlatform = "PC",
                    PreferredCategory = "Strategy",
                    ReceivePromotionalEmails = false,
                    Gender = "Male",
                    DateOfBirth = new DateTime(1989, 12, 14),
                    StreetAddress = "90 Forest Hill",
                    City = "Ottawa",
                    Province = "ON",
                    Country = "Canada",
                    Postal_Code = "K2P 1X4",
                    Phone_Number = "613-555-0114",
                    Register_Date = DateTime.Now.AddMonths(-7)
                },
                new Member
                {
                    Member_ID = 13,
                    FirstName = "Mia",
                    LastName = "Liu",
                    Email = "mia.liu@example.com",
                    Password = "Mi@LiuPass1",
                    PreferredLanguage = "Chinese",
                    PreferredPlatform = "PlayStation",
                    PreferredCategory = "Sports",
                    ReceivePromotionalEmails = true,
                    Gender = "Female",
                    DateOfBirth = new DateTime(1992, 10, 30),
                    Apt_suit = "4D",
                    StreetAddress = "456 King St",
                    City = "Vancouver",
                    Province = "BC",
                    Country = "Canada",
                    Postal_Code = "V6B 1N9",
                    Phone_Number = "604-555-0179",
                    Register_Date = DateTime.Now.AddDays(-25)
                }

            );

        }
    }

}
