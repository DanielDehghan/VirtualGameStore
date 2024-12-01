using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConestogaVirtualGameStore.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }

        public int Member_ID { get; set; }

        public Member Member { get; set; }

        public string Status { get; set; }

        public ICollection<Game> Games { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
