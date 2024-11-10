using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
    public class Wishlist_Games
    {
        public int Wishlist_ID { get; set; }

        public int GameId { get; set; }

        public Wishlist Wishlist { get; set; } 

        public Game Game { get; set; }
    }
}
