using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class CreateMemberViewModel
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
            public string? PreferredLanguage { get; set; }

            // Platform Preference
            [StringLength(255)]
            public string? PreferredPlatform { get; set; }

            [StringLength(255)]
            public string? PreferredCategory { get; set; }

            public bool ReceivePromotionalEmails { get; set; }

            [StringLength(255)]
            public string? Gender { get; set; }

            [StringLength(255)]
            public DateTime? DateOfBirth { get; set; }

            [StringLength(255)]
            public string? Apt_suit { get; set; }

            [StringLength(255)]
            public string? StreetAddress { get; set; }

            [StringLength(255)]
            public string? City { get; set; }

            [StringLength(255)]
            public string? Province { get; set; }

            [StringLength(255)]
            public string? Country { get; set; }

            [StringLength(255)]
            [Display(Name = "Postal Code")]
            [RegularExpression("^[A-Za-z]\\d[A-Za-z][ -]?\\d[A-Za-z]\\d$", ErrorMessage = "Invalid postal code format.")]

            public string? Postal_Code { get; set; }

            [StringLength(500)]
            public string? DeliveryInstruction { get; set; }

            [StringLength(255)]
            [Phone]
            [RegularExpression(@"^(\(\d{3}\)|\d{3})[ -]?\d{3}[ -]?\d{4}$", ErrorMessage = "Invalid phone number format.")]
            public string? Phone_Number { get; set; }

            [DataType(DataType.Date)]
            public DateTime Register_Date { get; set; }

        [BindNever]
        public IEnumerable<SelectListItem> PreferredPlatforms { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem> PrefrerredCategories { get; set; }

    }
}
