using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class CreateWishlistViewModel
    {
        [BindNever]
        public int Wishlist_ID { get; set; }

        [Required(ErrorMessage = "Wishlist name is required")]
        [StringLength(255)]
        public string Wishlist_Name { get; set; }

        public int Member_ID { get; set; }
    }
}
