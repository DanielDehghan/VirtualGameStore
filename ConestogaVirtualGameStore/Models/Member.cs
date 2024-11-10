using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConestogaVirtualGameStore.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Member_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        [StringLength(255)]
        public string? Country { get; set; }

        [StringLength(255)]
        public string? City { get; set; }

        [StringLength(255)]
        public string? Province { get; set; }

        [StringLength(255)]
        public string? Postal_Code { get; set; }

        [StringLength(255)]
        [Phone]
        public string? Phone_Number { get; set; }

        // Foreign key for Language (optional)
        public int? Language_ID { get; set; }

        // Foreign key for Cart (optional)
        public int? Cart_ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Register_Date { get; set; }

        public ICollection<MemberRelationship> MemberRelationshipPrimary { get; set; }

        public ICollection<MemberRelationship> MemberRelationshipRelated { get; set; }

        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
