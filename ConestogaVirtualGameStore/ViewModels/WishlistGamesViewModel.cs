using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class WishlistGamesViewModel
    {
        public Wishlist Wishlist {  get; set; }
        public Game Game { get; set; }
        public List<Game> GamesWishlist { get; set; }
        public List<Wishlist> Wishlists { get; set; }
        public string NewWishlistName { get; set; }
    }
}
