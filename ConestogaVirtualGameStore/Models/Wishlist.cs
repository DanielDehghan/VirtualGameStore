using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
    public class Wishlist
    {
        [Key]
        public int Wishlist_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Wishlist_Name { get; set; }

        public int Member_ID {  get; set; }

        public Member Member { get; set; }

        public ICollection<Wishlist_Games> Wishlist_Games { get; set; }
    }
}
