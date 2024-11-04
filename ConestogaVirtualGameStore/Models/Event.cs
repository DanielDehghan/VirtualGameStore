using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConestogaVirtualGameStore.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }


        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string Province { get; set; }

        [Required]
        [StringLength(255)]
        public string PostalCode { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }
    }
}
