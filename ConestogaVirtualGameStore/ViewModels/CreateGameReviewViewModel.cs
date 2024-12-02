using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class CreateGameReviewViewModel
    {
        [BindNever]
        public int Review_ID { get; set; }

        public int Game_ID { get; set; }

        public int Member_ID { get; set; }

        [Required(ErrorMessage = "Review title is required")]
        [StringLength(255)]
        public string ReviewTitle { get; set; }

        [Required(ErrorMessage = "Review description is required")]
        [StringLength(255)]
        public string ReviewDescription { get; set; }

        [Required(ErrorMessage = "Review rating is required")]
        public string SelectedRating { get; set; }

        [BindNever]
        public IEnumerable<SelectListItem> Ratings { get; set; }
    }
}
