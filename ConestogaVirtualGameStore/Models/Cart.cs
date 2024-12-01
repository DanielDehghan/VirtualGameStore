using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConestogaVirtualGameStore.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cart_ID { get; set; }
        public int Member_ID { get; set; }
        public Member Member { get; set; }
        public DateTime Date_Created { get; set; }
        public ICollection<CartGames> Cart_Games { get; set; }
    }
}
