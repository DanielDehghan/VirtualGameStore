using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class WishlistFriendFamilyViewModel
    {
        public Member Member { get; set; }
        public List<Wishlist> Wishlists { get; set; }
    }
}
