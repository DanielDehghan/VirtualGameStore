using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
    public class CartGames
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartGames_ID { get; set; }
        public int Cart_ID { get; set; }
        public int Game_ID { get; set; }
        public Cart Cart { get; set; }
        public Game Game { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
