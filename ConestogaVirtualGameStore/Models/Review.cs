using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Review_ID { get; set; }

        public int Game_ID { get; set; }

        public int Member_ID { get; set; }

        public Member Member { get; set; }

        [Required]
        [StringLength(255)]
        public string ReviewTitle { get; set; }

        [Required]
        [StringLength(255)]
        public string ReviewDescription { get; set; }

        [Required]
        public string ReviewRating { get; set; }

        public string? Status { get; set; }
    }
}
