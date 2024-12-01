using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConestogaVirtualGameStore.Models
{
    public class CreditCards
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CreditCard_ID { get; set; }

        public int Member_ID { get; set; }

        public Member Member { get; set; }

        [MinLength(16)]
        [MaxLength(19)]
        [Required]
        public string? CreditCardNumber { get; set; }

        [Required]
        public DateTime? CreditCardExpiryDate { get; set; }

        [Required]
        public string? CreditCardOwnerName { get; set; }

        [MinLength(3)]
        [MaxLength(3)]
        [Required]
        public string? CreditCardVerificationValue { get; set; }
    }
}
